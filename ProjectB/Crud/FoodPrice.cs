using System;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;

namespace ProjectB.Crud
{
    class FoodPrice
    {
        public static void Editmenu()
        {
            string userInput;
            int EditFoodChoice = 0;
            double drinksPrice = Functions.drinksPrice;
            double foodPrice = Functions.foodPrice;
            double foodAndDrinksPrice = Functions.foodAndDrinksPrice;
            bool foodSuccess = false;
            bool drinksSuccess = false;
            bool foodAndDrinksSuccess = false;
            bool menuEditSuccess = false;

            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Incase you want to return to the menu type: 'return'");
            Console.WriteLine("-----------------------------\nThese are the current prices for our food arrangements.");
            Console.WriteLine("1) Drinks $" + drinksPrice);
            Console.WriteLine("2) Food $" + foodPrice);
            Console.WriteLine("3) Food and Drinks $" + foodAndDrinksPrice + "\n-----------------------------\n");

            Console.WriteLine("Choose the menu item that you want to edit(use 1-3)");
            while (!menuEditSuccess)
            {
                userInput = Console.ReadLine();
                if (userInput == "return")
                {
                    Console.Write("Would you like to return to the menu, press ");
                    Functions.Write("y", ConsoleColor.Yellow);
                    Console.Write(" or ");
                    Functions.Write("n", ConsoleColor.Yellow);
                    bool Return = util.CheckYN();
                    if (Return == true) { menuEditSuccess = true; return; }
                    if (Return == false) { Console.WriteLine(""); Editmenu(); }
                }
                else
                {
                    menuEditSuccess = int.TryParse(userInput, out int number);
                    if (number < 1 || number > 3) { menuEditSuccess = false; }
                    if (menuEditSuccess) { EditFoodChoice = number; }
                    else
                    {
                        Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
                        Console.WriteLine("Please enter a number between 1 and 3");
                    }
                }
            }
            if (EditFoodChoice == 1)
            {
                while (!drinksSuccess)
                {
                    Console.WriteLine("Enter a price for the drinks arrangement:");
                    userInput = Console.ReadLine();
                    if (userInput == "return")
                    {
                        Console.Write("Would you like to return to the menu, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { drinksSuccess = true; return; }
                        if (Return == false) { Console.WriteLine(""); Editmenu(); }
                    }
                    else
                    {
                        drinksSuccess = double.TryParse(userInput, out double number);
                        if (drinksSuccess) { Functions.drinksPrice = number; }
                        else
                        {
                            Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
                            Console.WriteLine("Please use digits only");
                        }
                        Console.Write("Would you like to edit another menu item, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { Editmenu(); }
                        if (Return == false) { return; }
                    }
                }
            }
            else if (EditFoodChoice == 2)
            {
                while (!foodSuccess)
                {
                    Console.WriteLine("Enter a price for the food arrangement:");
                    userInput = Console.ReadLine();

                    if (userInput == "return")
                    {
                        Console.Write("Would you like to return to the menu, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { foodSuccess = true; return; }
                        if (Return == false) { Console.WriteLine(""); Editmenu(); }
                    }
                    else
                    {
                        foodSuccess = double.TryParse(userInput, out double number);
                        if (foodSuccess) { Functions.foodPrice = number; }
                        else
                        {
                            Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
                            Console.WriteLine("Please use digits only");
                        }
                        Console.Write("Would you like to edit another menu item, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { Editmenu(); }
                        if (Return == false) { return; }
                    }
                }
            }
            else if (EditFoodChoice == 3)
            {
                while (!foodAndDrinksSuccess)
                {
                    Console.WriteLine("Enter a price for the food and drinks arrangement:");
                    userInput = Console.ReadLine();
                    if (userInput == "return")
                    {
                        Console.Write("Would you like to return to the menu, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { foodAndDrinksSuccess = true; return; }
                        if (Return == false) { Console.WriteLine(""); Editmenu(); }
                    }
                    else
                    {
                        foodAndDrinksSuccess = double.TryParse(userInput, out double number);
                        if (foodAndDrinksSuccess) { Functions.foodAndDrinksPrice = number; }
                        else
                        {
                            Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
                            Console.WriteLine("Please use digits only");
                        }
                        Console.Write("Would you like to edit another menu item, press ");
                        Functions.Write("y", ConsoleColor.Yellow);
                        Console.Write(" or ");
                        Functions.Write("n", ConsoleColor.Yellow);
                        bool Return = util.CheckYN();
                        if (Return == true) { Editmenu(); }
                        if (Return == false) { return; }
                    }
                }
            }
            
        }  
    }
}
