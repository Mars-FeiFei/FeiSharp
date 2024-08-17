using FeiSharp2;
string sourceCode = "";
string code = "";
while (!code.Equals("run", StringComparison.CurrentCultureIgnoreCase))
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
    PrintStmt stmt = parser.ParsePrintStatement();
    EvaluatePrintStmt(stmt);
}
catch (Exception ex)
{
    Console.WriteLine("Parsing error: " + ex.Message);
}



// Evaluate and print the result of PrintStmt
static void EvaluatePrintStmt(PrintStmt stmt)
{
    int result = EvaluateExpression(stmt.Expression);
    Console.WriteLine(result);
}

// Simple expression evaluator
static int EvaluateExpression(Expr expr)
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
                "*" => left * right,
                "/" => left / right,
                _ => throw new Exception("Unexpected operator: " + binExpr.Operator)
            };

        default:
            throw new Exception("Unexpected expression type");
    }
}