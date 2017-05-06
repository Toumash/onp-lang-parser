using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Touscript.Interpreter.TokenList;

namespace Touscript.Interpreter
{
    public class Interpreter
    {
        public string Input { get; private set; }

        public Interpreter(string input)
        {
            Input = input.StripWhiteSpace();
        }

        public IEnumerable<Token> Interpret()
        {
            var list = new List<Token>();


            Dictionary<string, int> variables = new Dictionary<string, int>();
            int i = 0;
            Action advance = () => i++;

            while (i < Input.Length)
            {
                var c = Input[i];
                advance();
                if (c == '@')
                {
                    if (Array.IndexOf(new char[] { 'c', 's', 's', 'f' }, c) != -1) { }

                }
                else if (char.IsLetter(c))
                {
                    var variableName = new String(Input.Substring(i).TakeWhile(char.IsLetterOrDigit).ToArray());
                    yield return new Variable(variableName);
                }
            }
        }



        public void eat(char c, int index,string messageOnError = "")
        {
            if (index >= Input.Length)
            {
                throw new Exception();
            }
        }
    }
}
