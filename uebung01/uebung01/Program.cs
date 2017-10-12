using System;
using static System.Console;

namespace uebung01
{
    class Program
    {
        static void Main()
        {
            int a = 10;
            SetWindowSize(120,40);
            Console.Title = "Beispiel";
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.SetCursorPosition(0, a-5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Navigation\nZiel1\nZiel2\nZiel3");
            
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < 14; i++) { 
                Console.SetCursorPosition(30, a++);
                Console.WriteLine("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ..."); //ligula eget dolor. Aenean massa..
            }

            Console.ForegroundColor = ConsoleColor.White;            
            Console.SetCursorPosition(0, 39);
            Console.Write("Impressum");
            Console.SetCursorPosition(100, 0);
            Console.Write("Titel: ");
           // Console.SetCursorPosition(30, 25);
            Console.ReadLine();
        }
    }
}
