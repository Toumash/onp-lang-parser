using System;

namespace Touscript.Interpreter
{
    public abstract class Token
    {
        public string OriginalString { get; set; }

        public Token()
        {
        }
    }
}
