using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public class Angestellter : Personal
    {
        public static int gesamtAnzahlObjekte;
        protected int id; // wird weiter vererbt an folge klassen
        public Angestellter()
        {
            gesamtAnzahlObjekte++;
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Angestellter Basiskonstruktor gestartet");
            Console.WriteLine("Der Aufruf wurde ausgelöst von {0}", this.GetType());
            if(string.Compare(this.GetType().ToString(), "Wdh20173010ConsoleApplication.Angestellter") == 0)
            {
                Console.WriteLine("___________________________________________________\n");
            }
            Console.ForegroundColor = temp;
        }

        public int id_lesen
        {
            get
            {
                return id;
            }
        }

        public override void ausbezahlen()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Der Auszahlvorgang wird per Überweisung durchgeführt.");
            Console.ForegroundColor = temp;
        }
    }
}