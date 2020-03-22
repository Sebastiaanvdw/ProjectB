using System;
using ProjectB.Crud;
using System.Collections.Generic;

namespace ProjectB
{
    class Program
    {
        public static void Main()  
        {
            EscapeRoom[] Rooms = 
                { 
                new EscapeRoom(1),
                new EscapeRoom(2),
                new EscapeRoom(3),
                new EscapeRoom(4),
                new EscapeRoom(5) 
            };

            Console.WriteLine("1: Add room\n2: Edit room\n3:Delete room");
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
            //escaperoom room1 = new escaperoom();
            //room1.roomnumber = 1;
            //room1.roomname = "horror";
            //room1.agelimit = 18;
            //room1.roomavailability = false;
            //room1.roomtheme = "deze escape room bestaat uit een horror thema met enge puzzels en evenementen.";
            //room1.roomduration = "1 uur";
            //room1.roomreview = "";
            //room1.roomprice = 23.95;
            //room1.roomsize = "3-5 mensen";

            //escaperoom room2 = new escaperoom("sci-fi");
            //room2.roomnumber = 2;
            //room2.roomprice = 23.95;
            //room2.roomsize = "3-5 mensen";
            //room2.agelimit = 12;
            //room2.roomavailability = false;
            //room2.roomtheme = "deze escape room bestaat uit een sci-fi thema waarbij veel aandacht wordt besteed aan sterren puzzels.";
            //room2.roomduration = "1 uur";
            //room2.roomreview = "";
            //room2.roomname = "sci-fi";

            //escaperoom room3 = new escaperoom("fantasy");
            //room3.roomnumber = 3;
            //room3.roomprice = 23.95;
            //room3.roomsize = "3-5 mensen";
            //room3.agelimit = 12;
            //room3.roomavailability = false;
            //room3.roomtheme = "deze escape room bestaat uit een fantasy thema waarbij veel aandacht wordt besteed aan oude klassieke puzzels.";
            //room3.roomduration = "1.5 uur";
            //room3.roomreview = "";
            //room3.roomname = "fantasy";

            //escaperoom room4 = new escaperoom("detective");
            //room4.roomnumber = 4;
            //room4.roomprice = 19.95;
            //room4.roomsize = "5 mensen";
            //room4.agelimit = 14;
            //room4.roomavailability = false;
            //room4.roomtheme = "deze escape room bestaat uit een detective thema waarbij veel oude moordzaken moeten worden opgelost.";
            //room4.roomduration = "30 minuten";
            //room4.roomreview = "";
            //room4.roomname = "detective";

            //escaperoom room5 = new escaperoom("aquatic");
            //room5.roomnumber = 5;
            //room5.roomprice = 35.95;
            //room5.roomsize = "4-6 mensen";
            //room5.agelimit = 12;
            //room5.roomavailability = false;
            //room5.roomtheme = "deze escape room bestaat uit een aquatic thema waarbij je veel kennis nodig hebt over de ocean en dergelijke.";
            //room5.roomduration = "1.5 uur";
            //room5.roomreview = "";
            //room5.roomname = "aquatic";

            //Console.Clear();
            //Console.WriteLine("Maak een keuze voor een Escape Room:");
            //Console.WriteLine("====================================");
            //Console.WriteLine(Room1.roomNumber + ") " + Room1.roomName + " " + Room1.ageLimit + "+\n");
            //Console.WriteLine(Room2.roomNumber + ") " + Room2.roomName + " " + Room2.ageLimit + "+\n");
            //Console.WriteLine(Room3.roomNumber + ") " + Room3.roomName + " " + Room3.ageLimit + "+\n");
            //Console.WriteLine(Room4.roomNumber + ") " + Room4.roomName + " " + Room4.ageLimit + "+\n");
            //Console.WriteLine(Room5.roomNumber + ") " + Room5.roomName + " " + Room5.ageLimit + "+\n");
            //Console.WriteLine("====================================\n");
            //Console.WriteLine("Escaperoom Admin opties:\n");
            //Console.WriteLine("6) Add new Escaperoom\n");
            //Console.WriteLine("7) Edit Escaperooms\n");
            //Console.WriteLine("8) Remove Escaperoom\n");

            //switch(Console.ReadLine())
            //{
            //    case "1":
            //        Console.Clear();
            //        Console.WriteLine(Room1.roomTheme);
            //        break;
            //    case "2":
            //        Console.Clear();
            //        Console.WriteLine(Room2.roomTheme);
            //        break;
            //    case "3":
            //        Console.Clear();
            //        Console.WriteLine(Room3.roomTheme);
            //        break;
            //    case "4":
            //        Console.Clear();
            //        Console.WriteLine(Room4.roomTheme);
            //        break;
            //    case "5":
            //        Console.Clear();
            //        Console.WriteLine(Room5.roomTheme);
            //        break;
            //    case "6": //addEscapeRoom()
            //        Console.Clear();
            //        Console.WriteLine("What is the room name?\n");
            //        //string x = Console.ReadLine("Samisannoying");
            //        //EscapeRoom  = new EscapeRoom(userInput);
            //        break;
            //    case "7": //editEscapeRoom()
            //          Console.Clear();
            //        Console.WriteLine("test 7");
            //        break;
            //    case "8": //removeEscapeRoom()
            //        Console.Clear();
            //        Console.WriteLine("Which room do you want to delete?");
            //        Console.WriteLine("====================================");
            //        Console.WriteLine(Room1.roomNumber + ") " + Room1.roomName + " " + Room1.ageLimit + "+\n");
            //        Console.WriteLine(Room2.roomNumber + ") " + Room2.roomName + " " + Room2.ageLimit + "+\n");
            //        Console.WriteLine(Room3.roomNumber + ") " + Room3.roomName + " " + Room3.ageLimit + "+\n");
            //        Console.WriteLine(Room4.roomNumber + ") " + Room4.roomName + " " + Room4.ageLimit + "+\n");
            //        Console.WriteLine(Room5.roomNumber + ") " + Room5.roomName + " " + Room5.ageLimit + "+\n");
            //        Console.WriteLine("====================================\n");
            //        Console.ReadLine();
            //        break;
            //}
            //Console.WriteLine("Terug naar het hoofdmenu?: (Ja of Nee)\n");

            //switch (Console.ReadLine())
            //{
            //    case "Ja":
            //        Main();
            //        break;
            //    case "ja":
            //        Main();
            //        break;
            //    case "Nee":
            //        break;
            //    case "nee":
            //        break;
            
           }
        }
    }

