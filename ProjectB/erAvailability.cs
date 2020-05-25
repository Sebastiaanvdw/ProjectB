using System;

namespace ConsoleApp1
{
    class Program
    {
        public static TimeSpan roomDuration = TimeSpan.Parse("1:00");
        public static TimeSpan cleanUp = TimeSpan.Parse("00:30");
        public static TimeSpan openingTime = TimeSpan.Parse("09:00");
        public static string[] tijden = new string[3] { "13:00", "15:00", "17:00" };
        public static string[] opties = new string[3] { "1", "2", "3" };
        public static string availability = " Available";
        public static string availability2 = " Available";
        public static string availability3 = " Available";

        public static void Main()

        {

            TimeSpan endTime = roomDuration + openingTime;
            TimeSpan openingpluscleanup = openingTime + cleanUp;


            string formattedEndTime = endTime.ToString("hh\\:mm");
            string formattedOpeninTime = openingTime.ToString("hh\\:mm");
            string pluscleanup = openingpluscleanup.ToString("hh\\:mm");


            Console.Clear();


            Console.WriteLine("Please select a day:");

            string Day = Console.ReadLine();

            Console.WriteLine("--- Time Options ---");

            Console.WriteLine("|" + opties[0] + "|" + tijden[0] + "\n" + "|" + opties[1] + "|" + tijden[1] + "\n" + "|" + opties[2] + "|" + tijden[2]);
            Console.WriteLine("Make an option to change the availability of a room:");
            string tempTime = Console.ReadLine();




            Console.WriteLine("-- Availability Escape Rooms --");
            Console.WriteLine("What day would you like to see?");
            Console.WriteLine("-------------------------------");




            switch (Console.ReadLine())

            {
                case "Monday":
                    Console.WriteLine("--- Monday ---");
                    Console.WriteLine("On Monday the rooms are occupied at: ");

                    Console.WriteLine(tijden[0] + "-" + formattedEndTime + availability);
                    Console.WriteLine(tijden[1] + "-" + formattedEndTime + availability2);
                    Console.WriteLine(tijden[2] + "-" + formattedEndTime + availability3);

                    if (tempTime == opties[0])
                    {
                        availability = " Unavailable";

                    }
                    if (tempTime == opties[1])
                    {
                        availability2 = " Unavailable";

                    }
                    if (tempTime == opties[2])
                    {
                        availability3 = " Unavailable";

                    }

                    break;


                case "Tuesday":
                    Console.WriteLine("--- Tuesday ---");
                    Console.WriteLine("On Tuesday the rooms are occupied at: ");

                    if (tempTime == opties[0])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[1])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[2])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Unavailable");
                    }

                    break;


                case "Wednesday":
                    Console.WriteLine("--- Wednesday---");
                    Console.WriteLine("On Wednesday the rooms are occupied at: ");

                    if (tempTime == opties[0])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[1])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Unavailable");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Available");
                    }
                    if (tempTime == opties[2])
                    {
                        Console.WriteLine(tijden[0] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[1] + "-" + formattedEndTime + " Available");
                        Console.WriteLine(tijden[2] + "-" + formattedEndTime + " Unavailable");
                    }

                    break;

                case "Thursday":
                    Console.WriteLine("--- Thursday ---");
                    Console.WriteLine("On Thursday the rooms are occupied at: ");

                    if (Day == "Thursday")
                        Console.WriteLine("");


                    break;

                case "Friday":
                    Console.WriteLine("--- Friday ---");
                    Console.WriteLine("On Friday the rooms are occupied at: ");

                    if (Day == "Friday")
                        Console.WriteLine("");


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