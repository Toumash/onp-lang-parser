using System.Collections.Generic;
using System.Linq;

namespace Touscript.Core
{
    public class OnpConverter
    {
        //public List<Token> ConvertToONP(List<Token> normalNotation)
        //{
        //    var stack = new Stack<Token>();
        //    var onp = new List<Token>();

        //    while (normalNotation.Any())
        //    {
        //        var token = normalNotation[0];
        //        normalNotation.RemoveAt(0);

        //        if (!(token is Operator))
        //        {
        //            onp.Add(token);
        //        }
        //        else if (token is OpeningBracket)
        //        {
        //            stack.Push(token);
        //        }
        //        else if (token is ClosingBracket)
        //        {
        //            while (stack.Any())
        //            {
        //                var tok = stack.Pop();
        //                if (tok is OpeningBracket)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    onp.Add(tok);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var priority = (token as Operator).Priority;
        //            while (stack.Any())
        //            {
        //                var top = stack.Pop();
        //                if (top is OpeningBracket || (top as Operator).Priority < priority)
        //                {
        //                    stack.Push(top);
        //                    break;
        //                }
        //                onp.Add(top);
        //            }
        //            stack.Push(token);
        //        }
        //    }
        //    while (stack.Any())
        //    {
        //        var item = stack.Pop();
        //        onp.Add(item);
        //    }
        //    return onp;
        //}
    }
}
