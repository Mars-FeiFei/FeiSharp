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
        private readonly Dictionary<string, int> _variables = new();

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _current = 0;
        }

        // Parse statements (variable declarations and print statements)
        public void ParseStatements()
        {
            while (!IsAtEnd() && Peek().Type == TokenType.Keyword)
            {
                if (MatchKeyword("var"))
                {
                    ParseVariableDeclaration();
                }
                else if (MatchKeyword("print"))
                {
                    PrintStmt printStmt = ParsePrintStatement();
                    EvaluatePrintStmt(printStmt);
                }
            }
        }

        private void ParseVariableDeclaration()
        {
            // Match the variable name
            if (!MatchToken(TokenType.Identifier, out string varName))
            {
                throw new Exception("Expected variable name");
            }

            // Match the '=' token
            if (!MatchToken(TokenType.Operator, out string op) || op != "=")
            {
                throw new Exception("Expected '=' after variable name");
            }

            // Parse the expression on the right-hand side
            Expr expr = ParseExpression();

            // Ensure the statement ends with a semicolon
            if (!MatchPunctuation(";"))
            {
                throw new Exception("Expected ';' after variable declaration");
            }

            // Evaluate the expression and store the result
            int value = EvaluateExpression(expr);
            _variables[varName] = value;
        }


        // Parse a print statement
        private PrintStmt ParsePrintStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = ParseExpression();
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            return new PrintStmt(expr);
        }

        private Expr ParseExpression()
        {
            Expr expr = ParsePrimary();
            while (MatchOperator("+", "-"))
            {
                string op = Previous().Value;
                Expr right = ParsePrimary();
                expr = new BinaryExpr(expr, op, right);
            }
            return expr;
        }

        private Expr ParsePrimary()
        {
            if (MatchToken(TokenType.Number))
            {
                return new NumberExpr(int.Parse(Previous().Value));
            }

            if (MatchToken(TokenType.Identifier))
            {
                string varName = Previous().Value;
                if (_variables.TryGetValue(varName, out int value))
                {
                    return new NumberExpr(value);
                }
                throw new Exception($"Undefined variable: {varName}");
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

        private bool MatchToken(TokenType type, out string value)
        {
            if (Check(type))
            {
                value = Peek().Value;
                Advance();
                return true;
            }
            value = null;
            return false;
        }


        private bool MatchKeyword(string keyword)
        {
            if (Check(TokenType.Keyword) && Peek().Value == keyword)
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool MatchPunctuation(string punctuation)
        {
            if (Check(TokenType.Punctuation) && Peek().Value == punctuation)
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool MatchOperator(params string[] operators)
        {
            if (Check(TokenType.Operator) && operators.Contains(Peek().Value))
            {
                Advance();
                return true;
            }
            return false;
        }

        private bool MatchIdentifier(out string identifier)
        {
            if (Check(TokenType.Identifier))
            {
                identifier = Peek().Value;
                Advance();
                return true;
            }
            identifier = null;
            return false;
        }

        private bool Check(TokenType type)
        {
            return !IsAtEnd() && Peek().Type == type;
        }

        private Token Advance()
        {
            if (!IsAtEnd()) _current++;
            return Previous();
        }

        private bool IsAtEnd()
        {
            return _current >= _tokens.Count;
        }

        private Token Peek()
        {
            if (IsAtEnd()) throw new InvalidOperationException("No more tokens available.");
            return _tokens[_current];
        }

        private Token Previous()
        {
            if (_current == 0) throw new InvalidOperationException("No previous token available.");
            return _tokens[_current - 1];
        }

        private void EvaluatePrintStmt(PrintStmt stmt)
        {
            int result = EvaluateExpression(stmt.Expression);
            Console.WriteLine(result);
        }

        private int EvaluateExpression(Expr expr)
        {
            switch (expr)
            {
                case NumberExpr numExpr:
                    return numExpr.Value;

                case BinaryExpr binExpr:
                    int left = EvaluateExpression(binExpr.Left);
                    int right = EvaluateExpression(binExpr.Right);
                    return binExpr.Operator switch
                    {
                        "+" => left + right,
                        "-" => left - right,
                        _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
                    };

                default:
                    throw new Exception("Unexpected expression type");
            }
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

                if (current == '+') { _index++; return new Token(TokenType.Operator, "+"); }
                if (current == '-') { _index++; return new Token(TokenType.Operator, "-"); }
                if (current == '=') { _index++; return new Token(TokenType.Operator, "="); } // Added for '='
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
                    if (value == "var") return new Token(TokenType.Keyword, "var");
                    else if (value == "print") return new Token(TokenType.Keyword, "print");
                    else return new Token(TokenType.Identifier, value);
                }

                throw new Exception("Unexpected character: " + current);
            }

            return new Token(TokenType.EndOfFile, "");
        }
    }

}
