﻿//========================================================================
// This conversion was produced by the Free Edition of
// C++ to C# Converter courtesy of Tangible Software Solutions.
// Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

#define LUA_NUMBER_DOUBLE

using System.Runtime.InteropServices;

/*
** $Id: luaconf.h,v 1.82.1.7 2008/02/11 16:25:08 roberto Exp $
** Configuration file for Lua
** See Copyright Notice in lua.h
*/





/*
** ==================================================================
** Search for "@@" to find all configurable definitions.
** ===================================================================
*/


/*
@@ LUA_ANSI controls the use of non-ansi features.
** CHANGE it (define it) if you want Lua to avoid the use of any
** non-ansi feature or library.
*/
#if __STRICT_ANSI__
#define LUA_ANSI
#endif


#if !LUA_ANSI && _WIN32
#define LUA_WIN
#endif

#if LUA_USE_LINUX
#define LUA_USE_POSIX
#define LUA_USE_DLOPEN
#define LUA_USE_READLINE
#endif

#if LUA_USE_MACOSX
#define LUA_USE_POSIX
#define LUA_DL_DYLD
#endif



/*
@@ LUA_USE_POSIX includes all functionallity listed as X/Open System
@* Interfaces Extension (XSI).
** CHANGE it (define it) if your system is XSI compatible.
*/
#if LUA_USE_POSIX
#define LUA_USE_MKSTEMP
#define LUA_USE_ISATTY
#define LUA_USE_POPEN
#define LUA_USE_ULONGJMP
#endif


/*
@@ LUA_PATH and LUA_CPATH are the names of the environment variables that
@* Lua check to set its paths.
@@ LUA_INIT is the name of the environment variable that Lua
@* checks for initialization code.
** CHANGE them if you want different names.
*/


/*
@@ LUA_PATH_DEFAULT is the default path that Lua uses to look for
@* Lua libraries.
@@ LUA_CPATH_DEFAULT is the default path that Lua uses to look for
@* C libraries.
** CHANGE them if your machine has a non-conventional directory
** hierarchy or if you want to install your libraries in
** non-conventional directories.
*/
#if _WIN32
/*
** In Windows, any exclamation mark ('!') in the path is replaced by the
** path of the directory of the executable file of the current process.
*/
#define LUA_LDIR
#define LUA_CDIR
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_PATH_DEFAULT ".\\?.lua;" LUA_LDI"?.lua;" LUA_LDIR"?\\init.lua;" LUA_CDIR"?.lua;" LUA_CDIR"?\\init.lua"
#define LUA_PATH_DEFAULT
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_CPATH_DEFAULT ".\\?.dll;" LUA_CDI"?.dll;" LUA_CDIR"loadall.dll"
#define LUA_CPATH_DEFAULT

#else
#define LUA_ROOT
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_LDIR LUA_ROOT "share/lua/5.1/"
#define LUA_LDIR
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_CDIR LUA_ROOT "lib/lua/5.1/"
#define LUA_CDIR
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_PATH_DEFAULT "./?.lua;" LUA_LDI"?.lua;" LUA_LDIR"?/init.lua;" LUA_CDIR"?.lua;" LUA_CDIR"?/init.lua"
#define LUA_PATH_DEFAULT
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_CPATH_DEFAULT "./?.so;" LUA_CDI"?.so;" LUA_CDIR"loadall.so"
#define LUA_CPATH_DEFAULT
#endif


/*
@@ LUA_DIRSEP is the directory separator (for submodules).
** CHANGE it if your machine does not use "/" as the directory separator
** and is not Windows. (On Windows Lua automatically uses "\".)
*/
#if _WIN32
#define LUA_DIRSEP
#else
#define LUA_DIRSEP
#endif


/*
@@ LUA_PATHSEP is the character that separates templates in a path.
@@ LUA_PATH_MARK is the string that marks the substitution points in a
@* template.
@@ LUA_EXECDIR in a Windows path is replaced by the executable's
@* directory.
@@ LUA_IGMARK is a mark to ignore all before it when bulding the
@* luaopen_ function name.
** CHANGE them if for some reason your system cannot use those
** characters. (E.g., if one of those characters is a common character
** in file/directory names.) Probably you do not need to change them.
*/


