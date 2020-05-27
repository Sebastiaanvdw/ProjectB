using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB;
using Y_or_N;

namespace BetaalPagina_Jelmer
{
    public class BetaalPagina
    {
        public static void payment()
        {
            int roomChoice = Functions.RoomChoice;
            //string roomPrice = ""; //Room Price P.P.
            //string userParticipants = ""; //MainProgramma.userParticipants
            //string Arrangements = ""; //Price Chosen Arrangements
            //string FoodAndDrinks = ""; //Price Chosen Food & Drinks
            //string SubTotal = ""; //SubTotal = (P.P. * Participants) + Food & Drinks + Arrangementen 
            
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("==============================");
            Console.WriteLine("Participants:            " + Functions.userParticipants);
            Console.WriteLine("==============================");
            Console.WriteLine("Room Price P.P.:         "  + "€" + MainProgram.RoomsList[roomChoice].roomPrice);
            Console.WriteLine("Total Participant Price: " + "€" + Functions.userParticipants * MainProgram.RoomsList[roomChoice].roomPrice);
            Console.WriteLine("Food & Drinks:           " + "€" + Functions.userFoodArrangementPrice);
            Console.WriteLine("============================== +");
            Console.WriteLine("Arrangements:            " + "€" + Functions.userArrangementPrice);
            Console.WriteLine("============================== -");
            Console.WriteLine("SubTotal:                " + "€" + Functions.userTotalPrice );
            Console.WriteLine("==============================" + "\n");

            Console.Write("Would you like to continue with your payment? Press ");
            Functions.Write("y", ConsoleColor.Yellow);
            Console.Write(" or ");
            Functions.Write("n", ConsoleColor.Yellow);
            bool Return = util.CheckYN();
            if (Return == true) {
                Console.Clear();
                Console.WriteLine("Choose your payment method of choice:" + "\n" + "1) iDEAL" + "\n" + "2) Paypal" + "\n" + "3) Creditcard" + "\n" + "4) Tikkie" + "\n" + "5) Return to previous menu");
                Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.Write("] on the keyboard");
                Functions.Write("\nYour input - ", ConsoleColor.Yellow);
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    string PaymentMethod = "iDEAL";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    Console.ReadKey();
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    string PaymentMethod = "Paypal";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    Console.ReadKey();
                }
                else if (input.Key == ConsoleKey.D3)
                {
                    string PaymentMethod = "Creditcard";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    Console.ReadKey();
                }
                else if (input.Key == ConsoleKey.D4)
                {
                    string PaymentMethod = "Tikkie";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                    Functions.WriteLine("\nYour payment was succesful!", ConsoleColor.Green);
                    Console.ReadKey();
                }
                else if (input.Key == ConsoleKey.D5)
                {
                    return;
                }
            }
            else if (Return == false) {
                Console.Clear();
                Functions.Write("Your payment has been cancelled!\n", ConsoleColor.Yellow);
            }

            //if (ContinuePayment == "Yes" || ContinuePayment == "yes")
            //{
            //    Console.Clear();
            //    Console.WriteLine("Choose your payment method of choice:" + "\n" + "1) iDEAL" + "\n" + "2) Paypal" + "\n" + "3) Creditcard" + "\n" + "4) Tikkie");
            //    string UserMethodChoice = Console.ReadLine();
            //    if (UserMethodChoice == "1")
            //    {
            //        string PaymentMethod = "iDEAL";
            //        Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
            //    }
            //    else if (UserMethodChoice == "2")
            //    {
            //        string PaymentMethod = "Paypal";
            //        Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
            //    }
            //    else if (UserMethodChoice == "3")
            //    {
            //        string PaymentMethod = "Creditcard";
            //        Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
            //    }
            //    else if (UserMethodChoice == "4")
            //    {
            //        string PaymentMethod = "Tikkie";
            //        Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
            //    }
            //    Functions.WriteLine("Your payment was succesful!\n", ConsoleColor.Green);
            //    //Console.WriteLine("Press any key to continue...");
            //    //Console.ReadKey();
            //    //Redirect to main menu
            //}
            //else if (ContinuePayment == "No" || ContinuePayment == "no")
            //{
            //    Console.Clear();
            //    Functions.WriteLine("Your payment has been cancelled!\n", ConsoleColor.Yellow);
            //    //Console.WriteLine("You will shortly be redirected to the main menu.");
            //    //Console.WriteLine("Press any key to continue...");
            //    //Console.ReadKey(true);
            //    //Redirect to main menu
            //}
        }
    }
}