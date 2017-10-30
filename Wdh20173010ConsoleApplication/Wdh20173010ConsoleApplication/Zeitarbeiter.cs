using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public class Zeitarbeiter : Personal
    {
        public static int gesamtAnzahlObjekte;
        public Zeitarbeiter()
        {
            gesamtAnzahlObjekte++;
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Zeitarbeiter Basiskonstruktor gestartet");
            Console.WriteLine("Der Aufruf wurde ausgelöst von {0}", this.GetType());
            Console.ForegroundColor = temp;
        }

        public override void ausbezahlen()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Der Auszahlvorgang ist in Bar.");
            Console.ForegroundColor = temp;
        }
    }
}