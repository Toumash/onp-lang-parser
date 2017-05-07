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
                    if (string.IsNullOrEmpty(text))
                        continue;
                    var lexer = new Lexer(text);
                    var interpreter = new Interpreter(lexer);
                    interpreter.Interpret();
                    ChangeColorFor(() => Console.WriteLine("VARs:"), ConsoleColor.Green);
                    ChangeColorFor(() => interpreter.DumpVariables(), ConsoleColor.Green);
                }
                catch (UnexpectedEndOfFileException e)
                {
                    ChangeColorFor(() =>
                    {
                        Console.WriteLine($"Unexpected end of file. Character {e.Index}");
                        Console.WriteLine($"{e.Code.Substring((e.Index - 10) >= 0 ? e.Index - 10 : 0, e.Index)}");
                    }, ConsoleColor.Red);
                }
                catch (UnexpectedTokenException e)
                {
                    ChangeColorFor(() =>
                    {
                        Console.WriteLine($"Unexpected token {e.Token}. Character {e.Index}");
                        Console.WriteLine($"{e.Code.Substring((e.Index - 10) >= 0 ? e.Index - 10 : 0, e.Index)}");
                    }, ConsoleColor.Red);
                }
                catch (Exception e)
                {
                    ChangeColorFor(() => Console.WriteLine(e), ConsoleColor.Red);
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