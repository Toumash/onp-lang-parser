using System;
using System.Text;
using static Touscript.Core.TokenTypes;

namespace Touscript.Core
{
    public class Interpreter
    {
        public Token CurrentToken { get; private set; }
        public Lexer Lexer { get; }

        public Interpreter(Lexer lexer)
        {
            Lexer = lexer;
            CurrentToken = lexer.GetNextToken();
        }

        /// <summary>
        /// factor : NUMBER | LPAREN expr RPAREN
        /// </summary>
        public int Factor()
        {
            var token = CurrentToken;
            if (token.Type == NUMBER)
            {
                Eat(NUMBER);
                return (int)token.Value;
            }
            else if (token.Type == LPAREN)
            {
                Eat(LPAREN);
                var result = Expr();
                Eat(RPAREN);
                return result;
            }
            return -1;
        }

        public void Error()
        {
            throw new Exception("Error parsing input");
        }

        /// <summary>
        ///  expr   : term ((PLUS | MINUS) term)*
        /// term   : factor((MUL | DIV) factor)*
        /// factor : NUMBER
        /// </summary>
        public int Expr()
        {
            var result = Term();

            while (CurrentToken.Type.In(PLUS, MINUS))
            {
                var token = CurrentToken;
                if (token.Type == PLUS)
                {
                    Eat(PLUS);
                    result = result + Term();
                }
                else if (token.Type == MINUS)
                {
                    Eat(MINUS);
                    result = result - Term();
                }
            }
            return result;
        }

        /// <summary>
        /// term : factor ((MUL | DIV) factor)*
        /// </summary>
        public int Term()
        {
            var result = Factor();

            while (CurrentToken.Type.In(MUL, DIV))
            {
                var token = CurrentToken;
                if (token.Type == MUL)
                {
                    Eat(MUL);
                    result = result * Term();
                }
                else if (token.Type == DIV)
                {
                    Eat(DIV);
                    result = result / Term();
                }
            }
            return result;
        }

        public void Eat(string token_type)
        {
            if (CurrentToken.Type == token_type)
                CurrentToken = Lexer.GetNextToken();
            else
                Error();
        }
    }
}
