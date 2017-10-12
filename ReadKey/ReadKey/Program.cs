using System;


namespace ReadKey_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int zeile = 0;
            int spalte = 0;

            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                Console.SetCursorPosition(spalte, zeile);
                switch (cki.Key.ToString())
                {
                    case "LeftArrow":  spalte--; /*(spalte < 0)?spalte = 0:spalte-- ;*/ break;
                    case "RightArrow": spalte++ ; break;
                    case "UpArrow":    zeile-- ; break;
                    case "DownArrow":  zeile++ ; break;
                    default: break;
                }
                
                Console.WriteLine(zeile + "," + spalte);


                Console.WriteLine(cki.Key.ToString());
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
