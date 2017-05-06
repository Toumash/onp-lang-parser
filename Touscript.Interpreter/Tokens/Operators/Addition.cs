namespace Touscript.Interpreter.Operators
{
    public class Addition : Operator
    {
        public override int  Priority { get; } = 6;
        public override int Evaluate(Number left, Number right)
        {
            return left.Value + right.Value;
        }
    }
}
