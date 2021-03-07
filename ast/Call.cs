using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Call : Expr
    {
        public readonly Expr callee;
        public readonly Token paren;
        public readonly List<Expr> arguments;
        public Call(Expr callee, Token paren, List<Expr> arguments)
        {
            this.callee = callee;
            this.paren = paren;
            this.arguments = arguments;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            //return visitor.VisitCallExpr(this);
            throw new NotImplementedException();
        }
    }
}