/*
@@ LUA_INTEGER is the integral type used by lua_pushinteger/lua_tointeger.
** CHANGE that if ptrdiff_t is not adequate on your machine. (On most
** machines, ptrdiff_t gives a good choice between int or long.)
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_INTEGER ptrdiff_t


/*
@@ LUA_API is a mark for all core API functions.
@@ LUALIB_API is a mark for all standard library functions.
** CHANGE them if you need to define those functions in some special way.
** For instance, if you want to create one Windows DLL with the core and
** the libraries, you may want to use the following definition (define
** LUA_BUILD_AS_DLL to get it).
*/
#if LUA_BUILD_AS_DLL

#if LUA_CORE || LUA_LIB
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_API __declspec(dllexport)
#define LUA_API
#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_API __declspec(dllimport)
#define LUA_API
#endif

#else

//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_API extern
#define LUA_API

#endif

/* more often than not the libs go together with the core */
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUALIB_API LUA_API


/*
@@ LUAI_FUNC is a mark for all extern functions that are not to be
@* exported to outside modules.
@@ LUAI_DATA is a mark for all extern (const) variables that are not to
@* be exported to outside modules.
** CHANGE them if you need to mark them in some special way. Elf/gcc
** (versions 3.2 and later) mark them as "hidden" to optimize access
** when Lua is compiled as a shared library.
*/
#if luaall_c
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_FUNC static
#define LUAI_FUNC
#define LUAI_DATA

//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
#elif __GNUC__ && ((__GNUC__*100 + __GNUC_MINOR__) >= 302) && __ELF__
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_FUNC extern
#define LUAI_FUNC
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_DATA LUAI_FUNC
#define LUAI_DATA

#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_FUNC extern
#define LUAI_FUNC
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_DATA extern
#define LUAI_DATA
#endif



/*
@@ LUA_QL describes how error messages quote program elements.
** CHANGE it if you want a different appearance.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_QL(x) "'" x "'"
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_QS LUA_QL("%s")


/*
@@ LUA_IDSIZE gives the maximum size for the description of the source
@* of a function in debug information.
** CHANGE it if you want a different size.
*/


/*
** {==================================================================
** Stand-alone configuration
** ===================================================================
*/

#if lua_c || luaall_c

/*
@@ lua_stdin_is_tty detects whether the standard input is a 'tty' (that
@* is, whether we're running lua interactively).
** CHANGE it if you have a better definition for non-POSIX/non-Windows
** systems.
*/
#if LUA_USE_ISATTY
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_stdin_is_tty() isatty(0)
#define lua_stdin_is_tty
#elif LUA_WIN
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_stdin_is_tty() _isatty(_fileno(stdin))
#define lua_stdin_is_tty
#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_stdin_is_tty() 1
#define lua_stdin_is_tty
#endif


/*
@@ LUA_PROMPT is the default prompt used by stand-alone Lua.
@@ LUA_PROMPT2 is the default continuation prompt used by stand-alone Lua.
** CHANGE them if you want different prompts. (You can also change the
** prompts dynamically, assigning to globals _PROMPT/_PROMPT2.)
*/
#define LUA_PROMPT
#define LUA_PROMPT2


/*
@@ LUA_PROGNAME is the default name for the stand-alone Lua program.
** CHANGE it if your stand-alone interpreter has a different name and
** your system is not able to detect that name automatically.
*/
#define LUA_PROGNAME


/*
@@ LUA_MAXINPUT is the maximum length for an input line in the
@* stand-alone interpreter.
** CHANGE it if you need longer lines.
*/
#define LUA_MAXINPUT


