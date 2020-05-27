﻿using ProjectB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Y_or_N
{
    public class util
    {
        public static void test()
        {
            bool response = ReturnMenuYN();
        }

        public static bool ReturnMenuYN()
        {
            ConsoleKey response; // Creates a variable to hold the user's response.

            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();

                Console.Write("======================\nGo back to the menu?");
                Functions.WriteLine("\npress y or n", ConsoleColor.Yellow);// Asks the user to answer with 'Y' or 'N'.
                response = Console.ReadKey().Key; // Gets the user's response.
                Console.WriteLine(); // Breaks the line.
            } while (response != ConsoleKey.Y && response != ConsoleKey.N); // If the user did not respond with a 'Y' or an 'N', repeat the loop.

            /* 
             * Return true if the user responded with 'Y', otherwise false.
             * 
             * We know the response was either 'Y' or 'N', so we can assume 
             * the response is 'N' if it is not 'Y'.
             */
            return response == ConsoleKey.Y;
        }

        public static bool CheckML() //Method that only returns at a key input of M or L
        {
            ConsoleKey response; // Creates a variable to hold the user's response.

            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();

                Console.Write("======================\nExiting the current page, press "); util.Write("m", ConsoleColor.Yellow); Console.Write(" to return to the Menu, or press "); util.Write("l", ConsoleColor.Yellow); Console.Write(" to return to the login screen.\nYour input - ");


                response = Console.ReadKey().Key; // Gets the user's response.
                Console.WriteLine(); // Breaks the line.
            } while (response != ConsoleKey.M && response != ConsoleKey.L); // If the user did not respond with a 'Y' or an 'N', repeat the loop.

            return response == ConsoleKey.M;
        }

        public static void Write(object obj, ConsoleColor? color = null)
        {
            if (color != null)
                Console.ForegroundColor = color.Value;
            Console.Write(obj);
            Console.ResetColor();
        }

        public static bool CheckYN()
        {
            ConsoleKey response; // Creates a variable to hold the user's response.

            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();


                Functions.Write("\nYour input - ", ConsoleColor.Yellow);// Asks the user to answer with 'Y' or 'N'.
                response = Console.ReadKey().Key; // Gets the user's response.
                Console.WriteLine();
            } while (response != ConsoleKey.Y && response != ConsoleKey.N); // If the user did not respond with a 'Y' or an 'N', repeat the loop.

            /* 
             * Return true if the user responded with 'Y', otherwise false.
             * 
             * We know the response was either 'Y' or 'N', so we can assume 
             * the response is 'N' if it is not 'Y'.
             */
            return response == ConsoleKey.Y;
        }
        public static bool IsNullOrEmpty(string s)
        {
            if (String.IsNullOrEmpty(s))
                return true;
            else
                return false;
        }

        public static bool CheckCM()
        {
            ConsoleKey response; // Creates a variable to hold the user's response.

            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();


                Functions.Write("\nYour input - ", ConsoleColor.Yellow);// Asks the user to answer with 'Y' or 'N'.
                response = Console.ReadKey().Key; // Gets the user's response.

            } while (response != ConsoleKey.C && response != ConsoleKey.M); // If the user did not respond with a 'Y' or an 'N', repeat the loop.
            return response == ConsoleKey.C;
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }

        public static void Log(string s)
        {
            if (true)
            {
                bool flag = false;
                Console.Write("[");
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(GetTimestamp());
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("] [");
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write("Project-B");
                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine("] " + s);
                if (flag)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
