namespace Touscript.Core
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

        public override string ToString()
        {
            return $"Token({Type},{Value})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Token))
                return false;

            var token = obj as Token;
            return Type == token.Type && Value.Equals(token.Value);
        }
    }
}
