using System;

namespace Touscript.Interpreter
{
    public class ClosingBracket : Operator
    {
        public override int Priority { get; } = 99;

        public override int Evaluate(Number left, Number right)
        {
            throw new NotImplementedException();
        }
    }
}
