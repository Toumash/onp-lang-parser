using System;
using System.Collections.Generic;
using System.Text;
using static Touscript.Core.TokenTypes;

namespace Touscript.Core
{
    public class Interpreter
    {
        public Token CurrentToken { get; private set; }
        public Lexer Lexer { get; }
        public Dictionary<string, int> Variables { get; }

        public Interpreter(Lexer lexer)
        {
            Lexer = lexer;
            CurrentToken = lexer.GetNextToken();
            Variables = new Dictionary<string, int>();
        }

        public void Interpret()
        {
            while (CurrentToken.Type != EOF)
            {
                Main();
            }
        }

        public void DumpVariables()
        {
            foreach (var variable in Variables)
            {
                Console.WriteLine($"{variable.Key} = {variable.Value}");
            }
        }

        /// <summary>
        /// factor : NUMBER | LPAREN expre RPAREN | VARIABLE
        /// </summary>
        public int Factor()
        {
            var token = CurrentToken;
            if (token.Type == NUMBER)
            {
                Eat(NUMBER);
                return (int)token.Value;
            }
            else if (token.Type == VARIABLE)
            {
                Eat(VARIABLE);
                return (int)Value(token.Value.ToString());
            }
            else if (token.Type == LPAREN)
            {
                Eat(LPAREN);
                var result = Expr();
                Eat(RPAREN);
                return result;
            }
            return Error();
        }

        private int Value(string variableName)
        {
            if (Variables.ContainsKey(variableName))
            {
                return Variables[variableName];
            }
            return 0;
        }

        public int Error()
        {
            throw new Exception("Error parsing input");
        }

        /// <summary>
        /// main        : (VARIABLE assignmentOperator)? expr
        /// </summary>
        public int Main()
        {
            if (CurrentToken.Type == VARIABLE)
            {
                var token = CurrentToken;
                Eat(VARIABLE);
                var newValue = AssignmentOperator();
                Variables[(string)token.Value] = newValue;
                return newValue;
            }
            return Expr();
        }

        public int AssignmentOperator()
        {
            if (CurrentToken.Type == ASSIGNMENT)
            {
                Eat(ASSIGNMENT);
                return Expr();
            }
            return Error();
        }

        /// <summary>
        /// main        : (VARIABLE assignmentOperator)? expr
        /// expr        : term ((PLUS | MINUS) term)*
        /// term        : factor((MUL | DIV) factor)*
        /// factor      : NUMBER | LPAREN expre RPAREN | VARIABLE
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
