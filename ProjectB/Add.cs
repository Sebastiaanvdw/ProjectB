using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;

namespace ProjectB
{
	class Add
	{
		public static int roomNumber, ageMinimum, roomMinSize, roomMaxSize;
		public static double roomPrice;
		public static TimeSpan roomDuration;
		public static string roomTheme, roomName;

		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		public static void WriteToDatabase()
		{

			EscapeRoom escapeRoom = new EscapeRoom
			{
				RoomNumber = roomNumber,
				AgeMinimum = ageMinimum,
				RoomMinSize = roomMinSize,
				RoomMaxSize = roomMaxSize,
				RoomPrice = roomPrice,
				RoomTheme = roomTheme,
				RoomName = roomName,
				RoomDuration = roomDuration
			};

			escapeRoomsList.EscapeRooms.Add(escapeRoom);
			string json = JsonConvert.SerializeObject(escapeRoomsList, Formatting.Indented);
			File.WriteAllText(PathEscapeRoom, json);
		}
		public static void Function()
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

				if (escapeRoomsList.EscapeRooms.Count >= 0 & escapeRoomsList.EscapeRooms.Count < 5)
				{
					Console.Clear();
					int NewIndex = escapeRoomsList.EscapeRooms.Count - 1;
					if (escapeRoomsList.EscapeRooms.Count == 1) { NewIndex = 0; }
					roomNumber = NewIndex + 1;
					Console.WriteLine("-----------------------------");
					Console.WriteLine("Incase you want to return to the menu type: 'return'");
					Console.WriteLine("-----------------------------");
					while (!ageSuccess)
					{
						Console.WriteLine("Enter the minimum age for the escape room (between 12-100):");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else
						{
							ageSuccess = int.TryParse(userInput, out int number);
							if (number < 12 || number > 100) { ageSuccess = false; }
							if (ageSuccess) { ageMinimum = number; }
							else
							{
								Functions.ErrorMessage("Please enter a number between 12-100");
							}
						}
						
					}

					while (!minSuccess)
					{
						Console.WriteLine("Enter the minimum amount of players for the escape room (between 2-5):");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { escapeRoomsList.EscapeRooms.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else
						{
							minSuccess = int.TryParse(userInput, out int number);
							if (number < 2 || number > 5) { minSuccess = false; }
							if (minSuccess) { roomMinSize = number; }
							else
							{
								Functions.ErrorMessage("Please enter a number between 2-5");
							}
						}
						
					}

					while (!maxSuccess)
					{
						Console.WriteLine("Enter the maximum amount of players for the escape room (between"+ (roomMinSize + 1) + "-6):");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else
						{
							maxSuccess = int.TryParse(userInput, out int number);
							if (number <= roomMinSize || number > 6) { maxSuccess = false; }
							if (maxSuccess) { roomMaxSize = number; }
							else
							{
								Functions.ErrorMessage("Please enter a valid number between " + (RoomsList[NewIndex].roomMinSize + 1) + "-6");
							}
						}
					}


					while (!priceSuccess)
					{
						Console.WriteLine("Enter the price for the escape room (price is per participant):");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { escapeRoomsList.EscapeRooms.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else {
							priceSuccess = Double.TryParse(userInput, out double number);
							if (number < 0) { priceSuccess = false; }
							else if (userInput.Contains(".")) { priceSuccess = false; }
							if (priceSuccess) { roomPrice = Math.Round(number, 2); }
							else
							{
								Functions.ErrorMessage("Please enter a positive number");
							}
						}
					}

					while (!themeSuccess)
					{
						Console.WriteLine("Enter a theme for the escape room:");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { escapeRoomsList.EscapeRooms.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else {
							themeSuccess = userInput.All(c => Char.IsLetter(c));
							if (string.IsNullOrEmpty(userInput)) { themeSuccess = false; }
							if (themeSuccess) { roomTheme = userInput; }
							else
							{
								Functions.ErrorMessage("Please use alphabetic characters only");
							}
						}
						
					}

					while (!durationSuccess)
					{
						Console.WriteLine("Enter the duration for the escape room in hours(e.g. '2' or '1,5'):");
						userInput = Console.ReadLine();
						
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { escapeRoomsList.EscapeRooms.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else {
							durationSuccess = double.TryParse(userInput, out double number);
							if (number < 0 || number > 5) { durationSuccess = false; }
							else if (userInput.Contains(".")) { durationSuccess = false; }
							if (durationSuccess) { roomDuration = new TimeSpan(Convert.ToInt32(Math.Truncate(number)), Convert.ToInt32(Math.Round((number - Math.Truncate(number)) * 60)), 0); }
							else
							{
								Functions.ErrorMessage("Please try again");//idk of de 2 uur maximum is toegevoegd
							}
						}
					}

					while (!nameSuccess)
					{
						Console.WriteLine("Enter a name for the escape room:");
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							bool Return = util.ReturnToMenu();
							if (Return == true) { RoomsList.RemoveAt(NewIndex); return; }
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { escapeRoomsList.EscapeRooms.RemoveAt(NewIndex); return; }
							if (Return == false) { Console.WriteLine(""); LoopAddEscaperoom = false; }
						}
						else {
							if (string.IsNullOrEmpty(userInput)) { nameSuccess = false; }
							else { nameSuccess = true; }
							if (nameSuccess) { roomName = userInput; }
							else
							{
								Functions.ErrorMessage("Please use alphabetic characters only");
							}
						}
						
					}
					WriteToDatabase();
					Functions.WriteLine("Room Complete!", ConsoleColor.Green);
				}

				else
				{
					Functions.WriteLine("There are already 5 EscapeRooms existing!", ConsoleColor.Red);
				}
				if (escapeRoomsList.EscapeRooms.Count < 5)
				{
					Console.Write("Would you like to add another room?");
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
