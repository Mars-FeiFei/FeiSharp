using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeiSharp2
{
    public class VarExpr : Expr
    {
        public string Name { get; set; }
        public VarExpr(string name)
        {
            Name = name;
        }
    }
    
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _current;
        private readonly Dictionary<string, object> _variables = new();

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
                else if (MatchKeyword("init"))
                {
                    ParseInitStatement();
                }
                else if (MatchKeyword("set"))
                {
                    ParseSetStatement();
                }
            }
        }
        private void ParseSetStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = GetVar();
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
            string name = EvaluateExpression(ParseExpression()).ToString();
            Expr expr2 = new VarExpr(name);
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            _variables[((VarExpr)expr).Name] = ((VarExpr)expr2).Name;
        }
        private void ParseInitStatement()
        {
            if (!MatchPunctuation("(")) throw new Exception("Expected '('");
            Expr expr = GetVar();
            if (!MatchPunctuation(",")) throw new Exception("Expected ','");
             Expr expr2 = GetVar();
            if (!MatchPunctuation(")")) throw new Exception("Expected ')'");
            if (!MatchPunctuation(";")) throw new Exception("Expected ';'");
            _variables.Add(((VarExpr)expr).Name,InitValue(((VarExpr)expr2).Name));
        }
        private object InitValue(string type)
        {
                Type t = Type.GetType("System."+type);
                return Activator.CreateInstance(t);
        }
        // 泛型方法，返回类型 T 的默认值
        T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        private Expr GetVar()
        {
                if (MatchToken(TokenType.Identifier))
                {
                        return new VarExpr(Previous().Value);
                }
                return null;
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
            object value = EvaluateExpression(expr);
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
                return new ValueExpr(int.Parse(Previous().Value));
            }

            if(MatchToken(TokenType.String))
            {
                return new StringExpr(Previous().Value);
            }

            if (MatchToken(TokenType.Identifier))
            {
                string varName = Previous().Value;
                if (_variables.TryGetValue(varName, out object value))
                {
                    return new ValueExpr(value);
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
        private bool PreviousCheck(TokenType type)
        {
            return !IsAtEnd() && Previous().Type == type;
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
            Console.WriteLine(EvaluateExpression(stmt.Expression));
        }
        private object EvaluateExpression(Expr expr)
        {
            switch (expr)
            {
                case ValueExpr numExpr:
                    return numExpr.Value;

                case BinaryExpr binExpr:
                    object left = EvaluateExpression(binExpr.Left);
                    object right = EvaluateExpression(binExpr.Right);
                    if (left is string && right is string)
                    {
                        return binExpr.Operator switch
                        {
                            "+" => (string)left + (string)right,
                            "-" => Regex.Replace((string)left, Regex.Escape((string)right), ""),
                            _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
                        };
                    }
                    else if (right is int && left is int)
                    {
                        return binExpr.Operator switch
                        {
                            "+" => (int)left + (int)right,
                            "-" => (int)left - (int)right,
                            _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
                        };
                    }
                    return new object();
                case StringExpr stringExpr:
                    return stringExpr.Value;
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
        String,
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
    public class ValueExpr : Expr
    {
        public object Value { get; }
        public ValueExpr(object value) { Value = value; }
    }

    public class StringExpr: Expr
    {
        public string Value { get; }

        public StringExpr(string value) { Value = value; }
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
                    while (_index < _source.Length && char.IsDigit(_source[_index])) _index++;
                    return new Token(TokenType.Number, _source[start.._index]);
                }

                if (char.IsLetter(current))
                {
                    int start = _index;
                    while (_index < _source.Length && char.IsLetter(_source[_index])) _index++;
                    string value = _source.Substring(start, _index - start);
                    if (value == "var") return new Token(TokenType.Keyword, "var");
                    else if (value == "print") return new Token(TokenType.Keyword, "print");
                    else if (value == "init") return new Token(TokenType.Keyword,"init");
                    else if (value == "set") return new Token(TokenType.Keyword,"set");
                    else return new Token(TokenType.Identifier, value);
                }

                throw new Exception("Unexpected character: " + current);
            }

            return new Token(TokenType.EndOfFile, "");
        }
    }

}
