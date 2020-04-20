using System;

namespace ProjectB
{
    class escaperoomAvailability
    {
        static void Main()
        {
            Console.Clear();

            string EscapeRoom1Availability = "Available";
            string EscapeRoom2Availability = "Available";
            string EscapeRoom3Availability = "Available";
            string EscapeRoom4Availability = "Available";
            string EscapeRoom5Availability = "Available";


            Console.WriteLine("Select a room to check it's availability.\n");
            Console.WriteLine("1) Room 1\n");
            Console.WriteLine("2) Room 2\n");
            Console.WriteLine("3) Room 3\n");
            Console.WriteLine("4) Room 4\n");
            Console.WriteLine("5) Room 5\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Room 1 is: ");
                    Console.WriteLine(EscapeRoom1Availability);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Room 2 is: ");
                    Console.WriteLine(EscapeRoom2Availability);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Room 3 is: ");
                    Console.WriteLine(EscapeRoom3Availability);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Room 4 is: ");
                    Console.WriteLine(EscapeRoom4Availability);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Room 5 is: ");
                    Console.WriteLine(EscapeRoom5Availability);
                    break;
            }


            Console.WriteLine("Would you like to change the room's availability?\n");

            switch (Console.ReadLine())

            {
                case "yes":
                    Console.WriteLine("Room is now no longer available.");
                    break;
                case "no":
                    Console.WriteLine("N/A");
                    break;
            }
        }
    }
}



/*
 * Test voor later

bool A = false;
bool B = false;

Console.WriteLine("Enter input:");

			string jouwinput = Console.ReadLine();


			if (jouwinput == "A")
			{
				A = true;
				Console.WriteLine("A is True");
				Console.WriteLine("B is False");
			}
			else if (jouwinput == "B")
			{
				B = true;
				Console.WriteLine("A is False");
				Console.WriteLine("B is True");
			}
			else
			{
				Console.WriteLine("Start opnieuw");
			}

/
