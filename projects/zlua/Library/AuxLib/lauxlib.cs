﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zlua.Core.VirtualMachine
{
    public partial class lua_State
    {
        /// <summary>
        /// 构造新的lua解释器
        /// </summary>
        /// <returns></returns>
        /// <remarks>注意这和lua_State的ctor不同，比如要设置g.mainthread=this</remarks>
        static lua_State luaL_newstate()
        {
            lua_State L = lua_newstate();
            //TODOlua_atpanic(L, &panic);
            return L;
        }
    }
}
