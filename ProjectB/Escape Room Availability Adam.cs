﻿using System;

namespace Playground
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            string EscapeRoom1Availability = "Available";
            string EscapeRoom2Availability = "Available";
            string EscapeRoom3Availability = "Available";
            string EscapeRoom4Availability = "Available";
            string EscapeRoom5Availability = "Available";


            Console.WriteLine("Maak een keuze om de beschikbaarheid te checken van een Escape Room:\n");
            Console.WriteLine("1) Kamer 1\n");
            Console.WriteLine("2) Kamer 2\n");
            Console.WriteLine("3) Kamer 3\n");
            Console.WriteLine("4) Kamer 4\n");
            Console.WriteLine("5) Kamer 5\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom1Availability);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom2Availability);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom3Availability);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom4Availability);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(EscapeRoom5Availability);
                    break;
            }


            Console.WriteLine("Wil je de beschikbaarheid van de kamer aanpassen?\n");

            switch (Console.ReadLine())
            {
                case "ja":
                  
                    break;
                case "nee":
                    break;
            }
        }
    }
}
