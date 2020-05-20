using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB;

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
            Console.WriteLine("==========================");
            Console.WriteLine("Room Price P.P.: " + MainProgram.RoomsList[roomChoice].roomPrice + "$");
            Console.WriteLine("Participants: " + Functions.userParticipants);
            Console.WriteLine("Arrangements: " + Functions.userArrangementPrice + "$");
            Console.WriteLine("Food & Drinks: " + Functions.userFoodArrangementPrice + "$");
            Console.WriteLine("-------------------- +" + "\n");
            Console.WriteLine("SubTotal: " + Functions.userTotalPrice + "$");
            Console.WriteLine("==========================" + "\n");

            Console.WriteLine("Do you want to continue with your payment?('Yes' or 'No')");
            string ContinuePayment = Console.ReadLine();

            if (ContinuePayment == "Yes" || ContinuePayment == "yes")
            {
                Console.Clear();
                Console.WriteLine("Choose your payment method of choice:" + "\n" + "1) iDEAL" + "\n" + "2) Paypal" + "\n" + "3) Creditcard" + "\n" + "4) Tikkie");
                string UserMethodChoice = Console.ReadLine();
                if (UserMethodChoice == "1")
                {
                    string PaymentMethod = "iDEAL";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                }
                else if (UserMethodChoice == "2")
                {
                    string PaymentMethod = "Paypal";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                }
                else if (UserMethodChoice == "3")
                {
                    string PaymentMethod = "Creditcard";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                }
                else if (UserMethodChoice == "4")
                {
                    string PaymentMethod = "Tikkie";
                    Console.WriteLine("Your chosen payment method is: " + PaymentMethod);
                }
                Functions.WriteLine("Your payment was succesful!\n", ConsoleColor.Green);
                //Console.WriteLine("Press any key to continue...");
                //Console.ReadKey();
                //Redirect to main menu
            }
            else if (ContinuePayment == "No" || ContinuePayment == "no")
            {
                Console.Clear();
                Functions.WriteLine("Your payment has been cancelled!\n", ConsoleColor.Yellow);
                //Console.WriteLine("You will shortly be redirected to the main menu.");
                //Console.WriteLine("Press any key to continue...");
                //Console.ReadKey(true);
                //Redirect to main menu
            }
        }
    }
}