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
return;
