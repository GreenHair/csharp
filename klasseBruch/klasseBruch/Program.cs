using System;
using static System.Console;
namespace klasseBruch
{
    class Bruch
    {
        // Attribute
        int zaehler;
        int nenner;
        double dezimal;

        // Methoden
        public void nenner_setzen(int wert)
        {
            nenner = (!(wert == 0)) ? wert : 1;
        }
        public void zaehler_setzen(int wert)
        {
            zaehler = wert;
        }

        public int Zaehler
        {
            set // setter für eine property
            {
                zaehler = value;
                // do stuff
            }
            get
            {
                return zaehler;
            }
        }

        double dezimal_ermitteln()
        {
            dezimal = (double)zaehler / nenner;
            return dezimal;
        }
        public void darstellen()
        {
            Write("{0}/{1} = {2,4:F3}", zaehler, nenner, dezimal_ermitteln());
        }

        public void kuerzen()
        {

        }
        public void addieren()
        {

        }
        public void erweitern()
        {

        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Bruch myBruch = new Bruch();
            myBruch.zaehler_setzen(3);
            myBruch.nenner_setzen(4);
            myBruch.darstellen();
            myBruch.Zaehler = 33;  // ist wie myBruch.Zaehler(33)
            

            ReadLine();
        }
    }
}
