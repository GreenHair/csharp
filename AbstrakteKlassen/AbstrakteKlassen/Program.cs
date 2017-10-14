using System;
using static System.Console;

namespace AbstrakteKlassen
{
    class Program
    {
        class Klasse // Name wird Traditionell groß geschrieben
        {
            // Attributen oder Felder
            // Ohne explizieten Zugriffsmodifizier ist alles private und ohne
            // methode nicht erreichbar
            int ganzZahl;
            string zeichenkette;

            // Methoden
            public void zeigeAlles()
            {
                WriteLine("Das Objekt hat die Attributen:");
                WriteLine("{0}\t{1}", ganzZahl, zeichenkette);
            }

            // ganzZahl von ausserhalb mit wert füllen
            // public setter um die private  attribute zu setzen
            public void setze_ganzZahl_auf( int wert)
            {
                ganzZahl = wert;
            }

            public void setze_zeichenkette_auf(string wert)
            {
                zeichenkette = wert;
            }
        }

        static void Main(string[] args)
        {
            // Objekte erzeugen oder instantieren
            // Klasse nennen und Objektname festlegen
            Klasse objekt = new Klasse();
            //objekt.ganzZahl = 22; // wäre nur möglich wenn ganzZahl public => unerwünscht!
            objekt.setze_ganzZahl_auf(22);
            objekt.setze_zeichenkette_auf("Hallo Welt aus einem Objekt!");
            objekt.zeigeAlles();

            ReadLine();
        }
    }
}