/*
@@ lua_readline defines how to show a prompt and then read a line from
@* the standard input.
@@ lua_saveline defines how to "save" a read line in a "history".
@@ lua_freeline defines how to free a line read by lua_readline.
** CHANGE them if you want to improve this functionality (e.g., by using
** GNU readline and history facilities).
*/
#if LUA_USE_READLINE
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_readline(L,b,p) ((void)L, ((b)=readline(p)) != NULL)
#define lua_readline
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_saveline(L,idx) if (lua_strlen(L,idx) > 0) add_history(lua_tostring(L, idx));
#define lua_saveline
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_freeline(L,b) ((void)L, free(b))
#define lua_freeline
#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_readline(L,b,p) ((void)L, fputs(p, stdout), fflush(stdout), fgets(b, LUA_MAXINPUT, stdin) != NULL)
#define lua_readline
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_saveline(L,idx) { (void)L; (void)idx; }
#define lua_saveline
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_freeline(L,b) { (void)L; (void)b; }
#define lua_freeline
#endif

#endif

/* }================================================================== */


/*
@@ LUAI_GCPAUSE defines the default pause between garbage-collector cycles
@* as a percentage.
** CHANGE it if you want the GC to run faster or slower (higher values
** mean larger pauses which mean slower collection.) You can also change
** this value dynamically.
*/


/*
@@ LUAI_GCMUL defines the default speed of garbage collection relative to
@* memory allocation as a percentage.
** CHANGE it if you want to change the granularity of the garbage
** collection. (Higher values mean coarser collections. 0 represents
** infinity, where each step performs a full collection.) You can also
** change this value dynamically.
*/



/*
@@ LUA_COMPAT_GETN controls compatibility with old getn behavior.
** CHANGE it (define it) if you want exact compatibility with the
** behavior of setn/getn in Lua 5.0.
*/

/*
@@ LUA_COMPAT_LOADLIB controls compatibility about global loadlib.
** CHANGE it to undefined as soon as you do not need a global 'loadlib'
** function (the function is still available as 'package.loadlib').
*/

/*
@@ LUA_COMPAT_VARARG controls compatibility with old vararg feature.
** CHANGE it to undefined as soon as your programs use only '...' to
** access vararg parameters (instead of the old 'arg' table).
*/

/*
@@ LUA_COMPAT_MOD controls compatibility with old math.mod function.
** CHANGE it to undefined as soon as your programs use 'math.fmod' or
** the new '%' operator instead of 'math.mod'.
*/

/*
@@ LUA_COMPAT_LSTR controls compatibility with old long string nesting
@* facility.
** CHANGE it to 2 if you want the old behaviour, or undefine it to turn
** off the advisory error when nesting [[...]].
*/

/*
@@ LUA_COMPAT_GFIND controls compatibility with old 'string.gfind' name.
** CHANGE it to undefined as soon as you rename 'string.gfind' to
** 'string.gmatch'.
*/

/*
@@ LUA_COMPAT_OPENLIB controls compatibility with old 'luaL_openlib'
@* behavior.
** CHANGE it to undefined as soon as you replace to 'luaL_register'
** your uses of 'luaL_openlib'
*/



/*
@@ luai_apicheck is the assert macro used by the Lua-C API.
** CHANGE luai_apicheck if you want Lua to perform some checks in the
** parameters it gets from API calls. This may slow down the interpreter
** a bit, but may be quite useful when debugging C code that interfaces
** with Lua. A useful redefinition is to use assert.h.
*/
#if LUA_USE_APICHECK
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_apicheck(L,o) { (void)L; assert(o); }
#define luai_apicheck
#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_apicheck(L,o) { (void)L; }
#define luai_apicheck
#endif


/*
@@ LUAI_BITSINT defines the number of bits in an int.
** CHANGE here if Lua cannot automatically detect the number of bits of
** your machine. Probably you do not need to change this.
*/
/* avoid overflows in comparison */
//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
#if INT_MAX-20 < 32760
#define LUAI_BITSINT
//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
#elif INT_MAX > 2147483640L
/* int has at least 32 bits */
#define LUAI_BITSINT
#else
#error "you must define LUA_BITSINT with number of bits in an integer"
#endif


