using FeiSharpCodeEditor_WinForm.net8._0_;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public class Lexer
    {
        private readonly string _source;
        private int _index;

        public Lexer(string source)
        {
            _source = source;
            _index = 0;
        }

        public Token NextToken()
        {
            while (_index < _source.Length)
            {
                char current = _source[_index];
                if (char.IsWhiteSpace(current))
                {
                    _index++;
                    continue;
                }
                if (current == ']') { _index++; return new Token(TokenType.Punctuation, "]"); }
                if (current == '[') { _index++; return new Token(TokenType.Punctuation, "["); }
                if (current == '!') { _index++; return new Token(TokenType.Operator, "!"); }
                if (current == '}') { _index++; return new Token(TokenType.Punctuation, "}"); }
                if (current == '{') { _index++; return new Token(TokenType.Punctuation, "{"); }
                if (current == '<') { _index++; return new Token(TokenType.Operator, "<"); }
                if (current == '>') { _index++; return new Token(TokenType.Operator, ">"); }
                if (current == '=') { _index++; return new Token(TokenType.Operator, "="); }
                if (current == '|') { _index++; return new Token(TokenType.Operator, "|"); }
                if (current == '^') { _index++; return new Token(TokenType.Operator, "^"); }
                if (current == '/') { _index++; return new Token(TokenType.Operator, "/"); }
                if (current == '*') { _index++; return new Token(TokenType.Operator, "*"); }
                if (current == '-') { _index++; return new Token(TokenType.Operator, "-"); }
                if (current == ',') { _index++; return new Token(TokenType.Punctuation, ","); }
                if (current == '+') { _index++; return new Token(TokenType.Operator, "+"); }
                if (current == '-') { _index++; return new Token(TokenType.Operator, "-"); }
                if (current == '=') { _index++; return new Token(TokenType.Operator, "="); } // Added for '='
                if (current == ';') { _index++; return new Token(TokenType.Punctuation, ";"); }
                if (current == '(') { _index++; return new Token(TokenType.Punctuation, "("); }
                if (current == ')') { _index++; return new Token(TokenType.Punctuation, ")"); }
                if (current == '"')
                {
                    int start = ++_index;

                    while (_index < _source.Length && _source[_index] != '"')
                    {
                        _index++;
                    }
                    return new Token(TokenType.String, _source[start.._index++]);
                }

                if (char.IsDigit(current))
                {
                    int start = _index;
                    while (_index < _source.Length && (char.IsDigit(_source[_index]) || _source[_index] == '.')) _index++;
                    return new Token(TokenType.Number, _source[start.._index]);
                }

                if (char.IsLetter(current))
                {
                    int start = _index;
                    while (_index < _source.Length && char.IsLetter(_source[_index])) _index++;
                    string value = _source.Substring(start, _index - start);
                    if (value == "var") return new Token(TokenType.Keyword, "var");
                    else if (value == "gethtml") return new Token(TokenType.Keyword, "gethtml");
                    else if (value == "print") return new Token(TokenType.Keyword, "print");
                    else if (value == "init") return new Token(TokenType.Keyword, "init");
                    else if (value == "set") return new Token(TokenType.Keyword, "set");
                    else if (value == "import") return new Token(TokenType.Keyword, "import");
                    else if (value == "export") return new Token(TokenType.Keyword, "export");
                    else if (value == "start") return new Token(TokenType.Keyword, "start");
                    else if (value == "stop") return new Token(TokenType.Keyword, "stop");
                    else if (value == "wait") return new Token(TokenType.Keyword, "wait");
                    else if (value == "watchstart") return new Token(TokenType.Keyword, "watchstart");
                    else if (value == "watchend") return new Token(TokenType.Keyword, "watchend");
                    else if (value == "abe") return new Token(TokenType.Keyword, "abe");
                    else if (value == "Double") return new Token(TokenType.Type, "Double");
                    else if (value == "helper") return new Token(TokenType.Keyword, "helper");
                    else if (value == "true") return new Token(TokenType.Keyword, "true");
                    else if (value == "false") return new Token(TokenType.Keyword, "false");
                    else if (value == "if") return new Token(TokenType.Keyword, "if");
                    else if (value == "while") return new Token(TokenType.Keyword, "while");
                    else if (value == "dowhile") return new Token(TokenType.Keyword, "dowhile");
                    else if (value == "throw") return new Token(TokenType.Keyword, "throw");
                    else if (value == "return") return new Token(TokenType.Keyword, "return");
                    else if (value == "getVarsFromJsonFilePath") return new Token(TokenType.Keyword, "getVarsFromJsonFilePath");
                    else if (value == "func") { 
                        return new Token(TokenType.Keyword, "func"); 
                    }
                    else return new Token(TokenType.Identifier, value);
                }
                throw new Exception("Unexpected character: " + current);
            }
            return new Token(TokenType.EndOfFile, "");
        }
    }
}
