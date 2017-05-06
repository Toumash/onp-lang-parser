using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Interpreter.Tokens
{
    public class Equity : Operator
    {
        public override int Evaluate(Number left, Number right)
        {
            throw new NotImplementedException();
        }
    }
}