/*
@@ LUAI_UINT32 is an unsigned integer with at least 32 bits.
@@ LUAI_INT32 is an signed integer with at least 32 bits.
@@ LUAI_UMEM is an unsigned integer big enough to count the total
@* memory used by Lua.
@@ LUAI_MEM is a signed integer big enough to count the total memory
@* used by Lua.
** CHANGE here if for some weird reason the default definitions are not
** good enough for your machine. (The definitions in the 'else'
** part always works, but may waste space on machines with 64-bit
** longs.) Probably you do not need to change this.
*/
//C++ TO C# CONVERTER TODO TASK: C# does not allow setting or comparing #define constants:
#if LUAI_BITSINT >= 32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_UINT32 unsigned int
#define LUAI_UINT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_INT32 int
#define LUAI_INT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_MAXINT32 INT_MAX
#define LUAI_MAXINT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_UMEM size_t
#define LUAI_UMEM
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_MEM ptrdiff_t
#define LUAI_MEM
#else
/* 16-bit ints */
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_UINT32 unsigned long
#define LUAI_UINT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_INT32 long
#define LUAI_INT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_MAXINT32 LONG_MAX
#define LUAI_MAXINT32
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_UMEM unsigned long
#define LUAI_UMEM
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_MEM long
#define LUAI_MEM
#endif


/*
@@ LUAI_MAXCALLS limits the number of nested calls.
** CHANGE it if you need really deep recursive calls. This limit is
** arbitrary; its only purpose is to stop infinite recursion before
** exhausting memory.
*/


/*
@@ LUAI_MAXCSTACK limits the number of Lua stack slots that a C function
@* can use.
** CHANGE it if you need lots of (Lua) stack space for your C
** functions. This limit is arbitrary; its only purpose is to stop C
** functions to consume unlimited stack space. (must be smaller than
** -LUA_REGISTRYINDEX)
*/



/*
** {==================================================================
** CHANGE (to smaller values) the following definitions if your system
** has a small C stack. (Or you may want to change them to larger
** values if your system has a large C stack and these limits are
** too rigid for you.) Some of these constants control the size of
** stack-allocated arrays used by the compiler or the interpreter, while
** others limit the maximum number of recursive calls that the compiler
** or the interpreter can perform. Values too large may cause a C stack
** overflow for some forms of deep constructs.
** ===================================================================
*/


/*
@@ LUAI_MAXCCALLS is the maximum depth for nested C calls (short) and
@* syntactical nested non-terminals in a program.
*/


/*
@@ LUAI_MAXVARS is the maximum number of local variables per function
@* (must be smaller than 250).
*/


/*
@@ LUAI_MAXUPVALUES is the maximum number of upvalues per function
@* (must be smaller than 250).
*/


/*
@@ LUAL_BUFFERSIZE is the buffer size used by the lauxlib buffer system.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAL_BUFFERSIZE BUFSIZ

/* }================================================================== */




/*
** {==================================================================
@@ LUA_NUMBER is the type of numbers in Lua.
** CHANGE the following definitions only if you want to build Lua
** with a number type different from double. You may also need to
** change lua_number2int & lua_number2integer.
** ===================================================================
*/

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_NUMBER double

/*
@@ LUAI_UACNUMBER is the result of an 'usual argument conversion'
@* over a number.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_UACNUMBER double


/*
@@ LUA_NUMBER_SCAN is the format for reading numbers.
@@ LUA_NUMBER_FMT is the format for writing numbers.
@@ lua_number2str converts a number to a string.
@@ LUAI_MAXNUMBER2STR is maximum size of previous conversion.
@@ lua_str2number converts a string to a number.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2str(s,n) sprintf((s), LUA_NUMBER_FMT, (n))
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_str2number(s,p) strtod((s), (p))


/*
@@ The luai_num* macros define the primitive operations over numbers.
*/
#if LUA_CORE
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numadd(a,b) ((a)+(b))
#define luai_numadd
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numsub(a,b) ((a)-(b))
#define luai_numsub
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_nummul(a,b) ((a)*(b))
#define luai_nummul
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numdiv(a,b) ((a)/(b))
#define luai_numdiv
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_nummod(a,b) ((a) - floor((a)/(b))*(b))
#define luai_nummod
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numpow(a,b) (pow(a,b))
#define luai_numpow
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numunm(a) (-(a))
#define luai_numunm
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numeq(a,b) ((a)==(b))
#define luai_numeq
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numlt(a,b) ((a)<(b))
#define luai_numlt
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numle(a,b) ((a)<=(b))
#define luai_numle
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_numisnan(a) (!luai_numeq((a), (a)))
#define luai_numisnan
#endif


