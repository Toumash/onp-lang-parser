namespace Touscript.Interpreter.Operators
{
    public class Modulo : Operator
    {
        public override int Priority { get; } = 7;
        public override int Evaluate(Number left, Number right)
        {
            return left.Value % right.Value;
        }
    }
}
