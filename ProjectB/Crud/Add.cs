using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectB;

namespace ProjectB.Crud
{
	class Add
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			string userInput;
			bool priceSuccess= false;
			bool themeSuccess = false;
			bool minSuccess = false;
			bool maxSuccess = false;
			bool ageSuccess = false;
			bool durationSuccess = false;
			bool nameSuccess = false;


			if (RoomsList.Count >= 0 & RoomsList.Count < 5)
			{
				Console.Clear();
				RoomsList.Add(new EscapeRoom() { });
				int NewIndex = RoomsList.Count - 1;
				if (RoomsList.Count == 1) { NewIndex = 0; }
				RoomsList[NewIndex].roomNumber = NewIndex + 1;

				while (!ageSuccess)
				{
					Console.WriteLine("Enter the minimum age for the escape room:");
					userInput = Console.ReadLine();
					ageSuccess = int.TryParse(userInput, out int number);
					if (number < 12 || number > 100) { ageSuccess = false; }
					if (ageSuccess) { RoomsList[NewIndex].ageMinimum = number; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 12-100");
					}
				}

				while (!minSuccess)
				{
					Console.WriteLine("Enter the minimum amount of players for the escape room:");
					userInput = Console.ReadLine();
					minSuccess = int.TryParse(userInput, out int number);
					if (number < 2 || number > 5) { minSuccess = false; }
					if (minSuccess) { RoomsList[NewIndex].roomMinSize = number; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 2-5");
					}
				}

				while (!maxSuccess)
				{
					Console.WriteLine("Enter the maximum amount of players for the escape room:");
					userInput = Console.ReadLine();
					maxSuccess = int.TryParse(userInput, out int number);
					if (number <= RoomsList[NewIndex].roomMinSize || number > 6) { maxSuccess = false; }
					if (maxSuccess) { RoomsList[NewIndex].roomMaxSize = number; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a valid number inbetween " + (RoomsList[NewIndex].roomMinSize + 1) + "-6");
					}
				}


				while (!priceSuccess)
				{
					Console.WriteLine("Enter the price for the escape room:");
					userInput = Console.ReadLine();
					priceSuccess = Double.TryParse(userInput, out double number);
					if (priceSuccess) { RoomsList[NewIndex].roomPrice = number; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number.");
					}
				}

				while (!themeSuccess)
				{
					Console.WriteLine("Enter a theme for the escape room:");
					userInput = Console.ReadLine();
					themeSuccess = userInput.All(c => Char.IsLetter(c));
					if (string.IsNullOrEmpty(userInput)) { themeSuccess = false; }
					if (themeSuccess) { RoomsList[NewIndex].roomTheme = userInput; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please use alphabetic characters only");
					}
				}

				while (!durationSuccess)
				{
					Console.WriteLine("Enter the duration for the escape room (e.g. '2 Hours'):");
					userInput = Console.ReadLine();
					if (string.IsNullOrEmpty(userInput)) { durationSuccess = false; }
					else { durationSuccess = true; }
					if (durationSuccess) { RoomsList[NewIndex].roomDuration = userInput; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please try again");
					}
				}


				while (!nameSuccess)
				{
					Console.WriteLine("Enter a name for the escape room:");
					userInput = Console.ReadLine();
					if (string.IsNullOrEmpty(userInput)) { nameSuccess = false; }
					else { nameSuccess = true; }
					if (nameSuccess) { RoomsList[NewIndex].roomName = userInput; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please use alphabetic characters only");
					}
				}

				Functions.WriteLine("Room Complete!", ConsoleColor.Green);
			}

			else
			{
				Functions.WriteLine("There are already 5 EscapeRooms existing!", ConsoleColor.Red);
			}
			MainProgramma.ReturnMenuFunction();
		}
	}
}