/*
@@ lua_number2int is a macro to convert lua_Number to int.
@@ lua_number2integer is a macro to convert lua_Number to lua_Integer.
** CHANGE them if you know a faster way to convert a lua_Number to
** int (with any rounding method and without throwing errors) in your
** system. In Pentium machines, a naive typecast from double to int
** in C is extremely slow, so any alternative is worth trying.
*/

/* On a Pentium, resort to a trick */
#if LUA_NUMBER_DOUBLE && !LUA_ANSI && !__SSE2__ && (__i386 || _M_IX86 || __i386__)

/* On a Microsoft compiler, use assembler */
#if _MSC_VER

//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2int(i,d) __asm fld d __asm fistp i
#define lua_number2int
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2integer(i,n) lua_number2int(i, n)
#define lua_number2integer

/* the next trick should work on any Pentium, but sometimes clashes
   with a DirectX idiosyncrasy */
#else

//C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#, but the following union can be replicated with the StructLayout and FieldOffset attributes:
//ORIGINAL LINE: union luai_Cast
[StructLayout(LayoutKind.Explicit)]
public struct luai_Cast
{
	[FieldOffset(0)]
	public double l_d;
	[FieldOffset(0)]
	public int l_l;
}
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2int(i,d) { volatile union luai_Cast u; u.l_d = (d) + 6755399441055744.0; (i) = u.l_l; }
#define lua_number2int
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2integer(i,n) lua_number2int(i, n)
#define lua_number2integer

#endif


/* this option always works, but may be slow */
#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2int(i,d) ((i)=(int)(d))
#define lua_number2int
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_number2integer(i,d) ((i)=(lua_Integer)(d))
#define lua_number2integer

#endif

/* }================================================================== */


/*
@@ LUAI_USER_ALIGNMENT_T is a type that requires maximum alignment.
** CHANGE it if your system requires alignments larger than double. (For
** instance, if your system supports long doubles and they must be
** aligned in 16-byte boundaries, then you should add long double in the
** union.) Probably you do not need to change this.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_USER_ALIGNMENT_T union { double u; void *s; long l; }


/*
@@ LUAI_THROW/LUAI_TRY define how Lua does exception handling.
** CHANGE them if you prefer to use longjmp/setjmp even with C++
** or if want/don't to use _longjmp/_setjmp instead of regular
** longjmp/setjmp. By default, Lua handles errors with exceptions when
** compiling as C++ code, with _longjmp/_setjmp when asked to use them,
** and with longjmp/setjmp otherwise.
*/
#if __cplusplus
/* C++ exceptions */
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_THROW(L,c) throw(c)
#define LUAI_THROW
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_TRY(L,c,a) try { a } catch(...) { if ((c)->status == 0) (c)->status = -1; }
#define LUAI_TRY
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_jmpbuf int
#define luai_jmpbuf

#elif LUA_USE_ULONGJMP
/* in Unix, try _longjmp/_setjmp (more efficient) */
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_THROW(L,c) _longjmp((c)->b, 1)
#define LUAI_THROW
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_TRY(L,c,a) if (_setjmp((c)->b) == 0) { a }
#define LUAI_TRY
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_jmpbuf jmp_buf
#define luai_jmpbuf

#else
/* default handling with long jumps */
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_THROW(L,c) longjmp((c)->b, 1)
#define LUAI_THROW
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUAI_TRY(L,c,a) if (setjmp((c)->b) == 0) { a }
#define LUAI_TRY
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_jmpbuf jmp_buf
#define luai_jmpbuf

#endif


/*
@@ LUA_MAXCAPTURES is the maximum number of captures that a pattern
@* can do during pattern-matching.
** CHANGE it if you need more captures. This limit is arbitrary.
*/


