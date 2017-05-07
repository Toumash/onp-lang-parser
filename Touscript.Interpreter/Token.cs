namespace Touscript.Interpreter
{
    public class Token
    {
        public object Value { get; private set; }
        public string Type { get; private set; }

        public Token(string type, object value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
