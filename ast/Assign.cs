using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Assign : Expr
    {
        public readonly Token name;
        public readonly Expr value;
        public Assign(Token name, Expr value)
        {
            this.name = name;
            this.value = value;
        }
        public override R Accept<R>(IVisitor<R> visitor)
        {
            //return visitor.VisitAssignExpr(this);
            throw new NotImplementedException();
        }
    }
}
