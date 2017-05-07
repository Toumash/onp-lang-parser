using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core
{
    class AST
    {
        public AST Left { get; set; }
        public AST Right { get; set; }
        public Token Token { get; set; }
        public Token Operation { get; set; }
    }
}
