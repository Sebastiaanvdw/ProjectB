using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
    public class BetaalPagina
    {
        private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
        private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

        public static string PaymentMethod = "";
        public static bool PaymentSuccess = false;
        public static void Payment()
        {
            int roomChoice = Add.RoomChoice;
            PaymentSuccess = false;

            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("==============================");
            Console.WriteLine("Participants:            " + Add.userParticipants);
            Console.WriteLine("Room Price P.P.:         " + "€" + Math.Round(escapeRoomsList.EscapeRooms[roomChoice].RoomPrice, 2));
            Console.WriteLine("==============================");
            Console.WriteLine("Total Participant Price: " + "€" + Math.Round((Add.userParticipants * escapeRoomsList.EscapeRooms[roomChoice].RoomPrice), 2));
            Console.WriteLine("Food & Drinks:           " + "€" + Math.Round(Functions.userFoodArrangementPrice, 2));
            Console.WriteLine("============================== +");
            Console.WriteLine("Arrangements:            " + "€" + Math.Round(Functions.userArrangementPrice, 2));
            Console.WriteLine("============================== -");
            Console.WriteLine("SubTotal:                " + "€" + Math.Round(Functions.userTotalPrice, 2));
            Console.WriteLine("==============================" + "\n");

            Console.Write("Would you like to continue with your payment?");
            bool Return = Util.CheckYN();
            if (Return == true)
            {
                Console.Clear();
                Console.WriteLine("Choose your payment method of choice:" + "\n" + "1) iDEAL" + "\n" + "2) Paypal" + "\n" + "3) Creditcard" + "\n" + "4) Tikkie" + "\n" + "5) Return to previous menu");
                Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.Write("] on the keyboard");
                Functions.Write("\nYour input - ", ConsoleColor.Yellow);
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    PaymentMethod = "iDEAL";
                    Console.WriteLine("\nYour chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    PaymentSuccess = true;
                    Functions.ATC();
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    PaymentMethod = "Paypal";
                    Console.WriteLine("\nYour chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    PaymentSuccess = true;
                    Functions.ATC();
                }
                else if (input.Key == ConsoleKey.D3)
                {
                    PaymentMethod = "Creditcard";
                    Console.WriteLine("\nYour chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    PaymentSuccess = true;
                    Functions.ATC(); 
                }
                else if (input.Key == ConsoleKey.D4)
                {
                    PaymentMethod = "Tikkie";
                    Console.WriteLine("\nYour chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    PaymentSuccess = true;
                    Functions.ATC();
                }
                else if (input.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    Functions.Write("\nYour payment has been cancelled!\n", ConsoleColor.Red);
                    Functions.ATC();
                    return;
                }
            }
            else if (Return == false)
            {
                Console.Clear();
                Functions.Write("\nYour payment has been cancelled!\n", ConsoleColor.Red);
                Functions.ATC();
                return;
            }
        }
    }
}