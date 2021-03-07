using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Grouping : Expr
    {
        public readonly Expr expression;
        public Grouping(Expr expression)
        {
            this.expression = expression;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            return visitor.VisitGroupingExpr(this);
        }
    }
}
