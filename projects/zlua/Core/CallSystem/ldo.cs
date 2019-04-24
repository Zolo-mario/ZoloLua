﻿// 调用系统

using System;
using System.Diagnostics;

using zlua.Core.Configuration;
using zlua.Core.ObjectModel;

namespace zlua.Core.VirtualMachine
{
    public partial class lua_State
    {
        // luaD_call
        //
        // * 调用函数，函数可以是c#函数或lua函数
        // * 调用协议如下：
        //   调用/Call/前，Closure实例和实参被依次压栈
        //   调用/Call/后，Closure和实参被移除，并留下返回值
        // * /Call/并不是与luaD_call完全对应，而是替代了clua中一系列复杂的call函数整体功能
        //   clua实现dofile时有一个非常深的栈，这里简化为一个方法调用
        /// 从C调用一个函数（划重点），相比api里那个重要一点。这里我简单地保证C
        /// 这个call是从lapi开始的call，lapi计算出funcIndex，这条线是算一次C call，在Thread里也存了counter
        /// lua的call指令只使用precall，因为后面跟着goto reentry，而这里要主动调用一次execute开始执行；precall处理C或lua，我们先走lua
        /// lapi和这里ldo的Call只是签名形式不一样；说是ccall是因为这个必须是c api发起的call，因为lua call只调用precall
        /// lua_call 函数和args已经压栈，调用它；是一次C发起的调用
        /// 这个特殊的call不是lua实现内部使用的，他会用api来push func，push args然后调用
        /// 一个例子是每次启动chunk时，push chunk，call it，funcindex=topindex-1
        public void Call(int nargs = 0, int nresults = LUA_MULTRET)
        {
            ++NumCSharpCalls;
            if (NumCSharpCalls >= LuaConfiguration.MaxCalls)
                throw new Exception("CSharp stack overflow");
            // 对于chunk，top-(0+1)
            int funcIndex = top - (nargs + 1);
            // 因为Closure实例cl和实参已经被压栈，可以执行这个cl
            if (PreCall(funcIndex) == PCRLUA) {
                luaV_execute(1);
            }
            --NumCSharpCalls;
        }

        /* results from luaD_precall */
        internal const int PCRLUA = 0;   /* 说明precall初始化了一个lua函数：initiated a call to a Lua function */
        internal const int PCRC = 1;    /* 说明precall调用了一个c函数：did a call to a C function */

        // luaD_precall
        //
        // * 同时也是call指令实现
        // * funindex是相对于base的偏移
        public int PreCall(int funcIndex, int nresults = LUA_MULTRET)
        {
            // * 保存this.savedpc到当前CallInfo的savedpc中
            // * 根据函数参数个数计算待调用函数的base和top值，存入新的CallInfo中
            // * 切换到新的CallInfo
            //获取函数
            TValue funcValue = Stack[funcIndex];
            if (!funcValue.IsFunction) {
                funcValue = TryMetaCall(funcIndex);
            }
            // 保存PC
            this.ci.savedpc = this.pc;
            /* Lua function? prepare its call */
            if (funcValue.Cl is LuaClosure) {
                LuaClosure cl = funcValue.Cl as LuaClosure;
                Proto p = cl.p;
                CallInfo ci = new CallInfo()
                {
                    funcIndex = funcIndex,
                    top = funcIndex + p.MaxStackSize
                };
                if (ci.top >= this.StackLastFree)
                    Alloc(ci.top + 1);
                // 更新pc
                pc = 0;
                codes = p.Code;
                CallInfoStack.Push(ci);
                // 栈帧清为nil
                // 把多余的函数参数设为nil
                for (int st = top; st < ci.top; st++) //st是stacktop
                    Stack[st].SetNil();
                top = ci.top;  //L.top指向栈帧分配好的空间之后
                return PCRLUA;
            }
            /* if is a C function, call it */
            else {
                CallInfo ci = new CallInfo();
                const int MinStackSizeForCSharpFunction = 20;
                if (top + MinStackSizeForCSharpFunction >= StackLastFree)
                    Alloc(top + MinStackSizeForCSharpFunction + 1);
                // 调用C函数
                (Stack[funcIndex].Cl as CSharpClosure).f(this);
                // 调用结束之后的处理
                PosCall(top - @base);
                return PCRC;
            }
        }

        /// <summary>
        /// 从C或lua函数返回;`resultIndex是返回值相对于L.base的偏移(很容易错，因为没有指针）
        /// </summary>
        public void PosCall(int resultOffset)
        {
            CallInfo ci = CallInfoStack.Pop();
            pc = this.ci.savedpc;
            Stack[ci.funcIndex].Value = Stack[@base + resultOffset];
        }

        /// <summary>
        /// tryfuncTM; 尝试返回元方法__call
        /// 我们暂时不管metacall
        /// </summary>
        private TValue TryMetaCall(int funcIndex)
        {
            TValue metamethod = GetMetamethod(Stack[funcIndex], TMS.TM_CALL);
            Debug.Assert(metamethod.IsFunction);
            /* Open a hole inside the stack at `func' */
            for (int i = top; i > funcIndex; i--)
                Stack[i].Value = Stack[i - 1];
            top++;
            Stack[funcIndex].Value = metamethod;/* tag method is the new function to be called */
            return Stack[funcIndex];
        }
    }
}