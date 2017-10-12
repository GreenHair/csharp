using System;
using System.Text;
using static System.Console;

namespace einkaufsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            int maxWidth = LargestWindowWidth;
            int maxHeight = LargestWindowHeight;
            int topLine = 0;
            SetWindowSize(maxWidth / 2, maxHeight / 2);
            BackgroundColor = ConsoleColor.Black;
            Clear();
            string dateString = $"Heute: {DateTime.Now.ToLongDateString()}";
            string timeString = $" {DateTime.Now.ToString("hh:mm:ss")}";

            int lengthDateTimeNow = dateString.Length;
            int lengthTimeNow = timeString.Length;

            string[,] angebot =
            new string[5, 2] {
                {"Gummibärchen","2,75"},
                {"Mineralwasser","1,65"},
                {"Kaffee","2,95"},
                {"Chocolade 400gr","3,53"},
                {"Äpfel 2kg","1,99"}
            };
            
            SetCursorPosition(maxWidth / 2 - lengthDateTimeNow, topLine);
            ForegroundColor = ConsoleColor.Red;
            WriteLine(dateString);
            ForegroundColor = ConsoleColor.Green;
            SetCursorPosition(maxWidth / 2 - lengthDateTimeNow - 2, topLine + 1);
            WriteLine("Uhrzeit:");
            SetCursorPosition(maxWidth / 2 - lengthTimeNow, topLine + 1);
            WriteLine(timeString);

            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(2, 9);
            Write("{0,-30}Preis  Anz\tPositionspreis","Bezeichnung");
            for(int zeile = 0; zeile < angebot.GetLength(0); zeile++)
            {
                SetCursorPosition(2, zeile + 10);
                ForegroundColor = (ConsoleColor)(zeile + 10);
                for(int spalte = 0; spalte < angebot.GetLength(1); spalte++)
                {
                    Write("{0,-30}", angebot[zeile, spalte]);
                }
                
            }

            int x = 40;
            int y = 10;

            double[] position = new double[5];
            string[] anzahl = new string[5] { "000000","000000","000000","000000","000000"};

            ConsoleKeyInfo cki;

            do
            {
                SetCursorPosition(x, y);
                cki = ReadKey(true);
                switch (cki.Key.ToString())
                {
                    case "LeftArrow":  x=( x <= 40 )?  40: x-1 ; break;
                    case "RightArrow":  x = (x >= 45) ? 40 : x + 1; break;
                    case "UpArrow":  y = (y <= 10) ? 10 : y - 1; break;
                    case "DownArrow":  y = (y >= 14) ? 10 : y + 1; x = 40; break;
                    case "D0":   // Die Ziffertasten auf der Tastatur (nicht das nummerpad)
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9": Write(cki.KeyChar); x++;
                        //anzahl[y - 10].Insert(4, cki.KeyChar.ToString());
                        anzahl[y - 10] += cki.KeyChar.ToString();
                        position[y - 10] = Convert.ToInt32(anzahl[y - 10]) * Convert.ToDouble(angebot[y - 10, 1]);
                        SetCursorPosition(47, y);
                        Write("{0,8:C}", position[y - 10]);//Write(anzahl[y - 10]);
                        break;
                    default: ; break;
                }
                
            } while (cki.Key != ConsoleKey.Enter);

            x = 47;y = 10;   // neue Position für die Schreibmarke
            double gesamt = 0;
           
           for(int i = 0; i < 5; i++)
            {
                //position[y - 10] = Convert.ToInt32(anzahl[y - 10]) * Convert.ToDouble(angebot[y - 10, 1]);
                SetCursorPosition(x, y++);
                WriteLine("{0,8:C}", position[i]);
                gesamt += position[i];
            }

            SetCursorPosition(x, y++);
            Write("Gesamt: {0,8:C}", gesamt);


            ReadLine();
        }
    }
}
