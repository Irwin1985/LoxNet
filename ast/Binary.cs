using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Binary : Expr
    {
        public readonly Expr left;
        public readonly Token _operator;
        public readonly Expr right;
        public Binary(Expr left, Token _operator, Expr right)
        {
            this.left = left;
            this._operator = _operator;
            this.right = right;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitBinaryExpr(this);
        }

    }
}
