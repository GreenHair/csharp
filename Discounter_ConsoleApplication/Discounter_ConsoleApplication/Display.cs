using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discounter_ConsoleApplication
{
    internal static class Display
    {

        public static void darstellen(ref Regal[] regale, int x, int y)
        {
            //  Console.Clear();
            Console.WriteLine("Hier kommt Regal {0} bis {1} auf den Schirm", x, y);
            for (int i = x; i <= y; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGray;

                if (i == 0)
                {
                    Console.WriteLine("{0,42}", " ");
                    Console.Write(" ");
                }

                if ((i % 40 == 0) && (i > 0))
                {
                    Console.WriteLine(" ");
                    Console.Write(" ");

                    if (i % 80 == 0)
                    {
                        Console.WriteLine("{0,41}", " ");
                        Console.Write(" ");
                    }
                }

                Console.BackgroundColor = ConsoleColor.Green;

                if (regale[i].nachfuellen)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("!");

                }
                else
                {
                    Console.Write("#");
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ");
            Console.WriteLine("{0,42}", " ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
