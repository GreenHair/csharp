using System;


namespace SimpleDataTypes_ConsoleApplication
{
    class Program
    {
        static string s = "Hello";  // ohne static ist die Variable nur mit einem Object verfügbar ausserhalb Main
        static void Main()
        {
            string s = "World";
            Console.WriteLine(Program.s); // Die variable von ausserhalb
            Console.WriteLine(s); // Lokale variable mit gleicher name
            Console.ReadLine();
        }
    }
}
