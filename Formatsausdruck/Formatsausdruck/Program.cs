using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatsausdruck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int maxWidth = Console.LargestWindowWidth;
            int maxHeight = Console.LargestWindowHeight;
            int topLine = 0;
            Console.SetWindowSize(maxWidth / 2, maxHeight / 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            string dateString = $"Heute: {DateTime.Now.ToLongDateString()}";
            string timeString = $" {DateTime.Now.ToString("hh:mm:ss")}";

            int lengthDateTimeNow = dateString.Length;
            int lengthTimeNow = timeString.Length;

            string[] artikel = new string[5];
            artikel[0] = "Gummibärchen";
            artikel[1] = "Alexa Tablet";
            artikel[2] = "8 Rollen Klopapier";
            artikel[3] = "Niederländische National Mannschaft";
            artikel[4] = "Herd";

            double[] preise = new double[5];
            preise[0] = 2.75;
            preise[1] = 199.99;
            preise[2] = 1.65;
            preise[3] = 1052.75;
            preise[4] = 734.75;

            Console.SetCursorPosition(maxWidth / 2 - lengthDateTimeNow, topLine);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dateString);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(maxWidth / 2 - lengthDateTimeNow-2, topLine+1);
            Console.WriteLine("Uhrzeit:");
            Console.SetCursorPosition(maxWidth / 2 - lengthTimeNow, topLine+1);
            Console.WriteLine(timeString);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 9);
            Console.Write("Bezeichnung\t\tPreis\tAnzahl\tGesamt");
            double preis = 0;
            double gesamtpreis = 0;
            for (int zeile = 10; zeile < 15; zeile++)
            {
                int top = Console.CursorTop;
                int left = Console.CursorLeft;
                //Console.Write(top + " " + left);         
                Console.ForegroundColor = (ConsoleColor)(zeile%16);
                Console.SetCursorPosition(2, zeile);
                preis = zeile * 43 / 100.0;
                Console.Write($"{artikel[zeile-10]}\t\t{preise[zeile-10]} €\t" );
                int anzahl = Convert.ToInt16(Console.ReadLine());
                Console.SetCursorPosition(left-8, zeile+1);
                Console.Write(new string(' ',10));
                Console.SetCursorPosition(left-8, zeile);
                Console.Write("{0,8:C}" ,anzahl * preise[zeile - 10]);
                gesamtpreis += (anzahl * preise[zeile - 10]);
                Console.SetCursorPosition(Console.CursorLeft -8, Console.CursorTop + 2);
                Console.Write("{0,8:C}", gesamtpreis);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, Console.CursorTop-1);
            Console.Write(new string('_',36));
            Console.SetCursorPosition(Console.CursorLeft-8, Console.CursorTop+1);
            Console.Write("{0,8:C}",gesamtpreis);
            
                     
            Console.ReadLine();
        }
    }
}
