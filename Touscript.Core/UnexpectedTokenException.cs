using System;
using System.Runtime.Serialization;

namespace Touscript.Core
{
    [Serializable]
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException() { }
        public UnexpectedTokenException(string message) : base(message) { }
        public UnexpectedTokenException(string message, Exception inner) : base(message, inner) { }
        protected UnexpectedTokenException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}