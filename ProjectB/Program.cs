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

            Console.WriteLine("1: Add room\n2: Edit room\n3: Delete room");
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
           }
        }
    }

