using System;

namespace Touscript.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ChangeColorFor(() => Console.Write("? >> "), ConsoleColor.Cyan);
                    var text = Console.ReadLine();
                    text = text.StripWhiteSpace();
                    if (string.IsNullOrEmpty(text))
                        continue;
                    var lexer = new Lexer(text);
                    var interpreter = new Interpreter(lexer);
                    interpreter.Interpret();
                    ChangeColorFor(() => Console.WriteLine("VARs:"), ConsoleColor.Green);
                    ChangeColorFor(() => interpreter.DumpVariables(), ConsoleColor.Green);
                }
                catch (Exception e)
                {
                    var fg = Console.ForegroundColor;
                    var bg = Console.BackgroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ForegroundColor = fg;
                    Console.BackgroundColor = bg;
                }
            }
        }

        public static void ChangeColorFor(Action action, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;
            Console.ForegroundColor = foreground.HasValue ? foreground.Value : fg;
            Console.BackgroundColor = background.HasValue ? background.Value : bg;
            action();
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }
    }
}