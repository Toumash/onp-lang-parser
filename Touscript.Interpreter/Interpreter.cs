using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public void Advance()
        {
            Position += 1;
            if (Position > Input.Length - 1)
            {
                CurrentChar = '\0';
            }
            else
            {
                CurrentChar = Input[Position];
            }
        }

        public void Factor()
        {
            Eat(NUMBER);
        }

        public void SkipWhitespace()
        {
            while (!Eof() && char.IsWhiteSpace(CurrentChar))
            {
                Advance();
            }
        }

        public int Integer()
        {
            var result = new StringBuilder();
            while (!Eof() && char.IsDigit(CurrentChar))
            {
                result.Append(CurrentChar);
                Advance();
            }
            return int.Parse(result.ToString());
        }

        public bool Eof()
        {
            return CurrentChar == '\0';
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

            while (!Eof())
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsDigit(CurrentChar))
                {
                    return new Token(NUMBER, Integer());
                }

                if (CurrentChar == '+')
                {
                    Advance();
                    return new Token(PLUS, '-');
                }
                if (CurrentChar == '-')
                {
                    Advance();
                    return new Token(MINUS, '-');
                }
            }
            return new Token(EOF, null);
        }


        /// <summary>
        ///  expr -> INTEGER PLUS INTEGER
        /// </summary>
        /// <returns></returns>
        public void Expr()
        {
            Factor();

            while (CurrentToken.Type.In(MUL, DIV))
            {
                var token = CurrentToken;
                if (token.Type == MUL)
                {
                    Eat(MUL);
                    Factor();
                }
                else if (token.Type == DIV)
                {
                    Eat(DIV);
                    Factor();
                }
            }
        }

        public void Eat(string token_type)
        {
            if (CurrentToken.Type == token_type)
                CurrentToken = GetNextToken();
            else
                Error();
        }

        public int Term()
        {
            var token = CurrentToken;
            Eat(NUMBER);
            return (int)token.Value;
        }
    }
}
