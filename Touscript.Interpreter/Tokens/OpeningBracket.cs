using System;

namespace Touscript.Interpreter
{
    public class OpeningBracket : Operator
    {
        public override int Priority { get; } = 99;
        public override int Evaluate(Number left, Number right)
        {
            throw new NotImplementedException();
        }
    }
}
