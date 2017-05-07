using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core.Node
{
    class BinaryOperation : AST
    {
        public BinaryOperation(AST left, Token op, AST right)
        {
            this.Left = left;
            this.Token = op;
            this.Operation = op;
            this.Right = right;
        }
    }
}
