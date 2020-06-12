using ProjectB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Y_or_N
{
    public class Util
    {
        public static bool CheckYN()
        {
            ConsoleKey response; // Creates a variable to hold the user's response.
        
            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();
                Console.Write(" Press ");  Functions.Write("y", ConsoleColor.Yellow); Console.Write(" or "); Functions.WriteLine("n", ConsoleColor.Yellow); Functions.Write("Your input - ", ConsoleColor.Yellow);// Asks the user to answer with 'Y' or 'N'.
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
        public static bool ReturnToMenu()
        {
            ConsoleKey response; // Creates a variable to hold the user's response.

            do
            {
                while (Console.KeyAvailable) // Flushes the input queue.
                    Console.ReadKey();
                Console.Write("Would you like to return to the menu? Press "); Functions.Write("y", ConsoleColor.Yellow); Console.Write(" or "); Functions.WriteLine("n", ConsoleColor.Yellow); Functions.Write("Your input - ", ConsoleColor.Yellow);// Asks the user to answer with 'Y' or 'N'.
                response = Console.ReadKey().Key; // Gets the user's response.
                Console.WriteLine();
            } while (response != ConsoleKey.Y && response != ConsoleKey.N); 

            return response == ConsoleKey.Y;
        }
    }
}
