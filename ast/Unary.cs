using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Unary : Expr
    {
        public readonly Token _operator;
        public readonly Expr right;
        public Unary(Token _operator, Expr right)
        {
            this._operator = _operator;
            this.right = right;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitUnaryExpr(this);
        }
    }
}
