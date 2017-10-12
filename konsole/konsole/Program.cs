using System;
using static System.Console;
using static System.ConsoleColor;

namespace classConsole_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            BackgroundColor = Blue;
            Clear();
            WriteLine("The current window width is {0} Chars", Console.WindowWidth);
            ReadLine();
            
            Console.SetWindowSize(Console.LargestWindowWidth, 40);
            BackgroundColor = ConsoleColor.DarkGreen;
            Clear();
            Console.WriteLine("The current window width is {0} Chars", Console.WindowWidth);
            ReadLine();

        }
    }
}