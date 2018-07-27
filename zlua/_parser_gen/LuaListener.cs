﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.5-beta001
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\91018\Desktop\zlua\zlua\Lua.g4 by ANTLR 4.6.5-beta001

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace zlua.AntlrGen {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="LuaParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.5-beta001")]
[System.CLSCompliant(false)]
public interface ILuaListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>emptyStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEmptyStat([NotNull] LuaParser.EmptyStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>emptyStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEmptyStat([NotNull] LuaParser.EmptyStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>assignStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignStat([NotNull] LuaParser.AssignStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignStat([NotNull] LuaParser.AssignStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functioncallStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctioncallStat([NotNull] LuaParser.FunctioncallStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functioncallStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctioncallStat([NotNull] LuaParser.FunctioncallStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>breakStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBreakStat([NotNull] LuaParser.BreakStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>breakStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBreakStat([NotNull] LuaParser.BreakStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>doendStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoendStat([NotNull] LuaParser.DoendStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>doendStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoendStat([NotNull] LuaParser.DoendStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>whileStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileStat([NotNull] LuaParser.WhileStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>whileStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileStat([NotNull] LuaParser.WhileStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>repeatStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeatStat([NotNull] LuaParser.RepeatStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>repeatStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeatStat([NotNull] LuaParser.RepeatStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ifelseStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfelseStat([NotNull] LuaParser.IfelseStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ifelseStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfelseStat([NotNull] LuaParser.IfelseStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>forijkStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForijkStat([NotNull] LuaParser.ForijkStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>forijkStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForijkStat([NotNull] LuaParser.ForijkStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>forinStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForinStat([NotNull] LuaParser.ForinStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>forinStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForinStat([NotNull] LuaParser.ForinStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functiondefStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctiondefStat([NotNull] LuaParser.FunctiondefStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functiondefStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctiondefStat([NotNull] LuaParser.FunctiondefStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>localfunctiondefStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLocalfunctiondefStat([NotNull] LuaParser.LocalfunctiondefStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>localfunctiondefStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLocalfunctiondefStat([NotNull] LuaParser.LocalfunctiondefStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>localassignStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLocalassignStat([NotNull] LuaParser.LocalassignStatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>localassignStat</c>
	/// labeled alternative in <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLocalassignStat([NotNull] LuaParser.LocalassignStatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>nilfalsetruevarargExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNilfalsetruevarargExp([NotNull] LuaParser.NilfalsetruevarargExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>nilfalsetruevarargExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNilfalsetruevarargExp([NotNull] LuaParser.NilfalsetruevarargExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>numberExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumberExp([NotNull] LuaParser.NumberExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numberExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumberExp([NotNull] LuaParser.NumberExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>stringExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringExp([NotNull] LuaParser.StringExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringExp([NotNull] LuaParser.StringExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functiondefExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctiondefExp([NotNull] LuaParser.FunctiondefExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functiondefExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctiondefExp([NotNull] LuaParser.FunctiondefExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>prefixexpExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrefixexpExp([NotNull] LuaParser.PrefixexpExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>prefixexpExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrefixexpExp([NotNull] LuaParser.PrefixexpExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tablectorExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTablectorExp([NotNull] LuaParser.TablectorExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tablectorExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTablectorExp([NotNull] LuaParser.TablectorExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>powExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPowExp([NotNull] LuaParser.PowExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>powExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPowExp([NotNull] LuaParser.PowExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unmExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnmExp([NotNull] LuaParser.UnmExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unmExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnmExp([NotNull] LuaParser.UnmExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>muldivExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMuldivExp([NotNull] LuaParser.MuldivExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>muldivExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMuldivExp([NotNull] LuaParser.MuldivExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>addsubExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddsubExp([NotNull] LuaParser.AddsubExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addsubExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddsubExp([NotNull] LuaParser.AddsubExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>concatExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConcatExp([NotNull] LuaParser.ConcatExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>concatExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConcatExp([NotNull] LuaParser.ConcatExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>cmpExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCmpExp([NotNull] LuaParser.CmpExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>cmpExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCmpExp([NotNull] LuaParser.CmpExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>andExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExp([NotNull] LuaParser.AndExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>andExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExp([NotNull] LuaParser.AndExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>orExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrExp([NotNull] LuaParser.OrExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>orExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrExp([NotNull] LuaParser.OrExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>bitwiseExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBitwiseExp([NotNull] LuaParser.BitwiseExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>bitwiseExp</c>
	/// labeled alternative in <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBitwiseExp([NotNull] LuaParser.BitwiseExpContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>normalArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNormalArgs([NotNull] LuaParser.NormalArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>normalArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNormalArgs([NotNull] LuaParser.NormalArgsContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tablectorArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTablectorArgs([NotNull] LuaParser.TablectorArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tablectorArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTablectorArgs([NotNull] LuaParser.TablectorArgsContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>stringArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringArgs([NotNull] LuaParser.StringArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringArgs</c>
	/// labeled alternative in <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringArgs([NotNull] LuaParser.StringArgsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.chunk"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChunk([NotNull] LuaParser.ChunkContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.chunk"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChunk([NotNull] LuaParser.ChunkContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] LuaParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] LuaParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStat([NotNull] LuaParser.StatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStat([NotNull] LuaParser.StatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.retstat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRetstat([NotNull] LuaParser.RetstatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.retstat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRetstat([NotNull] LuaParser.RetstatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.funcname"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncname([NotNull] LuaParser.FuncnameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.funcname"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncname([NotNull] LuaParser.FuncnameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.varlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarlist([NotNull] LuaParser.VarlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.varlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarlist([NotNull] LuaParser.VarlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.namelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamelist([NotNull] LuaParser.NamelistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.namelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamelist([NotNull] LuaParser.NamelistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.explist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExplist([NotNull] LuaParser.ExplistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.explist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExplist([NotNull] LuaParser.ExplistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExp([NotNull] LuaParser.ExpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExp([NotNull] LuaParser.ExpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.nilfalsetruevararg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNilfalsetruevararg([NotNull] LuaParser.NilfalsetruevarargContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.nilfalsetruevararg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNilfalsetruevararg([NotNull] LuaParser.NilfalsetruevarargContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.prefixexp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrefixexp([NotNull] LuaParser.PrefixexpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.prefixexp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrefixexp([NotNull] LuaParser.PrefixexpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctioncall([NotNull] LuaParser.FunctioncallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctioncall([NotNull] LuaParser.FunctioncallContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.varOrExp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarOrExp([NotNull] LuaParser.VarOrExpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.varOrExp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarOrExp([NotNull] LuaParser.VarOrExpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar([NotNull] LuaParser.VarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar([NotNull] LuaParser.VarContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.varSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarSuffix([NotNull] LuaParser.VarSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.varSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarSuffix([NotNull] LuaParser.VarSuffixContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.nameAndArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNameAndArgs([NotNull] LuaParser.NameAndArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.nameAndArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNameAndArgs([NotNull] LuaParser.NameAndArgsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgs([NotNull] LuaParser.ArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgs([NotNull] LuaParser.ArgsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.functiondef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctiondef([NotNull] LuaParser.FunctiondefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.functiondef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctiondef([NotNull] LuaParser.FunctiondefContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.funcbody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncbody([NotNull] LuaParser.FuncbodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.funcbody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncbody([NotNull] LuaParser.FuncbodyContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.parlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParlist([NotNull] LuaParser.ParlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.parlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParlist([NotNull] LuaParser.ParlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.tableconstructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTableconstructor([NotNull] LuaParser.TableconstructorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.tableconstructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTableconstructor([NotNull] LuaParser.TableconstructorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.fieldlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldlist([NotNull] LuaParser.FieldlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.fieldlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldlist([NotNull] LuaParser.FieldlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterField([NotNull] LuaParser.FieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitField([NotNull] LuaParser.FieldContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.fieldsep"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldsep([NotNull] LuaParser.FieldsepContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.fieldsep"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldsep([NotNull] LuaParser.FieldsepContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorOr([NotNull] LuaParser.OperatorOrContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorOr([NotNull] LuaParser.OperatorOrContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorAnd([NotNull] LuaParser.OperatorAndContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorAnd([NotNull] LuaParser.OperatorAndContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorComparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorComparison([NotNull] LuaParser.OperatorComparisonContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorComparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorComparison([NotNull] LuaParser.OperatorComparisonContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorStrcat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorStrcat([NotNull] LuaParser.OperatorStrcatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorStrcat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorStrcat([NotNull] LuaParser.OperatorStrcatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorAddSub"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorAddSub([NotNull] LuaParser.OperatorAddSubContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorAddSub"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorAddSub([NotNull] LuaParser.OperatorAddSubContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorMulDivMod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorMulDivMod([NotNull] LuaParser.OperatorMulDivModContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorMulDivMod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorMulDivMod([NotNull] LuaParser.OperatorMulDivModContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorBitwise"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorBitwise([NotNull] LuaParser.OperatorBitwiseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorBitwise"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorBitwise([NotNull] LuaParser.OperatorBitwiseContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorUnary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorUnary([NotNull] LuaParser.OperatorUnaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorUnary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorUnary([NotNull] LuaParser.OperatorUnaryContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.operatorPower"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperatorPower([NotNull] LuaParser.OperatorPowerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.operatorPower"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperatorPower([NotNull] LuaParser.OperatorPowerContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] LuaParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] LuaParser.NumberContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="LuaParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] LuaParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LuaParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] LuaParser.StringContext context);
}
} // namespace zlua.AntlrGen
