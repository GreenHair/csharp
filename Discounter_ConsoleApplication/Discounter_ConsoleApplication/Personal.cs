﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscounterActor_ConsoleApplication
{
     class Personal : Actor
    {
        
        public Personal()
        {
            this.id = Actor.lfrNr;
            Console.WriteLine("Ich bin beim Personal und das Objekt {0}", id);
        }
        public override void bezahlen(ref Kasse ks)
        {
            double preis = ks.kunde_abrechnen(einkaufswagen);
            Console.WriteLine("Das Personal zahlt mit Rabatt");
            Console.WriteLine("statt {0,6:F2} nur {1,6:F2} Euro",preis, preis*.7);
        }

        ~Personal()
        {
           
        }
    }
}