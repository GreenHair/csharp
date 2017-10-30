using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public class LeitenderAngestellter : Angestellter
    {
        public static int gesamtAnzahlObjekte;
        private SortedList<int,int> meineMitarbeiterIDs = new SortedList<int,int>();
        public LeitenderAngestellter()
        {
            gesamtAnzahlObjekte++;
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("LeitenderAngestellter Basiskonstruktor gestartet");
            Console.WriteLine("Der Aufruf wurde ausgelöst von {0}", this.GetType());
            Console.ForegroundColor = temp;
        }

        public void inAbteilungEinstellen(int id)
        {
            meineMitarbeiterIDs.Add(id,id);
        }

        public int wieVielMaHabIchDenn()
        {
            return meineMitarbeiterIDs.Count;
        }

        public void zeigeMeineMitarbeiter()
        {
            foreach(KeyValuePair<int, int> element in meineMitarbeiterIDs)
            {
                Console.WriteLine("Der Mitarbeiter{0} gehört zu Abteilung", element.Value);
            }
        }

        public override void ausbezahlen()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            base.ausbezahlen();
            Console.WriteLine("Der Lohn wird vollständig ausbezahlt.");
            Console.ForegroundColor = temp;
        }
    }
}