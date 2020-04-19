using System;

namespace availER
{
    public class Program
    {
        public static void Avail() 
        {
            Console.Clear();

            string Kamer1 = "beschikbaar";
            string Kamer2 = "niet beschikbaar";
            string Kamer3 = "niet beschikbaar";
            string Kamer4 = "beschikbaar";
            string Kamer5 = "beschikbaar";


            Console.WriteLine("====================================");
            Console.WriteLine("Overzicht beschikbaarheid van de Escape Rooms." + "\n");
            Console.WriteLine("Kamer 1: "+ Kamer1 + "\n" + "Kamer 2: " + Kamer2 + "\n" + "Kamer 3: "+ Kamer3 + "\n" + "Kamer 4: " + Kamer4 + "\n" + "Kamer 5: " + Kamer5);
            Console.WriteLine("====================================");
            Console.WriteLine("Welke kamer wilt u boeken(1-5)?");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Deze kamer is " + Kamer1 + " voor boeking.");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Deze kamer is " + Kamer2 + " voor boeking.");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Deze kamer is " + Kamer3 + " voor boeking.");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Deze kamer is " + Kamer4 + " voor boeking.");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Deze kamer is " + Kamer5 + " voor boeking.");
                    break;
            }
        }
    }
}
