using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static TimeSpan roomDuration = TimeSpan.Parse("1:00");
        public static TimeSpan cleanUp = TimeSpan.Parse("00:30");
        public static TimeSpan openingTime = TimeSpan.Parse("09:00");
        public static string[] tijden = new string[15] { "09:15", "12:15", "14:45", "09:15", "12:15", "14:45", "09:15", "12:15", "14:45", "09:15", "12:15", "14:45", "09:15", "12:15", "14:45" };
        public static string[] opties = new string[15] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };

        public static string availability = " Available";
        public static string availability2 = " Available";
        public static string availability3 = " Available";

        public static void Main()

        {

            TimeSpan endTime = roomDuration + TimeSpan.Parse(tijden[2]);
            TimeSpan openingpluscleanup = openingTime + cleanUp;


            string formattedEndTime = endTime.ToString("hh\\:mm");
            string formattedOpeninTime = openingTime.ToString("hh\\:mm");
            string pluscleanup = openingpluscleanup.ToString("hh\\:mm");


            Console.Clear();
            Console.WriteLine("--- Time Options ---");


            Console.WriteLine("--Monday--");
            Console.WriteLine("|" + opties[0] + "|" + tijden[0] + "\n" + "|" + opties[1] + "|" + tijden[1] + "\n" + "|" + opties[2] + "|" + tijden[2]);

            Console.WriteLine("--Tuesday--");
            Console.WriteLine("|" + opties[3] + "|" + tijden[3] + "\n" + "|" + opties[4] + "|" + tijden[4] + "\n" + "|" + opties[5] + "|" + tijden[5]);

            Console.WriteLine("--Wednesday--");
            Console.WriteLine("|" + opties[6] + "|" + tijden[6] + "\n" + "|" + opties[7] + "|" + tijden[7] + "\n" + "|" + opties[8] + "|" + tijden[8]);

            Console.WriteLine("--Thursday--");
            Console.WriteLine("|" + opties[9] + "|" + tijden[9] + "\n" + "|" + opties[10] + "|" + tijden[10] + "\n" + "|" + opties[11] + "|" + tijden[11]);

            Console.WriteLine("--Friday--");
            Console.WriteLine("|" + opties[12] + "|" + tijden[12] + "\n" + "|" + opties[13] + "|" + tijden[13] + "\n" + "|" + opties[14] + "|" + tijden[14]);


            Console.WriteLine("Make an option to change the availability of a room:");
            string tempTime = Console.ReadLine();


            Console.WriteLine("");
            Console.WriteLine("-- Availability Escape Rooms --");
            Console.WriteLine("What day would you like to see?");
            Console.WriteLine("-------------------------------");



            switch (Console.ReadLine())

            {
                case "Monday":
                    Console.WriteLine("--- Monday ---");
                    Console.WriteLine("On Monday the rooms are occupied at: ");


                    for (int i = 0; i <= tijden.Length - 1; i++)
                    {

                        endTime = roomDuration + TimeSpan.Parse(tijden[i]);
                        formattedEndTime = endTime.ToString("hh\\:mm");
                    }


                    if (tempTime == opties[0])
                    {
                        availability = " Unavailable";
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + availability);
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + availability2);
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + availability3);

                    }
                    if (tempTime == opties[1])
                    {

                        availability2 = " Unavailable";
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + availability);
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + availability2);
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + availability3);

                    }
                    if (tempTime == opties[2])
                    {

                        availability3 = " Unavailable";
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + availability);
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + availability2);
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + availability3);

                    }


                    break;


                case "Tuesday":
                    Console.WriteLine("--- Tuesday ---");
                    Console.WriteLine("On Tuesday the rooms are occupied at: ");

                    if (tempTime == opties[3])
                    {
                        Console.WriteLine(tijden[3] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[4] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[5] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[4])
                    {
                        Console.WriteLine(tijden[3] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[4] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[5] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[5])
                    {
                        Console.WriteLine(tijden[3] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[4] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[5] + "-" + formattedEndTime + " Unavailable");
                    }

                    break;


                case "Wednesday":
                    Console.WriteLine("--- Wednesday---");
                    Console.WriteLine("On Wednesday the rooms are occupied at: ");


                    if (tempTime == opties[6])
                    {
                        Console.WriteLine(tijden[6] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[7] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[8] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[7])
                    {
                        Console.WriteLine(tijden[6] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[7] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[8] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[8])
                    {
                        Console.WriteLine(tijden[6] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[7] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[8] + "-" + formattedEndTime + " Unavailable");
                    }

                    break;

                case "Thursday":
                    Console.WriteLine("--- Thursday ---");
                    Console.WriteLine("On Thursday the rooms are occupied at: ");

                    if (tempTime == opties[9])
                    {
                        Console.WriteLine(tijden[9] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[10] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[11] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[10])
                    {
                        Console.WriteLine(tijden[9] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[10] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[11] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[11])
                    {
                        Console.WriteLine(tijden[9] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[10] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[11] + "-" + formattedEndTime + " Unavailable");
                    }


                    break;

                case "Friday":
                    Console.WriteLine("--- Friday ---");
                    Console.WriteLine("On Friday the rooms are occupied at: ");


                    if (tempTime == opties[12])
                    {
                        Console.WriteLine(tijden[12] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[13] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[14] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[13])
                    {
                        Console.WriteLine(tijden[12] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[13] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[14] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[14])
                    {
                        Console.WriteLine(tijden[12] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[13] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[14] + "-" + formattedEndTime + " Unavailable");
                    }

                    break;

            }
            {
                Console.WriteLine("----------------------------------");


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
}