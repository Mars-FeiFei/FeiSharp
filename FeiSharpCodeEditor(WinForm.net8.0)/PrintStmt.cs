using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpCodeEditor_WinForm.net8._0_
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
