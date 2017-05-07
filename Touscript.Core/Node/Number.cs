using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core.Node
{
    class Number : AST
    {
        public int Value { get; set; }

        public Number(Token token, int value)
        {
            this.Value = value;
        }
    }
}
