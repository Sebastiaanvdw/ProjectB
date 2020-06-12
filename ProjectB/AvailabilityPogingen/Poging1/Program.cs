using System;

namespace TestAvailabilityUpdate
{
    class Program
    {

        static double Monday = 9.00;
        static double Tuesday = 9.00;
        static double Wednesday = 9.00;
        static double Thursday = 9.00;
        static double Friday = 9.00;
        // Hardcoded


        static double RoomDuration = 1.00;
        static double CleanUp = 0.5;

        static void Main(string[] args)
        {

            Console.Clear();

            Console.WriteLine("What day would you like to see?");
            
            switch (Console.ReadLine())
            {
                case "Monday":
                    Console.WriteLine("There is a room that starts at: ");
                    Console.WriteLine(Monday);
                    Console.WriteLine("And ends at: ");
                    Console.WriteLine(Monday + RoomDuration);

                    Console.WriteLine("----------------------------------");

                    Console.WriteLine("There is another room that starts at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp);
                    Console.WriteLine("And ends at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration);

                    Console.WriteLine("----------------------------------");

                    Console.WriteLine("There is another room that starts at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp);
                    Console.WriteLine("And ends at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration);

                    Console.WriteLine("There is another room that starts at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp);
                    Console.WriteLine("And ends at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration);

                    Console.WriteLine("There is another room that starts at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp);
                    Console.WriteLine("And ends at: ");
                    Console.WriteLine(Monday + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration + CleanUp + RoomDuration);

                    break;

                case "Tuesday":
                    Console.WriteLine("There is a room available at: ");
                    Console.WriteLine(Tuesday);
                    break;

                case "Wednesday":
                    Console.WriteLine("There is a room available at: ");
                    Console.WriteLine(Wednesday);
                    break;

                case "Thursday":
                    Console.WriteLine("There is a room available at: ");
                    Console.WriteLine(Thursday);
                    break;

                case "Friday":
                    Console.WriteLine("There is a room available at: ");
                    Console.WriteLine(Friday);
                    break;


            }











        }


            





        
    }
}
