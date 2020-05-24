using System;

namespace ConsoleApp1
{
    class Program
    {
        public static TimeSpan roomDuration = TimeSpan.Parse("1:00");
        public static TimeSpan cleanUp = TimeSpan.Parse("00:30");
        public static TimeSpan openingTime = TimeSpan.Parse("09:00");
        public static void Main()

        {



            TimeSpan endTime = roomDuration + openingTime;
            TimeSpan openingpluscleanup = openingTime + cleanUp;

            string formattedEndTime = endTime.ToString("hh\\:mm");
            string formattedOpeninTime = openingTime.ToString("hh\\:mm");
            string pluscleanup = openingpluscleanup.ToString("hh\\:mm");


            Console.Clear();


            Console.WriteLine("Day?");

            string Day = Console.ReadLine();

            Console.WriteLine("Time");

            //DateTime tempTime = Console.ReadLine();
            //string tempTime2 = tempTime.ToString("hh\\:mm");


            Console.WriteLine("-- Availability Escape Rooms --");
            Console.WriteLine("What day would you like to see?");
            Console.WriteLine("-------------------------------");




            switch (Console.ReadLine())

            {
                case "Monday":
                    Console.WriteLine("--- Monday ---");
                    Console.WriteLine("On Monday the rooms are occupied at: ");



                    break;


                case "Tuesday":
                    Console.WriteLine("--- Tuesday ---");
                    Console.WriteLine("On Tuesday the rooms are occupied at: ");

                    if (Day == "Tuesday")
                        Console.WriteLine("");


                    break;


                case "Wednesday":
                    Console.WriteLine("--- Wednesday---");
                    Console.WriteLine("On Wednesday the rooms are occupied at: ");

                    if (Day == "Wednesday")
                        Console.WriteLine("");

                    break;

                case "Thursday":
                    Console.WriteLine("--- Thursday ---");
                    Console.WriteLine("On Thursday the rooms are occupied at: ");

                    if (Day == "Thursday")
                        Console.WriteLine("");


                    break;

                case "Friday":
                    Console.WriteLine("--- Friday ---");
                    Console.WriteLine("On Tuesday the rooms are occupied at: ");

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