/*
@@ lua_tmpnam is the function that the OS library uses to create a
@* temporary name.
@@ LUA_TMPNAMBUFSIZE is the maximum size of a name created by lua_tmpnam.
** CHANGE them if you have an alternative to tmpnam (which is considered
** insecure) or if you want the original tmpnam anyway.  By default, Lua
** uses tmpnam except when POSIX is available, where it uses mkstemp.
*/
#if loslib_c || luaall_c

#if LUA_USE_MKSTEMP
#define LUA_TMPNAMBUFSIZE
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_tmpnam(b,e) { strcpy(b, "/tmp/lua_XXXXXX"); e = mkstemp(b); if (e != -1) close(e); e = (e == -1); }
#define lua_tmpnam

#else
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_TMPNAMBUFSIZE L_tmpnam
#define LUA_TMPNAMBUFSIZE
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_tmpnam(b,e) { e = (tmpnam(b) == NULL); }
#define lua_tmpnam
#endif

#endif


/*
@@ lua_popen spawns a new process connected to the current one through
@* the file streams.
** CHANGE it if you have a way to implement it in your system.
*/
#if LUA_USE_POPEN

//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_popen(L,c,m) ((void)L, fflush(NULL), popen(c,m))
#define lua_popen
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_pclose(L,file) ((void)L, (pclose(file) != -1))
#define lua_pclose

#elif LUA_WIN

//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_popen(L,c,m) ((void)L, _popen(c,m))
#define lua_popen
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_pclose(L,file) ((void)L, (_pclose(file) != -1))
#define lua_pclose

#else

//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_popen(L,c,m) ((void)((void)c, m), luaL_error(L, LUA_QL("popen") " not supported"), (FILE*)0)
#define lua_popen
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define lua_pclose(L,file) ((void)((void)L, file), 0)
#define lua_pclose

#endif

/*
@@ LUA_DL_* define which dynamic-library system Lua should use.
** CHANGE here if Lua has problems choosing the appropriate
** dynamic-library system for your platform (either Windows' DLL, Mac's
** dyld, or Unix's dlopen). If your system is some kind of Unix, there
** is a good chance that it has dlopen, so LUA_DL_DLOPEN will work for
** it.  To use dlopen you also need to adapt the src/Makefile (probably
** adding -ldl to the linker options), so Lua does not select it
** automatically.  (When you change the makefile to add -ldl, you must
** also add -DLUA_USE_DLOPEN.)
** If you do not want any kind of dynamic library, undefine all these
** options.
** By default, _WIN32 gets LUA_DL_DLL and MAC OS X gets LUA_DL_DYLD.
*/
#if LUA_USE_DLOPEN
#define LUA_DL_DLOPEN
#endif

#if LUA_WIN
#define LUA_DL_DLL
#endif


/*
@@ LUAI_EXTRASPACE allows you to add user-specific data in a lua_State
@* (the data goes just *before* the lua_State pointer).
** CHANGE (define) this if you really need that. This value must be
** a multiple of the maximum alignment required for your machine.
*/


/*
@@ luai_userstate* allow user-specific actions on threads.
** CHANGE them if you defined LUAI_EXTRASPACE and need to do something
** extra when a thread is created/deleted/resumed/yielded.
*/
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstateopen(L) ((void)L)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstateclose(L) ((void)L)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstatethread(L,L1) ((void)L)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstatefree(L) ((void)L)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstateresume(L,n) ((void)L)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define luai_userstateyield(L,n) ((void)L)


/*
@@ LUA_INTFRMLEN is the length modifier for integer conversions
@* in 'string.format'.
@@ LUA_INTFRM_T is the integer type correspoding to the previous length
@* modifier.
** CHANGE them if your system supports long long or does not support long.
*/

#if LUA_USELONGLONG

#define LUA_INTFRMLEN
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_INTFRM_T long long
#define LUA_INTFRM_T

#else

#define LUA_INTFRMLEN
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LUA_INTFRM_T long
#define LUA_INTFRM_T

#endif



/* =================================================================== */

/*
** Local configuration. You can use this space to add your redefinitions
** without modifying the main part of the file.
*/




