using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class Scanner
    {
        private readonly string source;
        private List<Token> tokens = new List<Token>();
        private int start = 0;
        private int current = 0;
        private int line = 1;
        private readonly Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>();

        public Scanner(string source)
        {
            this.source = source;
            keywords.Add("and", TokenType.AND);
            keywords.Add("class", TokenType.CLASS);
            keywords.Add("else", TokenType.ELSE);
            keywords.Add("false", TokenType.FALSE);
            keywords.Add("for", TokenType.FOR);
            keywords.Add("fun", TokenType.FUN);
            keywords.Add("if", TokenType.IF);
            keywords.Add("nil", TokenType.NIL);
            keywords.Add("or", TokenType.OR);
            keywords.Add("print", TokenType.PRINT);
            keywords.Add("return", TokenType.RETURN);
            keywords.Add("super", TokenType.SUPER);
            keywords.Add("this", TokenType.THIS);
            keywords.Add("true", TokenType.TRUE);
            keywords.Add("var", TokenType.VAR);
            keywords.Add("while", TokenType.WHILE);

        }
        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                // estamos al inicio del siguiente lexema.
                start = current;
                ScanToken();
            }
            tokens.Add(new Token(TokenType.EOF, "", null, line));
            return tokens;
        }
        private void ScanToken()
        {
            char c = Advance();
            switch (c)
            {
                case '(': AddToken(TokenType.LEFT_PAREN); break;
                case ')': AddToken(TokenType.RIGHT_PAREN); break;
                case '{': AddToken(TokenType.LEFT_BRACE); break;
                case '}': AddToken(TokenType.RIGHT_BRACE); break;
                case ',': AddToken(TokenType.COMMA); break;
                case '.': AddToken(TokenType.DOT); break;
                case '-': AddToken(TokenType.MINUS); break;
                case '+': AddToken(TokenType.PLUS); break;
                case ';': AddToken(TokenType.SEMICOLON); break;
                case '*': AddToken(TokenType.STAR); break;
                case '!':
                    AddToken(Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG);
                    break;
                case '=':
                    AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL);
                    break;
                case '<':
                    AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS);
                    break;
                case '>':
                    AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GRATER);
                    break;
                case '/':
                    if (Match('/'))
                    {
                        // un comentario simple llega hasta el final de la línea.
                        while (Peek() != '\n' && !IsAtEnd())
                        {
                            Advance();
                        }
                    } else
                    {
                        AddToken(TokenType.SLASH);
                    }
                    break;
                case ' ':
                case '\r':
                case '\t':
                    // Ignoramos espacios en blanco.
                    break;
                case '\n':
                    line++;
                    break;
                case '"':
                    String();
                    break;
                default:
                    if (IsDigit(c))
                    {
                        Number();
                    } else if (IsAlpha(c))
                    {
                        Identifier();
                    } else
                    {
                        LoxNet.Error(line, "Unexpected character.");
                    }
                    break;
            }

        }
        private void Identifier()
        {
            while (IsAlphaNumeric(Peek()))
            {
                Advance();
            }
            string text = source.Substring(start, current - start);
            if (!keywords.TryGetValue(text, out TokenType type))
            {
                type = TokenType.IDENTIFIER;
            }
            AddToken(type, text);
        }

        private void Number()
        {
            while (IsDigit(Peek()))
            {
                Advance();
            }
            // Revisamos la parte fraccional
            if (Peek() == '.' && IsDigit(PeekNext()))
            {
                Advance(); // Consumimos el '.'
                while (IsDigit(Peek()))
                {
                    Advance();
                }
            }
            AddToken(TokenType.NUMBER, Convert.ToDouble(source.Substring(start, current - start)));
        }
        private void String () {
            while (Peek() != '"' && !IsAtEnd())
            {
                if (Peek() == '\n')
                {
                    line++;
                }
                Advance();
            }
            // el '"' final
            Advance();

            // extraemos el string.
            string value = source.Substring(start + 1, current - 1);
            AddToken(TokenType.STRING, value);
        }
        /*
         * Match funciona como un Advance() condicionado, es decir, solo
         * consumimos el caracter actual si es el que el que buscamos.
         */
        private bool Match(char expected)
        {
            if (IsAtEnd()) return false;
            if (source[current] != expected) return false;

            current++;
            return true;
        }
        private char Peek()
        {
            if (IsAtEnd()) return '\0';
            return source[current];
        }
        private char PeekNext()
        {
            if (current + 1 >= source.Length)
            {
                return '\0';
            }
            return source[current + 1];
        }
        private bool IsAlpha(char c)
        {
            return (c >= 'a' && c <= 'z') ||
                (c >= 'A' && c <= 'Z') ||
                c == '_';
        }
        private bool IsAlphaNumeric(char c)
        {
            return IsAlpha(c) || IsDigit(c);
        }
        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        private bool IsAtEnd()
        {
            return current >= source.Length;
        }
        private char Advance()
        {
            return source[current++];
        }
        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }
        private void AddToken(TokenType type, object literal)
        {
            string text = source.Substring(start, current - start);
            tokens.Add(new Token(type, text, literal, line));
        }
    }
}
