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



        public int Factor()
        {
            var token = CurrentToken;
            Eat(NUMBER);
            return (int)token.Value;
        }

        public void Error()
        {
            throw new Exception("Error parsing input");
        }

        /// <summary>
        ///  expr -> INTEGER PLUS INTEGER
        /// </summary>
        /// <returns></returns>
        public int Expr()
        {
            var result = Factor();

            while (CurrentToken.Type.In(MUL, DIV))
            {
                var token = CurrentToken;
                if (token.Type == MUL)
                {
                    Eat(MUL);
                    result = result * Factor();
                }
                else if (token.Type == DIV)
                {
                    Eat(DIV);
                    result = result / Factor();
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
