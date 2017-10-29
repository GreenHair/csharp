using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discounter_ConsoleApplication
{
    

    class Program
    {
        // Warenkatalog laden per 

        
        static void Main(string[] args)
        {

            Warenkatalog wk = new Warenkatalog();
            DiscounterActor_ConsoleApplication.Kasse kasse = new DiscounterActor_ConsoleApplication.Kasse(ref wk);

            Verkauf v = new Verkauf("Im2.OG_Hohe Strasse",400.0, ref Warenkatalog.warenkatalog);
            v.anzeigen(v.regale);       // der ganze Raum 
            ReadLine();
            Lager l = new Lager("gemeinsamer Keller in Ossendorf", 270.0, ref Warenkatalog.warenkatalog);
            l.anzeigen(l.regale);
            WriteLine("{0}\t{1}", l.regale[810].regal_id,l.regale[810].aktuellerInhalt);
            DiscounterActor_ConsoleApplication.Lagerist lagermensch = new DiscounterActor_ConsoleApplication.Lagerist();
            ReadLine();

            DiscounterActor_ConsoleApplication.Kunde k = new DiscounterActor_ConsoleApplication.Kunde();
            k.einkaufswagen=k.wareEntnehmen(v);
            v.anzeigen(v.regale);
            k.bezahlen(ref kasse); // wird polymorph weitergegeben an  kasse.kunde_abrechnen();
            /* Kunde aus dem Speicher entfernen
            k = null;
            GC.Collect();*/
            ReadLine();
            
            v.anzeigen(v.regale);
            //kasse.fehlbestand_anzeigen();
            //ReadLine();

            DiscounterActor_ConsoleApplication.Personal p = new DiscounterActor_ConsoleApplication.Personal();
            p.einkaufswagen = p.wareEntnehmen(v);
            v.anzeigen(v.regale);
            p.bezahlen(ref kasse); // wird polymorph weitergegeben an  kasse.kunde_abrechnen();
            ReadLine();

            v.anzeigen(v.regale);
            

            DiscounterActor_ConsoleApplication.Kunde k2 = new DiscounterActor_ConsoleApplication.Kunde();
            k2.einkaufswagen = k2.wareEntnehmen(v,k2.einkaufsliste);
            v.anzeigen(v.regale);
            k2.bezahlen(ref kasse);
            ReadLine();
            v.anzeigen(v.regale);
           
            //kasse.fehlbestand_anzeigen(v);
            if(v.leereRegale >= 5)
            {
                kasse.nachfuellen_anfordern(ref v, ref l, lagermensch);
            }
            
            // WriteLine("{0}\t{1}", v.regale[440].aktuellerInhalt, v.regale[440].nachfuellen);
            ReadLine();
            v.anzeigen(v.regale);
            l.anzeigen(l.regale);
            // Console.WriteLine();
            DiscounterActor_ConsoleApplication.Kunde k3 = new DiscounterActor_ConsoleApplication.Kunde();
            k3.einkaufswagen = k3.wareEntnehmen(v, k3.einkaufsliste);
            v.anzeigen(v.regale);
            k3.bezahlen(ref kasse);
            ReadLine();
            kasse.nachfuellen_anfordern(ref v,ref l, lagermensch);
            v.anzeigen(v.regale);
            l.anzeigen(l.regale);
            ReadLine();
            DiscounterActor_ConsoleApplication.Kunde[] menge = new DiscounterActor_ConsoleApplication.Kunde[10];
            for( int i = 0; i < 10; i++)
            {
                menge[i] = new DiscounterActor_ConsoleApplication.Kunde();
                menge[i].einkaufswagen = menge[i].wareEntnehmen(v);
                menge[i].bezahlen(ref kasse);
                if (v.leereRegale >= lagermensch.tragkraft)
                {
                    kasse.nachfuellen_anfordern(ref v, ref l, lagermensch);
                }
                System.Threading.Thread.Sleep(2000);
            }
            v.anzeigen(v.regale);
            l.anzeigen(l.regale);
            ReadLine();
        }
    }
}
