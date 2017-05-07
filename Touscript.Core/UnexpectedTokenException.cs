using System;
using System.Runtime.Serialization;

namespace Touscript.Core
{
    [Serializable]
    public class UnexpectedTokenException : Exception
    {
        public string Code { get; private set; }
        public Token Token { get; private set; }
        public int Index { get; private set; }

        public UnexpectedTokenException() { }
        public UnexpectedTokenException(string message) : base(message) { }
        public UnexpectedTokenException(string message, Exception inner) : base(message, inner) { }
        protected UnexpectedTokenException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }

        public UnexpectedTokenException(int index, string code, Token token)
        {
            this.Code = code;
            this.Token = token;
            this.Index = index;
        }
    }
}