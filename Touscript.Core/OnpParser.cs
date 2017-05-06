using System.Collections.Generic;
using Touscript.Interpreter;

namespace Touscript.Core
{
    public class OnpParser
    {
        public int Evaluate(List<Token> tokens)
        {
            var stos = new Stack<Token>();

            foreach (var token in tokens)
            {
                if (!(token is Operator))
                {
                    stos.Push(token);
                }
                else
                {
                    var op1 = stos.Pop() as Number;
                    var op2 = stos.Pop() as Number;
                    var OperationResult = (token as Operator).Evaluate(op1, op2);
                    stos.Push(new Number(OperationResult));
                }
            }
            var result = stos.Pop();
            return (result as Number).Value;
        }
    }
}
