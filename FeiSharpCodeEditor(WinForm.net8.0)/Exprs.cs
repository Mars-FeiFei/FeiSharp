using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpStudio
{
    public abstract class Expr { }
    public class VarExpr : Expr
    {
        public string Name { get; set; }
        public VarExpr(string name)
        {
            Name = name;
        }
    }
    public class ValueExpr : Expr
    {
        public object Value { get; }
        public ValueExpr(object value) { Value = value; }
    }

    public class StringExpr : Expr
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

}
