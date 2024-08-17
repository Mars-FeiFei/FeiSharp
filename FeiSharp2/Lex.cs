using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharp2
{

    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _current;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _current = 0;
        }

        // Parse a print statement
        public PrintStmt ParsePrintStatement()
        {
            if (!MatchKeyword("print")) throw new Exception("Expected 'print' keyword");
            Expr expr = ParseExpression();
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            return new PrintStmt(expr);
        }

        // Parse an expression (supports simple binary operations)
        private Expr ParseExpression()
        {
            Expr expr = ParsePrimary();
            while (MatchOperator("+", "-","*","/"))
            {
                string op = Previous().Value;
                Expr right = ParsePrimary();
                expr = new BinaryExpr(expr, op, right);
            }
            return expr;
        }

        // Parse primary expressions (numbers or variable names)
        private Expr ParsePrimary()
        {
            if (MatchToken(TokenType.Number))
            {
                return new NumberExpr(int.Parse(Previous().Value));
            }

            if (MatchToken(TokenType.Identifier))
            {
                return new VariableExpr(Previous().Value);
            }

            if (MatchPunctuation("("))
            {
                Expr expr = ParseExpression();
                if (!MatchPunctuation(")"))
                {
                    throw new Exception("Expected ')' after expression");
                }
                return expr;
            }

            throw new Exception("Unexpected token: " + (IsAtEnd() ? "End of input" : Peek().Value));
        }

        // Match one or more token types
        private bool MatchToken(params TokenType[] types)
        {
            foreach (var type in types)
            {
                if (Check(type))
                {
                    Advance();
                    return true;
                }
            }
            return false;
        }

        // Match specific keywords
        private bool MatchKeyword(string keyword)
        {
            if (Check(TokenType.Keyword) && Peek().Value == keyword)
            {
                Advance();
                return true;
            }
            return false;
        }

        // Match specific punctuation
        private bool MatchPunctuation(string punctuation)
        {
            if (Check(TokenType.Punctuation) && Peek().Value == punctuation)
            {
                Advance();
                return true;
            }
            return false;
        }

        // Match specific operators
        private bool MatchOperator(params string[] operators)
        {
            if (Check(TokenType.Operator) && operators.Contains(Peek().Value))
            {
                Advance();
                return true;
            }
            return false;
        }

        // Check if the current token is of the specified type
        private bool Check(TokenType type)
        {
            // Directly check if _current is within bounds
            return !IsAtEnd() && Peek().Type == type;
        }

        // Move to the next token
        private Token Advance()
        {
            if (!IsAtEnd()) _current++;
            return Previous(); // Safe to call Previous() because _current was not -1
        }

        // Check if the end of the token list has been reached
        private bool IsAtEnd()
        {
            return _current >= _tokens.Count;
        }

        // Peek at the current token
        private Token Peek()
        {
            if (IsAtEnd()) throw new InvalidOperationException("No more tokens available.");
            return _tokens[_current];
        }

        // Get the previous token (useful after advancing)
        private Token Previous()
        {
            if (_current == 0) throw new InvalidOperationException("No previous token available.");
            return _tokens[_current - 1];
        }
    }



    // Example TokenType enum
    public enum TokenType
    {
        Keyword,
        Identifier,
        Number,
        Punctuation,
        Operator,
        EndOfFile
    }

    // Example Token class
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

    // Example PrintStmt class
    public class PrintStmt
    {
        public Expr Expression { get; }
        public PrintStmt(Expr expression)
        {
            Expression = expression;
        }
    }

    // Example Expr class hierarchy
    public abstract class Expr { }
    public class NumberExpr : Expr
    {
        public int Value { get; }
        public NumberExpr(int value) { Value = value; }
    }
    public class VariableExpr : Expr
    {
        public string Name { get; }
        public VariableExpr(string name) { Name = name; }
    }
    public class BinaryExpr : Expr
    {
        public Expr Left { get; }
        public string Operator { get; }
        public Expr Right { get; }
        public BinaryExpr(Expr left, string op, Expr right)
        {
            Left = left;
            Operator = op;
            Right = right;
        }
    }

    // Example of Lexer (simple implementation)
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
                if (current == '/') { _index++; return new Token(TokenType.Operator, "/"); }
                if (current == '*') { _index++; return new Token(TokenType.Operator, "*"); }
                if (current == '-') { _index++; return new Token(TokenType.Operator, "-"); }
                if (current == '+') { _index++; return new Token(TokenType.Operator, "+"); }
                if (current == ';') { _index++; return new Token(TokenType.Punctuation, ";"); }
                if (current == '(') { _index++; return new Token(TokenType.Punctuation, "("); }
                if (current == ')') { _index++; return new Token(TokenType.Punctuation, ")"); }

                if (char.IsDigit(current))
                {
                    int start = _index;
                    while (_index < _source.Length && char.IsDigit(_source[_index])) _index++;
                    return new Token(TokenType.Number, _source.Substring(start, _index - start));
                }

                if (char.IsLetter(current))
                {
                    int start = _index;
                    while (_index < _source.Length && char.IsLetter(_source[_index])) _index++;
                    string value = _source.Substring(start, _index - start);
                    if (value == "print") return new Token(TokenType.Keyword, "print");
                    return new Token(TokenType.Identifier, value);
                }

                throw new Exception("Unexpected character: " + current);
            }

            return new Token(TokenType.EndOfFile, "");
        }
    }
}