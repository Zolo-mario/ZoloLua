﻿using System;
using System.Collections;
using System.Collections.Generic;

using zlua.Core.Lua;

namespace zlua.Core.ObjectModel
{
    public class Table : GCObject, IEnumerable<KeyValuePair<TValue, TValue>>
    {
        /// <summary>
        /// 用于优化元方法查找的标志
        /// </summary>
        /// <remarks>1 left shift p bits means tagmethod(p) is not present</remarks>
        public byte flags;

        public Table metatable;
        private List<TValue> array;
        private Dictionary<TValue, TValue> hashTablePart;

        public Table(int sizeArrayPart, int sizeHashTablePart)
        {
            hashTablePart = new Dictionary<TValue, TValue>(sizeHashTablePart);
            array = new List<TValue>(sizeArrayPart);
        }

        /// <summary>
        /// main search function
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue luaH_get(TValue key)
        {
            switch (key.tt) {
                case LuaTag.LUA_TNIL: return lobject.NilObject;
                case LuaTag.LUA_TSTRING:
                    return luaH_getstr(key.TStr);

                case LuaTag.LUA_TNUMBER:
                    lua_Number n = key.N;
                    // clua是(int)n，估计问题不大
                    int k = (int)Math.Round(n, MidpointRounding.AwayFromZero);
                    if ((lua_Number)k == n)
                        return luaH_getnum(k);
                    /* else go through */
                    goto default;
                default:
                    TValue v;
                    if (hashTablePart.TryGetValue(key, out v)) {
                        return v;
                    } else {
                        return lobject.NilObject;
                    }
            }
        }

        /// <summary>
        /// 返回查找到的值，否则创建新的键值对并返回该新创建的值
        /// </summary>
        public TValue luaH_set(TValue key)
        {
            TValue v = luaH_get(key);
            // 注意这里是比较地址
            // clua中if (p != luaO_nilobject)，c语言没有等于号重载
            // luaO_nilobject被设计为一个单例，专门用于表查找返回时作为未查到的标志
            // 下面的else分支中还检查了IsNil
            if (Object.ReferenceEquals(v, lobject.NilObject)) {
                return v;
            } else {
                if (key.IsNil) {
                    //TODO
                    //luaG_runerror(L, "table index is nil");
                    throw new Exception();
                } else if (key.IsNumber && Double.IsNaN(key.N)) {
                    //luaG_runerror(L, "table index is NaN");
                    throw new Exception();
                } else {
                    return newkey(key);
                }
            }
        }

        /// <summary>
        /// search function for strings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue luaH_getstr(TString key)
        {
            TValue k = new TValue(key);
            TValue v;
            if (hashTablePart.TryGetValue(k, out v)) {
                return v;
            } else {
                return lobject.NilObject;
            }
        }

        /// <summary>
        /// search function for integers
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue luaH_getnum(int key)
        {
            /* (1 <= key && key <= t->sizearray) */
            // 这里比较有技巧性，负数和非负数各占有符号数的上下一半，互不相交，这样只需要比较一次
            if ((uint)key - 1 < (uint)array.Count) {
                return array[key - 1];
            } else {
                TValue k = new TValue((lua_Number)key);
                TValue v;
                if (hashTablePart.TryGetValue(k, out v)) {
                    return v;
                } else {
                    return lobject.NilObject;
                }
            }
        }

        public TValue luaH_setstr(TString key)
        {
            var v = luaH_getstr(key);
            if (Object.ReferenceEquals(v, lobject.NilObject)) {
                return v;
            } else {
                TValue k = new TValue(key);
                return newkey(k);
            }
        }

        public TValue luaH_setnum(int key)
        {
            TValue v = luaH_getnum(key);
            if (Object.ReferenceEquals(v, lobject.NilObject)) {
                return v;
            } else {
                TValue k = new TValue((lua_Number)key);
                return newkey(k);
            }
        }

        private TValue newkey(TValue k)
        {
            TValue newVal = new TValue();
            hashTablePart[k] = newVal;
            return newVal;
        }

        /// <summary>
        /// Try to find a boundary in table `t'. A `boundary' is an integer index
        /// such that t[i] is non-nil and t[i+1] is nil (and 0 if t[1] is nil).
        /// 尝试找到表的边界t，边界是一个整数索引，使得t[i]非nil，而t[i+1]是nil，如果t[1]是nil返回0
        /// </summary>
        /// <returns></returns>
        public int luaH_getn()
        {
            Table t;
            int j = array.Count;
            if (j > 0 && array[j - 1].IsNil) {
                /* there is a boundary in the array part: (binary) search for it */
                int i = 0;
                while (j - i > 1) {
                    int m = (i + j) / 2;
                    if (array[m - 1].IsNil) j = m;
                    else i = m;
                }
                return i;
            }
            /* else must find a boundary in hash part */
            else if (hashTablePart.Count == 0)  /* hash part is empty? */
                return j;  /* that is easy... */
            else return unbound_search(j);
        }

        private int unbound_search(int j)
        {
            int i = j;  /* i is zero or a present index */
            j++;
            /* find `i' and `j' such that i is present and j is not */
            while (!luaH_getnum(j).IsNil) {
                i = j;
                j *= 2;
                if (j > (2147483647 - 2)) {  /* overflow? */
                                             /* table was built with bad purposes: resort to linear search */
                    i = 1;
                    while (!luaH_getnum(i).IsNil) i++;
                    return i - 1;
                }
            }
            /* now do a binary search between them */
            while (j - i > 1) {
                int m = (i + j) / 2;
                if (luaH_getnum(m).IsNil) j = m;
                else i = m;
            }
            return i;
        }

        public int sizearray { get { return array.Count; } }

        public void luaH_resizearray(int nasize)
        {
            //TODO
            int nsize = (hashTablePart.Count == 0) ? 0 : hashTablePart.Count;
            resize(nasize, nsize);
        }

        private void resize(int nasize, int nhsize)
        {
            for (int i = array.Count; i < nasize; i++) {
                array.Add(new TValue());
            }
            //TODO
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator<KeyValuePair<TValue, TValue>> IEnumerable<KeyValuePair<TValue, TValue>>.GetEnumerator()
        {
            lua_Integer index = 0;
            foreach (var item in array) {
                //yield return
                //    new KeyValuePair<TValue, TValue>(
                //        new TValue(++index), item);
            }
            foreach (var item in hashTablePart) {
                yield return item;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}