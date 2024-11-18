namespace FeiSharpStudio
{
    public class PrintStmt
    {
        public Expr Expression { get; }
        public PrintStmt(Expr expression)
        {
            Expression = expression;
        }
    }
}
