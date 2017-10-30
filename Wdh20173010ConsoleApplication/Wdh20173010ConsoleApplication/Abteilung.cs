using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wdh20173010ConsoleApplication
{
    public class Abteilung
    {
        public LeitenderAngestellter chef;
       // static char[] b = { 'B', 'o', 's', 's' };
        public string nameChef = new string(/*b*/new char[] { 'B', 'o', 's', 's' });

        public Abteilung(LeitenderAngestellter derBoss)
        {
            chef = derBoss;
        }
    }
}