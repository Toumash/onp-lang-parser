using System;
using Touscript.Interpreter;

namespace Touscript.Interpreter
{
    public class Variable : Token
    {
        public string Name { get; set; }

        public Variable(string variableName)
        {
            Name = variableName.StripWhiteSpace();
        }
    }
}
