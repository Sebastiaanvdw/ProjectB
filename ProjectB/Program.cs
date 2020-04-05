using System;
using ProjectB.Crud;
using System.Collections.Generic;

namespace ProjectB
{
    class Program
    {
        public static void Main()  
        {
            Console.Clear();
            EscapeRoom[] Rooms = 
                { 
                new EscapeRoom(1),
                new EscapeRoom(2),
                new EscapeRoom(3),
                new EscapeRoom(4),
                new EscapeRoom(5) 
            };

            Console.WriteLine("1: Add room\n2: Edit room\n3: Delete room\n4: Availability rooms\n5: Contact and F.A.Q.");
            string userInput = Console.ReadLine();

            if (userInput == "1") //AddRoom
            {
                bool availableRoom = isRoom(Rooms);
                if (!availableRoom) { Console.WriteLine("No available room spaces, sorry"); }
                else
                {
                    int roomNum = getNextRoom(Rooms);
                    Rooms[roomNum - 1].isTaken = true;

                    Console.WriteLine("Enter the minimum age (e.g 12) - \n");
                    string temp = Console.ReadLine();
                    int ageLimit;
                    Int32.TryParse(temp, out int eye);
                    { ageLimit = eye; }
                    Console.Clear();

                    Console.WriteLine("Enter the room price (e.g 24.95) - \n");
                    string temp2 = Console.ReadLine();
                    double roomPrice;
                    Double.TryParse(temp2, out double i);
                    { roomPrice = i; }
                    Console.Clear();

                    Console.WriteLine("Enter the availability (y/n) - \n");
                    string temp3 = Console.ReadLine();
                    bool roomAvailability;
                    bool.TryParse(temp3, out bool y);
                    { roomAvailability = y; }
                    Console.Clear();

                    Console.WriteLine("Enter the age roomSize (e.g 2-4) - \n");
                    string roomSize = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter the room Theme description (string) - \n");
                    string roomTheme = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter the room duration (e.g 1 hour) - \n");
                    string roomDuration = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter the room name - \n");
                    string roomName = Console.ReadLine();
                    Console.Clear();


                    Rooms[roomNum - 1].setNewValues(ageLimit, roomPrice, roomAvailability, roomSize, roomTheme, roomDuration, roomName);
                }              
            }

            else if(userInput == "2") //Edit
            {

            }

            else if (userInput == "2") //Delete
            {

            }

            else if (userInput == "4") //Available
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
                        Console.WriteLine("Kamer 1 is: ");
                        Console.WriteLine(EscapeRoom1Availability);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Kamer 2 is: ");
                        Console.WriteLine(EscapeRoom2Availability);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Kamer 3 is: ");
                        Console.WriteLine(EscapeRoom3Availability);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Kamer 4 is: ");
                        Console.WriteLine(EscapeRoom4Availability);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Kamer 5 is: ");
                        Console.WriteLine(EscapeRoom5Availability);
                        break;
                }


                Console.WriteLine("Wil je de beschikbaarheid van de kamer aanpassen?\n");

                switch (Console.ReadLine())

                {
                    case "ja":
                        Console.WriteLine("Kamer is nu niet langer beschikbaar.");
                        break;
                    case "nee":
                        Main();
                        break;
                }
            }

            if (userInput == "5"){
                Console.Clear();
                Console.WriteLine("Welcome to the Contact and F.A.Q. page.\nPlease select one of the options below:\n\n1: Contact information\n2: F.A.Q.\n");
                string userInputCFAQ = Console.ReadLine();

                if (userInputCFAQ == "1"){
                    Contact();
                }

                if (userInputCFAQ == "2")
                {
                    FAQ();
                }
            }

            static void Contact()
            {
                Console.Clear();
                Console.WriteLine("Opening hours:\nMon to Thurs: 9:00am - 5:00pm\nFriday: 9:00am - 7:00pm\n\nTelephone number: 01034235423\n\nE-mail: EscapeMail@rooms.com\n\nLocation: Janpieterstraat 49 Rotterdam 3546WQ\n\nWould you like to return to the main menu(1) or view our F.A.Q. page(2) or exit the program(3)?\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;
                    case "2":
                        FAQ();
                        break;
                    case "3":
                        break;
                }
            }

            static void FAQ()
            {
                String FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n\n";
                String FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n\n";
                String FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n\n";

                Console.Clear();
                Console.WriteLine(FAQ1 + FAQ2 + FAQ3 + "Would you like to return to the main menu(1) or view our Contact page(2) or exit the program(3)?\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;
                    case "2":
                        Contact();
                        break;
                    case "3":
                        break;
                }
            }

            static bool isRoom(EscapeRoom[] givenRooms) {
                for (int i = 0; i < givenRooms.Length; i++) {
                    if (!(givenRooms[i].isTaken)) { return true; }
                    
                }
                return false;
            }

            static int getNextRoom(EscapeRoom[] givenRooms)
        {
            //int availableRoom;
            for (int i = 0; i < givenRooms.Length; i++) {
                    if (!(givenRooms[i].isTaken)) { return givenRooms[i].roomNumber; }
            }
            return -1;
        }            
           }
    }
    }

