﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiscounterActor_ConsoleApplication
{
    class Kasse  // soll den Umsatz berechnen für jeden Kunden
                 // für den ganzen Tag 
                 // Bestandsabfragen ( pro Regal) ermöglichen
                 // Schwund ermitteln 
    {
        // Attribute
        private double kunde_umsatz;
        private double tages_umsatz;
        public bool offen;
        private Warenkatalog wk;

        // Methoden

        public Kasse(ref Warenkatalog wk)
        {
            offen = true;
            kunde_umsatz = 0.0;
            tages_umsatz = 0.0;
        Console.WriteLine("Kasse ist geöffnet");
        }

        public double kunde_abrechnen( Einkaufszettel ekw )
        {
            kunde_umsatz = 0.0;
            for (int i = 0; i < ekw.liste.Count;i++)
            {
               // Console.WriteLine("Artikel {0,3}, {1,3} mal a {2,4:F2} Euro", ekw.liste[i].artikel, ekw.liste[i].anzahl, Warenkatalog.warenkatalog[ekw.liste[i].artikel].art_einzelpreis);
                kunde_umsatz += ekw.liste[i].anzahl * Warenkatalog.warenkatalog[ekw.liste[i].artikel].art_einzelpreis;
            }
            tages_umsatz += kunde_umsatz;            
            return kunde_umsatz; 
        }

        public void nachfuellen_anfordern(ref Discounter_ConsoleApplication.Verkauf v,ref Discounter_ConsoleApplication.Lager l, Lagerist heinz)
        {
            // Auftrag an Personal, die Regale auf der Fehlliste nachzufüllen

            // dazu braucht mann das Resultat von fehlbestand_anzeigen(), einen Lagerspezi der angsprochen wird
            Einkaufszettel auftrag = new Einkaufszettel("Auftrag");
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Der Lagerist geht zum Lager....");
            auftrag = heinz.wareEntnehmen(l, fehlbestand_anzeigen(v));
            Console.WriteLine("Der Lagerist füllt nach...");
            heinz.wareAuffuellen(v, auftrag);
            Console.ForegroundColor = temp;        
        }

        public Einkaufszettel  fehlbestand_anzeigen(Discounter_ConsoleApplication.Raum v)
        {
            // Über alle Regale wandern und jedes mit "nachfüllen = True"
            // in die Fehlliste eintragen
            Einkaufszettel fehlliste = new Einkaufszettel("Auftrag");
            for (int i = 0; i < v.regale.Length; i++)
            {
                if (v.regale[i].nachfuellen == true)
                {
                   // Console.WriteLine(" Regal {0} muss aufgefüllt werden ", i);
                   // Console.WriteLine(" Es fehlen zum Maximalbestand {0} Einheiten", v.regale[i].kapazität - v.regale[i].aktuellerInhalt);
                    fehlliste.liste.Add(new Einkaufszettel.zeile() { artikel = i, anzahl = v.regale[i].kapazität - v.regale[i].aktuellerInhalt });
                }
            }
            // Fehlende Menge zum Maximalbestand
            return fehlliste;
        }
    }
}
