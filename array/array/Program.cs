using System;
using static System.Console;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] warenkorb = new string[5];
            warenkorb[0] = "200gr. Tüte Gummibären";
            warenkorb[1] = "1 Pfund Butter";
            warenkorb[2] = "1 Paprika";

            object[] universal = new object[5];
            universal[0] = "200gr. Tüte Gummibären";
            universal[1] = 555;
            universal[2] = 'A';

            for ( int index = 0; index < warenkorb.Length; index++)
            {
                WriteLine("| {0} |", warenkorb[index]);
            }

            for (int index = 0; index < universal.Length; index++)
            {
                WriteLine("| {0} |", universal[index].GetType());
                WriteLine("| {0} |", universal[index]);
            }

            ReadLine();
        }
    }
}
