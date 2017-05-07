using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Touscript.Core.TokenTypes;

namespace Touscript.Core
{
    public class Lexer
    {
        public string Input { get; private set; }
        public Token CurrentToken { get; private set; }
        public char CurrentChar { get; private set; }
        public int Position { get; private set; }

        public Lexer(string input)
        {
            Input = input.StripWhiteSpace();
            CurrentToken = null;
            Position = 0;
            CurrentChar = Input[Position];
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

        public string Variable()
        {
            var result = new StringBuilder();

            result.Append(CurrentChar);
            Advance();
            while (!Eof() && char.IsLetterOrDigit(CurrentChar))
            {
                result.Append(CurrentChar);
                Advance();
            }
            return result.ToString();
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
                if (CurrentChar == '*')
                {
                    Advance();
                    return new Token(MUL, '*');
                }
                if (CurrentChar == '/')
                {
                    Advance();
                    return new Token(DIV, '/');
                }
                if (CurrentChar == '(')
                {
                    Advance();
                    return new Token(LPAREN, '(');
                }
                if (CurrentChar == ')')
                {
                    Advance();
                    return new Token(RPAREN, ')');
                }
                if (char.IsLetter(CurrentChar))
                {
                    return new Token(VAR, Variable());
                }
                if (CurrentChar == '=')
                {
                    Advance();
                    return new Token(ASSIGN, '=');
                }
                return new Token(EOF, null);
            }
            return new Token(EOF, null);
        }
    }
}
