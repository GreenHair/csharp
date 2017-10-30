using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public abstract class Personal
    {
        public static int gesamtAnzahlObjekte;
        protected double entlohnung;
        // Basiskonstruktor
        public Personal(
            [System.Runtime.CompilerServices.CallerMemberName] string memberName ="",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0
            )
        {
            gesamtAnzahlObjekte++;
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" --- Objekterstellung beginnt ------------------");
            Console.WriteLine("Personal Basiskonstruktor gestartet");
            Console.WriteLine("Der Aufruf wurde ausgelöst von {0}", this.GetType());
            Console.WriteLine("{0} {1} : {2}", memberName, sourceFilePath, lineNumber);
            
            Console.ForegroundColor = temp;
           
        }

        public virtual void ausbezahlen()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;            
            Console.WriteLine("Der Auszahlvorgang ist noch nicht Spezifiziert");            
            Console.ForegroundColor = temp;
        }
    }
}