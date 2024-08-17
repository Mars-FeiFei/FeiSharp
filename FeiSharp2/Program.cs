// See https://aka.ms/new-console-template for more information
using FeiSharp2;

string code = "";
string sourceCode = "";
while (code.ToLower() != "run")
{
    code = Console.ReadLine();
    sourceCode += code;
}
Lexer lexer = new Lexer(sourceCode);

List<Token> tokens = new List<Token>();
Token token;
do
{
    token = lexer.NextToken();
    tokens.Add(token);
} while (token.Type != TokenType.EndOfFile);

Parser parser = new Parser(tokens);
try
{
    parser.ParseStatements();
}
catch (Exception ex)
{
    Console.WriteLine("Parsing error: " + ex.Message);
}






Console.WriteLine("Hello, World!");

return;

//string sourceCode = "";
//string code = "";
//while (code.ToUpper() != "RUN" )
//{
//    code = Console.ReadLine();
//    sourceCode += code;
//}

//Lexer lexer = new Lexer(sourceCode);

//List<Token> tokens = new List<Token>();
//Token token;
//do
//{
//    token = lexer.NextToken();
//    tokens.Add(token);
//} while (token.Type != TokenType.EndOfFile);

//Parser parser = new Parser(tokens);
//try
//{
//    PrintStmt stmt = parser.ParsePrintStatement();
//    // Output or process the parsed statement
//    Console.WriteLine("Parsed successfully. Evaluating result...");
//    EvaluatePrintStmt(stmt);
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Parsing error: " + ex.Message);
//}



//// Evaluate and print the result of PrintStmt
//static void EvaluatePrintStmt(PrintStmt stmt)
//{
//    int result = EvaluateExpression(stmt.Expression);
//    Console.WriteLine(result);
//}

//// Simple expression evaluator
//static int EvaluateExpression(Expr expr)
//{
//    switch (expr)
//    {
//        case NumberExpr numExpr:
//            return numExpr.Value;

//        case BinaryExpr binExpr:
//            int left = EvaluateExpression(binExpr.Left);
//            int right = EvaluateExpression(binExpr.Right);
//            return binExpr.Operator switch
//            {
//                "+" => left + right,
//                "-" => left - right,
//                _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
//            };

//        default:
//            throw new Exception("Unexpected expression type");
//    }
//}


