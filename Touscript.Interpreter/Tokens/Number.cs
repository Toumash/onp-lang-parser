namespace Touscript.Interpreter
{
    public class Number : Token
    {
        public int Value { get; private set; }
        public Number(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Number;
            if (p == null)
            {
                return false;
            }
            return Value == p.Value;
        }
    }
}
