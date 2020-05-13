using System;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;


namespace ProjectB.Crud
{
	class Add
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			bool LoopAddEscaperoom = true;
			while (LoopAddEscaperoom)
			{
				string userInput;
				bool priceSuccess = false;
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
						Console.WriteLine("Enter the minimum age for the escape room (between 12-100):");
						userInput = Console.ReadLine();
						ageSuccess = int.TryParse(userInput, out int number);
						if (number < 12 || number > 100) { ageSuccess = false; }
						if (ageSuccess) { RoomsList[NewIndex].ageMinimum = number; }
						else
						{
							Functions.Error();
							Console.WriteLine("Please enter a number between 12-100");
						}
					}

					while (!minSuccess)
					{
						Console.WriteLine("Enter the minimum amount of players for the escape room (between 2-5):");
						userInput = Console.ReadLine();
						minSuccess = int.TryParse(userInput, out int number);
						if (number < 2 || number > 5) { minSuccess = false; }
						if (minSuccess) { RoomsList[NewIndex].roomMinSize = number; }
						else
						{
							Functions.Error();
							Console.WriteLine("Please enter a number between 2-5");
						}
					}

					while (!maxSuccess)
					{
						Console.WriteLine("Enter the maximum amount of players for the escape room (between "+ (RoomsList[NewIndex].roomMinSize + 1) + "-6):");
						userInput = Console.ReadLine();
						maxSuccess = int.TryParse(userInput, out int number);
						if (number <= RoomsList[NewIndex].roomMinSize || number > 6) { maxSuccess = false; }
						if (maxSuccess) { RoomsList[NewIndex].roomMaxSize = number; }
						else
						{
							Functions.Error();
							Console.WriteLine("Please enter a valid number inbetween " + (RoomsList[NewIndex].roomMinSize + 1) + "-6");
						}
					}


					while (!priceSuccess)
					{
						Console.WriteLine("Enter the price for the escape room (price is per participant):");
						userInput = Console.ReadLine();
						priceSuccess = Double.TryParse(userInput, out double number);
						if (number < 0) { priceSuccess = false; }
						if (priceSuccess) { RoomsList[NewIndex].roomPrice = Math.Round(number, 2); }
						else
						{
							Functions.Error();
							Console.WriteLine("Please enter a positive number.");
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
							Functions.Error();
							Console.WriteLine("Please use alphabetic characters only");
						}
					}

					while (!durationSuccess)
					{
						Console.WriteLine("Enter the duration for the escape room in hours(e.g. '2'):");
						userInput = Console.ReadLine();
						durationSuccess = double.TryParse(userInput, out double number);
						if (number < 0 || number > 5) { durationSuccess = true; }
						if (durationSuccess) { RoomsList[NewIndex].roomDuration = Math.Truncate(number).ToString() + " hour(s) and " + Math.Round((number - Math.Truncate(number))*60).ToString() + " minutes"; }
						else
						{
							Functions.Error();
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
							Functions.Error();
							Console.WriteLine("Please use alphabetic characters only");
						}
					}
					Functions.WriteLine("Room Complete!", ConsoleColor.Green);
				}

				else
				{
					Functions.WriteLine("There are already 5 EscapeRooms existing!", ConsoleColor.Red);
				}
				if (RoomsList.Count < 5)
				{
					Console.Write("Would you like to add another room, press ");
					Functions.Write("y", ConsoleColor.Yellow);
					Console.Write(" or ");
					Functions.Write("n", ConsoleColor.Yellow);
					bool Return = util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopAddEscaperoom = false; }
				}
				else
				{
					return;
				}
			}
		}
	}
}
