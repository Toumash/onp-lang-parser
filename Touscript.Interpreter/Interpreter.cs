using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Touscript.Interpreter;
using static Touscript.Interpreter.TokenTypes;

namespace Touscript.Interpreter
{
    public class Interpreter
    {
        public string Input { get; private set; }
        public Token CurrentToken { get; private set; }
        public char CurrentChar { get; private set; }
        public int Position { get; private set; }

        public Interpreter(string input)
        {
            Input = input.StripWhiteSpace();
            CurrentToken = null;
            Position = 0;
            CurrentChar = Input[Position];
        }

        public void Error()
        {
            throw new Exception("Error parsing input");
        }

        /// <summary>
        /// Lexical analyzer (also known as scanner or tokenizer)
        /// This method is responsible for breaking a sentence
        /// apart into tokens.One token at a time.
        /// </summary>
        /// <returns>Next Token from the <see cref="Input"/></returns>
        public Token GetNextToken()
        {
            var text = Input;

            // is self.pos index past the end of the self.text ?
            //if so, then return EOF token because there is no more
            // input left to convert into tokens
            if (Position > text.Length - 1)
                return new Token(EOF, null);

            // get a character at the position self.pos and decide
            // what token to create based on the single character
            CurrentChar = text[Position];
            Token token = null;
            if (char.IsDigit(CurrentChar))
            {
                token = new Token(NUMBER, int.Parse(CurrentChar + ""));
                Position += 1;
                return token;
            }

            if (CurrentChar == '+')
            {
                token = new Token(PLUS, CurrentChar);
                Position += 1;
                return token;
            }

            Error();
            return null;
        }

        /// <summary>
        ///  expr -> INTEGER PLUS INTEGER
        /// </summary>
        /// <returns></returns>
        public int expr()
        {
            CurrentToken = GetNextToken();

            // we expect the current token to be a single-digit integer
            var left = CurrentToken;
            eat(NUMBER);

            // we expect the current token to be a '+' token
            var op = CurrentToken;
            eat(PLUS);

            // we expect the current token to be a single-digit integer
            var right = CurrentToken;
            eat(NUMBER);
            // after the above call the self.current_token is set to
            // EOF token;

            // at this point INTEGER PLUS INTEGER sequence of tokens
            // has been successfully found and the method can just
            // return the result of adding two integers, thus
            // effectively interpreting client input
            var result = (int)left.Value + (int)right.Value;
            return result;
        }

        public void eat(string token_type)
        {
            if (CurrentToken.Type == token_type)
                CurrentToken = GetNextToken();
            else
                Error();
        }
    }
}
