using System;
using static System.Console;
using static System.ConsoleColor;
using System.Collections.Generic;

namespace Bestellformular_ConsoleApplication
{
    class Program
    {
        struct Bestellzeile
        {
            public string bezeichnung;
            public double einzelpreis;
            public int bestellmenge;
            public double zeilenpreis;
        };
        Dictionary<string, double> mwstSatz = new Dictionary<string, double>();
        
        static string hinweis = "Alle Preise sind Netto, zzgl. MwSt";
        static string auswahl;

        static void Main(string[] args)
        {
            Dictionary<string, double> landMwst = new Dictionary<string, double>();
            landMwst.Add("D", 0.19);
            landMwst.Add("NL", 0.21);
            landMwst.Add("S", 0.25);
            landMwst.Add("F", 0.16);

            Bestellzeile[] bestellung = new Bestellzeile[]
                { new Bestellzeile {bezeichnung ="Laptop" ,einzelpreis=782.99,bestellmenge=0,zeilenpreis=0.0 },
                  new Bestellzeile {bezeichnung ="Tablet" ,einzelpreis=186.49,bestellmenge=0,zeilenpreis=0.0 },
                  new Bestellzeile {bezeichnung ="Phone " ,einzelpreis= 87.99,bestellmenge=0,zeilenpreis=0.0 },
                  new Bestellzeile {bezeichnung ="Printer",einzelpreis=236.39,bestellmenge=0,zeilenpreis=0.0 },
                  new Bestellzeile {bezeichnung ="Desktop",einzelpreis=986.99,bestellmenge=0,zeilenpreis=0.0 }
                };
            int oldCursorTop = 9;
            ConsoleKeyInfo cki;
            bool mwstGesetzt = false;
            //double steuerSatz = mehrwertsteuersatz(landMwst);
            
            //WriteLine("\n{0}", landMwst["D"]);
            do
            {
                int startLeft = 4; int startTop = 8;
                int breiteBez = 7; int breiteEp = 7;
                SetCursorPosition(startLeft, startTop);
                ForegroundColor = White;
                Write("Bezeichnung\tE.Preis\tBestellmenge\tPreis");
                ForegroundColor = Green;
                double gesamtpreis = 0;
                foreach (Bestellzeile zeile in bestellung)
                {
                    SetCursorPosition(4, ++CursorTop); ;
                    Write("{0,-7}\t{1,7:F2}\t{2,6:D}\t{3,13:F2}", zeile.bezeichnung, zeile.einzelpreis, zeile.bestellmenge, zeile.zeilenpreis);
                    gesamtpreis += zeile.zeilenpreis;
                }
                hinweiseAusgeben(startLeft,startTop-1,Red);
                CursorSize = 10;
               while (!mwstGesetzt)
                {
                    SetCursorPosition(startLeft, 18);
                    WriteLine("Bitte geben Sie ihr Mehrwertsteuersatz an: ");
                    SetCursorPosition(startLeft, 19);
                    foreach (KeyValuePair<string, double> kvp in landMwst)
                    {
                        Write("{0} : {1:P}\t", kvp.Key, kvp.Value);
                    }
                    auswahl = ReadLine();
                    double satz = 0.0;
                    if(landMwst.TryGetValue(auswahl, out satz)){
                            mwstGesetzt = true;
                    }
                    else
                    {
                        Write("\nLand nicht gefunden, bitte versuchen Sie es nochmanl!");
                    }
                    
                }
                
                SetCursorPosition(startLeft, 20);
                Write("Gesamtpreis: {0,8:F2}", gesamtpreis);
             // Write("\n Mehrwertsteuer: {0,8:F2}", mwstBerechnen(0.07,gesamtpreis));
             // Write("\n          Summe: {0,8:F2}", gesamtpreis + mwstBerechnen(0.07,gesamtpreis));
                summeBerechnen(gesamtpreis, Yellow, landMwst[auswahl] /*steuerSatz*/);
                
                SetCursorPosition(breiteBez + 8 + breiteEp + 8, oldCursorTop);
                cki = Console.ReadKey(true);
                if (!Char.IsNumber(cki.KeyChar))
                {
                    switch (cki.Key.ToString())
                    {
                        case "UpArrow": SetCursorPosition(CursorLeft, (CursorTop > startTop + 1) ? --CursorTop : CursorTop); break;
                        case "DownArrow": SetCursorPosition(CursorLeft, (CursorTop < (startTop + 5)) ? ++CursorTop : CursorTop); break;
                        case "RightArrow":
                            bestellung[CursorTop - 9].bestellmenge++;
                            bestellung[CursorTop - 9].zeilenpreis += bestellung[CursorTop - 9].einzelpreis; break;
                        case "LeftArrow":
                            if (bestellung[CursorTop - 9].bestellmenge > 0)
                            {
                                bestellung[CursorTop - 9].bestellmenge--;
                                bestellung[CursorTop - 9].zeilenpreis -= bestellung[CursorTop - 9].einzelpreis;
                            }
                            break;
                        default: break;
                    }
                    oldCursorTop = CursorTop;
                }
                else
                {
                    int num = int.Parse(cki.KeyChar.ToString());
                    bestellung[CursorTop - 9].bestellmenge = num;
                    bestellung[CursorTop - 9].zeilenpreis = num * bestellung[CursorTop - 9].einzelpreis;
                    Write(num);
                }
            } while (cki.Key != ConsoleKey.Escape);
            ReadLine();
        }   // end of main
        private static void hinweiseAusgeben() // Überladung
        {
           Write("\nHinweis: ");
        }
        private static void hinweiseAusgeben(int left, int top)
        {
            SetCursorPosition(left, top);
            Write("Hinweis: ");
        }
        private static void hinweiseAusgeben(int left, int top, ConsoleColor farbe)
        {
            ConsoleColor hilf = ForegroundColor;
            ForegroundColor = farbe;
            SetCursorPosition(left, top);
            Write("Hinweis: {0}",hinweis);
            ForegroundColor = hilf;
        }
        private static double mwstBerechnen(double gesamtpreis)
        {
            Write("\tMwSt. 19%");
            return gesamtpreis * 0.19;
        }
        private static double mwstBerechnen(double mwst, double gesamtpreis)
        {
            Write("\tMwst. {0:P}", mwst);
            return gesamtpreis * mwst;
        }
        /*private static void summeBerechnen( double gesamtpreis, ConsoleColor farbe)
        {
            summeBerechnen(gesamtpreis, 0.19, farbe); // Delegation
            /*ConsoleColor hilf = ForegroundColor;
            double mwst = gesamtpreis*0.19;
            Write("\n Mehrwertsteuer: {0,8:F2}\t Mwst = 19%", mwst);
            ForegroundColor = farbe;
            SetCursorPosition(10, CursorTop+1);
            Write("Summe: {0,8:F2}", gesamtpreis + mwst);
            ForegroundColor = hilf;*/
        //} 
                                                //optionale parameter(n) => geht nur als letzte(n) parameter(n)                     
        private static void summeBerechnen(double gesamtpreis, ConsoleColor farbe, double mwst = 0.19)
        {
            ConsoleColor hilf = ForegroundColor;
            double ust = gesamtpreis * mwst;
            Write("\n Mehrwertsteuer: {0,8:F2}\t Mwst = {1:P}", ust, mwst);
            ForegroundColor = farbe;            
            SetCursorPosition(10, CursorTop + 1);
            Write("Summe: {0,8:F2}", gesamtpreis + ust);
            ForegroundColor = hilf;
        }
        private static double mehrwertsteuersatz(Dictionary<string,double> steuer)
        {
            double satz = 0.0;
            foreach (KeyValuePair<string, double> kvp in steuer)
            {
                Write("{0} : {1:P}\t", kvp.Key, kvp.Value);
            }
            Write("\nBitte geben Sie ihr Mehrwertsteuersatz an: ");
            string eingabe = ReadLine();
            if(steuer.TryGetValue(eingabe, out satz))
            {
                return satz;
            }
            else
            {
                WriteLine("Land nicht gefunden. Es werden 19% berechnet.");
                satz = 0.19;
                return satz;
            }
            
        }
    }
}

