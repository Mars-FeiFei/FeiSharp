using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceCode = "var x = 5; print(x);";
            Lexer lexer = new Lexer(sourceCode);

            List<Token> tokens = new List<Token>();
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new Parser(tokens);
            PrintStmt stmt = parser.ParsePrintStatement();

            Interpreter interpreter = new Interpreter();
            interpreter.Interpret(stmt);
        }
    }




}
