using System;

namespace ProjectB
{   
    class Program
    {
        static void Main()
        {
            Console.Clear();

            string EscapeRoom1 = "Deze Escape Room bestaat uit een Horror thema met enge puzzels en evenementen.\nTijdsduur: 1 uur\nPrijs: 23,95\nGrootte: 3-5 mensen\n";
            string EscapeRoom2 = "Deze Escape Room bestaat uit een Sci-fi thema waarbij veel aandacht wordt besteed aan sterren puzzels.\nTijdsduur: 1 uur\nPrijs: 23,95\nGrootte: 3-5 mensen\n";
            string EscapeRoom3 = "Deze Escape Room bestaat uit een Fantasy thema waarbij veel aandacht wordt besteed aan oude klassieke puzzels.\nTijdsduur: 1.5 uur\nPrijs: 35,95\nGrootte: 4-6 mensen\n";
            string EscapeRoom4 = "Deze Escape Room bestaat uit een Detective thema waarbij veel oude moordzaken moeten worden opgelost.\nTijdsduur: 30 minuten\nPrijs: 19,95\nGrootte: 5 mensen\n";
            string EscapeRoom5 = "Deze Escape Room bestaat uit een Aquatic thema waarbij je veel kennis nodig hebt over de ocean en dergelijke.\nTijdsduur: 1.5 uur\nPrijs: 35,95\nGrootte: 4-6 mensen\n";


            Console.WriteLine("Maak een keuze voor een Escape Room:");
            Console.WriteLine("====================================");
            Console.WriteLine("1) Horror 18+\n");
            Console.WriteLine("2) Sci-fi 12+\n");
            Console.WriteLine("3) Fantasy 12+\n");
            Console.WriteLine("4) Detective 14+\n");
            Console.WriteLine("5) Aquatic 12+");
            Console.WriteLine("====================================\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom1);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom2);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom3);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom4);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom5);
                    break;
            }

            Console.WriteLine("Terug naar het hoofdmenu?: (Ja of Nee)\n");

            switch (Console.ReadLine())
            {
                case "Ja":
                    Main();
                    break;
                case "ja":
                    Main();
                    break;
                case "Nee":
                    break;
                case "nee":
                    break;
            }
        }
    }
}
