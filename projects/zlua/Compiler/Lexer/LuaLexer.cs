﻿using System;

// 词法分析

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace zlua.Compiler.Lexer
{
    // 词法分析器
    //
    // 例子：
    // 实例化传给TokenStream再给parser调用，比如下面这样：
    // new Parser(new TokenStream(new Lexer("print(\"hello world\")","")))
    internal class LuaLexer : IEnumerable<Token>
    {
        #region 公有属性

        public string Chunk { get; }

        public string ChunkName { get; }

        #endregion 公有属性

        #region 私有属性

        // chunk指针，指向还未处理的第一个字符
        private int Position { get; set; } = 0;

        #endregion 私有属性

        #region 构造函数

        public LuaLexer(string chunk, string chunkName)
        {
            Chunk = chunk;
            ChunkName = chunkName;
        }

        #endregion 构造函数

        #region 公有方法

        public IEnumerator<Token> GetEnumerator()
        {
            int line = 1;

            #region 内嵌辅助函数

            // 构造带有当前行号的Token
            //
            // local function是c#7的功能，没必要使用，我们尽量维持在c#4以兼容unity
            Func<TokenKind, string, Token> NewToken = (TokenKind kind, string lexeme) => new Token(line, kind, lexeme);

            // [x] 慢慢重构使用这个lambda
            Func<TokenKind, Token> NewSymbol = (TokenKind kind) => new Token(line, kind, "");

            // 跳过空白符，遇到换行符时递增行号
            //
            // * 换行符有'\n'，'\r'，"\n\r"，"\r\n"
            // * \f和\v是比较少见的空白符
            //   leptjson就是普通的tnr和space
            // * leptjson不记录行号，因此\n\r它不用考虑
            Action SkipWhitespace = () =>
            {
                // 用于跳出外层循环
                bool flag = true;
                while (IsNotEndOfChunk && flag) {
                    // 比较下面两种写法
                    // switch方式虽然多写一点不会死的
                    //if(c==' ' || c == '\f' || c == '\v') {
                    //reader.Read();
                    //}else if(c=='')
                    switch (Peek()) {
                        case ' ':
                            Position++;
                            break;

                        case '\t':
                            Position++;
                            break;

                        case '\f':
                            Position++;
                            break;

                        case '\v':
                            Position++;
                            break;

                        case '\n':
                            Position++;
                            line++;
                            // "\n\r"
                            TestAndRead('\r');
                            break;

                        case '\r':
                            Position++;
                            line++;
                            TestAndRead('\n');
                            break;

                        default:
                            flag = false;
                            break;
                    }
                }
            };

            // 处理转义字符
            //
            // 传入builder是因为\z并不返回char
            // 而是执行动作
            // 内嵌是因为\z要调用SkipWhitespace
            Action<StringBuilder> Escape =
                (StringBuilder builder) =>
                {
                    char c = Read();
                    char outChar;
                    if (Token.SingleCharEscapetable.TryGetValue(c, out outChar)) {
                        builder.Append(outChar);
                        return;
                    } else {
                        switch (c) {
                            case 'z':
                                SkipWhitespace();
                                break;
                            // \xXX XX是两位十六进制代表的ascii码
                            case 'x':
                                // 一下子写不对的corner case，先跳过
                                // 下面的代码可能是错误的，因为XX需要专用的解析，标准库的可能不适用
                                //char[] cs = Chunk.GetRange(Position, 2).ToArray();
                                //byte outByte;
                                //if (!byte.TryParse(new String(cs), out outByte)) {
                                //    throw new Exception("两位ascii整数格式不正确"); // TODO看心情验证ascii首位为0，不知道一般的解码器是否验证。。
                                //} else {
                                //    builder.Append((char)outByte);
                                //}
                                throw new NotImplementedException();
                                break;
                            // \u{XXX} utf8字符
                            case 'u':
                                throw new NotImplementedException();
                                break;

                            default: {
                                    // TODO \nnn 三位十进制，代表ascii，懒得搞了
                                    throw new NotImplementedException();
                                    throw new Exception("错误的转义字符内容");
                                    break;
                                }
                        }
                    }
                };

            // 扫描一段字符串，转换其中的转义字符
            //
            // 这里必须做好转义，因为长字符串是没有转义的，而字符串我们只定义了一个token类型，所以必须统一返回解析好的字符串
            Func<string> ScanShortString = () =>
            {
                char leftQuote = Read();
                StringBuilder builder = new StringBuilder();
                while (IsNotEndOfChunk) {
                    char c = Read();
                    // 如果是转义，处理好
                    if (c == '\\') {
                        Escape(builder);
                    } else if (c == leftQuote) {
                        return builder.ToString();
                    } else {
                        builder.Append(c);
                    }
                }
                // TODO error
                return "";
            };

            #endregion 内嵌辅助函数

            while (IsNotEndOfChunk) {
                SkipWhitespace();
                // 若源文本末尾是空白符，跳过空白后Position已经越界
                if (!IsNotEndOfChunk)
                    break;

                char c = Peek();

                // 查表是为了过滤，因为这些字符有共同特点
                TokenKind outKind;
                Tuple<TokenKind, char, TokenKind> ouTuple;
                if (Token.SingleCharSymbols.TryGetValue(c, out outKind)) {
                    Position++;
                    yield return NewSymbol(outKind);
                } else if (Token.DoubleCharSymbols.TryGetValue(c, out ouTuple)) {
                    Position++;
                    if (TestAndRead(ouTuple.Item2)) {
                        yield return NewSymbol(ouTuple.Item3);
                    } else {
                        yield return NewSymbol(ouTuple.Item1);
                    }
                } else {
                    switch (c) {
                        // 下面两个也是一样的逻辑，但是就两个，手写了
                        case '<': {
                                Position++;
                                // <<
                                if (TestAndRead('<')) {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_SHL);
                                }
                                // <=
                                else if (TestAndRead('=')) {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_LE);
                                }
                                // <
                                else {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_LT);
                                }
                                break;
                            }
                        case '>': {
                                Position++;
                                if (TestAndRead('>')) {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_SHR);
                                } else if (TestAndRead('=')) {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_GE);
                                } else {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_GT);
                                }
                                break;
                            }
                        // ...，..，.和.开头的浮点数
                        // 注意这里是贪婪的
                        case '.': {
                                // ...
                                if (Chunk[Position + 1] == '.' && Chunk[Position + 2] == '.') {
                                    Position += 3;
                                    yield return NewSymbol(TokenKind.TOKEN_VARARG);
                                }
                                // ..
                                else if (Chunk[Position + 1] == '.') {
                                    Position += 2;
                                    yield return NewSymbol(TokenKind.TOKEN_OP_CONCAT);
                                }
                                // .
                                else {
                                    // peek一个字符以区别浮点数
                                    // 这个浮点数必须在这里处理，因为c#的switch有严格的break要求
                                    // 事后ifelse也不好，所以这里多写一行
                                    // 注意相反的条件必须检查eof
                                    // if (i == -1 || !Char.IsDigit((char)i))
                                    if (Char.IsDigit(Chunk[Position + 1])) {
                                        yield return NewToken(TokenKind.TOKEN_NUMBER, ScanNumber());
                                    } else {
                                        Position++;
                                        yield return NewSymbol(TokenKind.TOKEN_SEP_DOT);
                                    }
                                }
                                break;
                            }
                        // 长字符串和表索引
                        case '[': {
                                Position++;
                                // 注意这里不读掉这个[或者=
                                c = Peek();
                                if (c == '[' || c == '=') {
                                    yield return NewToken(TokenKind.TOKEN_STRING, ScanLongString());
                                } else {
                                    yield return NewSymbol(TokenKind.TOKEN_SEP_LBRACK);
                                }
                                break;
                            }
                        case '\'': {
                                yield return NewToken(TokenKind.TOKEN_STRING, ScanShortString());
                                break;
                            }
                        case '"': {
                                yield return NewToken(TokenKind.TOKEN_STRING, ScanShortString());
                                break;
                            }
                        case '-': {
                                Position++;
                                if (TestAndRead('-')) {
                                    SkipComment();
                                } else {
                                    yield return NewSymbol(TokenKind.TOKEN_OP_MINUS);
                                }
                                break;
                            }
                        default: {
                                // 这里我们不处理dot开头的浮点数
                                // 在上面dot处处理
                                if ( /*c == '.' ||*/ Char.IsDigit(c)) {
                                    yield return NewToken(TokenKind.TOKEN_NUMBER, ScanNumber());
                                } else if (c == '_' || Char.IsLetter(c)) {
                                    string identifier = ScanIdentifier();
                                    if (Token.Keywords.TryGetValue(identifier, out outKind)) {
                                        yield return NewToken(outKind, identifier);
                                    } else {
                                        yield return NewToken(TokenKind.TOKEN_IDENTIFIER, identifier);
                                    }
                                } else {
                                    // TODO syntax error
                                    throw new Exception($"unexpected symbol near {c}");
                                }
                                break;
                            }
                    }
                }
            }
            // chunk结束，返回eof
            yield return NewSymbol(TokenKind.TOKEN_EOF);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion 公有方法

        #region 私有方法

        // 测试前瞻字符是否为/c/，是则前进一格chunk指针
        //
        // 在条件中有副作用不是一个好习惯，但是这是一个辅助函数
        private bool TestAndRead(char c)
        {
            if (Position < Chunk.Length && Chunk[Position] == c) {
                Position++;
                return true;
            } else {
                return false;
            }
        }

        // 测试前瞻字符是否满足/predicate/，是则前进一格指针
        private bool TestAndRead(Predicate<char> predicate)
        {
            if (predicate(Peek())) {
                Position++;
                return true;
            } else {
                return false;
            }
        }

        private bool TestPeek(char c)
        {
            return Chunk[Position] == c;
        }

        private bool TestPeek(Predicate<char> predicate)
        {
            return predicate(Peek());
        }

        private char Read()
        {
            return Chunk[Position++];
        }

        private char Peek()
        {
            return Chunk[Position];
        }

        private bool IsNotEndOfChunk {
            // 初始值 0<n
            get { return Position < Chunk.Length; }
        }

        //
        //
        // 不会抛出异常
        private string ScanIdentifier()
        {
            int count = MaxLength(Token.MaxLengthOfIdentifier);
            var match = Regex.Match(Chunk.Substring(Position, count), Token.ReIdentifier);
            Position += match.Length;
            return match.Value;
        }

        private int MaxLength(int maxLength)
        {
            int count = Position + maxLength <= Chunk.Length ?
                maxLength : Chunk.Length - Position;
            return count;
        }

        private string ScanNumber()
        {
            int count = MaxLength(Token.MaxLengthOfNumber);
            Match match = Regex.Match(Chunk.Substring(Position, count), Token.ReNumber);
            if (match.Success) {
                Position += match.Length;
                return match.Value;
            } else {
                // TODO
                throw new Exception("parse number error");
            }
        }

        private int ScanNumLeftBracket()
        {
            int i = 0;
            while (TestAndRead('=')) {
                i++;
            }
            return i;
        }

        // 扫描并返回字符串内容
        //
        // [=[ xxx ]=] => xxx
        // 这里我们要验证等号个数相等
        // 这里我真的写得超级复杂。。没办法。。
        private string ScanLongString()
        {
            Read();

            int n = ScanNumLeftBracket();
            if (!TestAndRead('[')) {
                throw new Exception("invalid long string delimiter near");
            }
            // 跳过第一个换行符
            // TODO 没处理其他换行符
            // TODO 长字符串将四种换行符统一换成\n
            TestAndRead('\n');
            // 解析来正式解析字符串内容，不允许转义
            StringBuilder builder = new StringBuilder();
            while (IsNotEndOfChunk) {
                // 可能是字符串结尾，形如]==]
                // 如果没匹配就仍然是字符串内部，要把读出的加入builder
                // 检查过了，没问题，就是太烦了
                // 注意这里是没法正则的，所以只好手写逻辑
                if (TestAndRead(']')) {
                    List<char> cs = new List<char>('[');
                    bool pass = true;
                    // 尝试读出n个等号，不够就不是字符串结尾
                    for (int i = 0; i < n; i++) {
                        char c1 = Read();
                        cs.Add(c1);
                        if ('=' != c1) {
                            pass = false;
                            break;
                        }
                    }
                    if (pass) {
                        // end of long string
                        if (TestAndRead(']')) {
                            return builder.ToString();
                        } else {
                            builder.Append(cs);
                        }
                    }
                } else {
                    builder.Append(Read());
                }
            }
            return builder.ToString();
        }

        // 跳过注释，开头的--在/TokenStream/中已消耗
        private void SkipComment()
        {
            // 以[开头可能是长注释，匹配"^\[=**\["后一定是长注释
            // 换句话说，长注释时--加上长字符串
            // 从[开始ScanLongString，这个方法会递增行号
            // 实现上正则是做不到的，我今天忙了一天这件事了
            if (TestPeek('[')) {
                ScanLongString();
            }

            // [x] 先处理短注释
            // 短注释跳过这一行所有内容
            while (IsNotEndOfChunk && !IsNewlineChar(Peek())) {
                Position++;
            }
        }

        private bool IsNewlineChar(char c)
        {
            return c == '\r' || c == '\n';
        }

        #endregion 私有方法
    }
}