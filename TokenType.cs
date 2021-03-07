using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public enum TokenType
    {
        // Tokens de un caracter de longitud.
        LEFT_PAREN, RIGHT_PAREN, LEFT_BRACE, RIGHT_BRACE,
        COMMA, DOT, MINUS, PLUS, SEMICOLON, SLASH, STAR,

        // Tokens de uno o más caracteres de longitud.
        BANG, BANG_EQUAL,
        EQUAL, EQUAL_EQUAL,
        GRATER, GREATER_EQUAL,
        LESS, LESS_EQUAL,

        // Literales
        IDENTIFIER, STRING, NUMBER,

        // Palabras reservadas
        AND, CLASS, ELSE, FALSE, FUN, FOR, IF, NIL, OR,
        PRINT, RETURN, SUPER, THIS, TRUE, VAR, WHILE,

        EOF
    }
}
