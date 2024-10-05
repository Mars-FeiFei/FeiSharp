using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    // Example Token types
    public static class TokenTypes
    {
        public const string PrintKeyword = "print";
        public const string Semicolon = ";";
        public const string PlusOperator = "+";
        public const string NumberToken = "Number";
        public const string IdentifierToken = "Identifier";
    }

}
