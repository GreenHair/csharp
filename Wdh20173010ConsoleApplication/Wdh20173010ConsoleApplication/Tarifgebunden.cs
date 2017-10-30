using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public class TarifgebundenerAngestellter : Angestellter
    {
        public static int gesamtAnzahlObjekte;
        // hat auch eine id von Angestellter erhalten
        public TarifgebundenerAngestellter()
        {
            gesamtAnzahlObjekte++;
            id = Angestellter.gesamtAnzahlObjekte;
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("TarifgebundenerAngestellter Basiskonstruktor gestartet");
            Console.WriteLine("Der Aufruf wurde ausgelöst von {0}", this.GetType());
            Console.ForegroundColor = temp;
        }

        public override void ausbezahlen()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            base.ausbezahlen();
            Console.WriteLine("Vom Lohn werden die Sozialebeiträge abgezogen.");
            Console.ForegroundColor = temp;
        }
    }
}