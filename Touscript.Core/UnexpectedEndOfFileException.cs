using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core
{
    [Serializable]
    public class UnexpectedEndOfFileException : Exception
    {
        public string Code { get; private set; }
        public int Index { get; private set; }

        public UnexpectedEndOfFileException() { }
        public UnexpectedEndOfFileException(string message) : base(message) { }
        public UnexpectedEndOfFileException(string message, Exception inner) : base(message, inner) { }
        protected UnexpectedEndOfFileException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }

        public UnexpectedEndOfFileException(int index, string code)
        {
            this.Code = code;
            this.Index = index;
        }
    }
}
