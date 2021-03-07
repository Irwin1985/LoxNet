using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public abstract class Expr
    {
        public abstract R Accept<R>(IVisitor<R> visitor);
    }
}
