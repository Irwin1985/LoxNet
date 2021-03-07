using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Token
    {
        TokenType type;
        private readonly string lexeme;
        private readonly object literal;
        private readonly int line;

        public Token(TokenType type, string lexeme, object literal, int line)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.literal = literal;
            this.line = line;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", type, lexeme, literal);
        }


    }
}
