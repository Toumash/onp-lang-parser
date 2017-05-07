using System;

namespace Touscript.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
                Console.Write("script> ");
                var text = Console.ReadLine();
                text = text.StripWhiteSpace();
                if (string.IsNullOrEmpty(text))
                    continue;
                var lexer = new Lexer(text);
                var interpreter = new Interpreter(lexer);
                var result = interpreter.Expr();
                Console.WriteLine(result);
            }
        }
    }
}