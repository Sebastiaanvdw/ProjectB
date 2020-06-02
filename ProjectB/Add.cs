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
		public static int roomNumber, ageMinimum, roomMinSize, roomMaxSize, userID;
		public static double roomPrice;
		public static TimeSpan roomDuration;
		public static string roomTheme, roomName, input_message, error_message, userName, firstName, lastName, password, streetName, houseNumber, postalCode, residencyName, email, phoneNumber;

		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
		
		public static void EscapeRoomWriteToDatabase()
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
		public static void UserWriteToDatabase()
		{
			User user = new User
			{
				UserID = userID,
				UserName = userName,
				UserPassword = password,
				UserFirstName = firstName,
				UserLastName = lastName,
				UserPostalCode = postalCode,
				UserStreetName = streetName,
				UserHouseNumber = houseNumber,
				UserResidencyName = residencyName,
				UserEmail = email,
				UserPhoneNumber = phoneNumber,
				UserRole = "customer"
			};
			usersList.Users.Add(user);
			string json = JsonConvert.SerializeObject(usersList, Formatting.Indented);
			File.WriteAllText(PathUser, json);
		}
		public static void Function()
		{
			bool LoopAddFunction = false;
			while (!LoopAddFunction)
			{
				Console.Clear();
				Console.WriteLine("=======================================\nWelcome to the Add page.\n=======================================\n1) Add an escape room\n2) Add an user\n3) Return to menu\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("3", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
				Functions.Write("Your input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { AddEscapeRoom(); }
				else if (input.Key == ConsoleKey.D2) { AddUser();  }
				else if (input.Key == ConsoleKey.D3) { return; }
				else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
			}
		}
		public static void AddEscapeRoom()
		{
			bool LoopAddEscapeRoom = true;
			while (LoopAddEscapeRoom)
			{
				bool durationSuccess = false;
				string userInput;
				int NewIndex = escapeRoomsList.EscapeRooms.Count - 1;
				if (escapeRoomsList.EscapeRooms.Count == 1) { NewIndex = 0; }
				roomNumber = NewIndex + 1;
				Console.Clear();
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Please fill in the information required for an escape room:");
				Console.WriteLine("-----------------------------");

				input_message = "Enter the minimum age for the escape room(between 12 - 100):";
				error_message = "Please enter a number between 12 and 100.";
				ageMinimum = Error_Exception_Int(input_message, error_message, 12, 100);

				input_message = "Enter the minimum amount of players for the escape room (between 2-5):";
				error_message = "Please enter a number between 2-5";
				roomMinSize = Error_Exception_Int(input_message, error_message, 2, 5);

				input_message = "Enter the maximum amount of players for the escape room (between" + (roomMinSize + 1) + "-6):";
				error_message = "Please enter a valid number inbetween " + (roomMinSize + 1) + "-6";
				roomMaxSize = Error_Exception_Int(input_message, error_message, (roomMinSize + 1), 6);

				input_message = "Enter the price for the escape room (price is per participant):";
				error_message = "Please enter a positive number.";
				roomPrice = Error_Exception_Double(input_message, error_message, 1, 99999);

				input_message = "Enter a theme for the escape room:";
				error_message = "Please use alphabetic characters only";
				roomTheme = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

				while (!durationSuccess)
				{
					Console.WriteLine("Enter the duration for the escape room in hours(e.g. '2' or '1,5'):");
					userInput = Console.ReadLine();
					durationSuccess = double.TryParse(userInput, out double number);
					if (number < 0 || number > 5) { durationSuccess = false; }
					else if (userInput.Contains(".")) { durationSuccess = false; }
					if (durationSuccess) { roomDuration = new TimeSpan(Convert.ToInt32(Math.Truncate(number)), Convert.ToInt32(Math.Round((number - Math.Truncate(number)) * 60)), 0); }
					else
					{
						Functions.Error();
						Console.WriteLine("Please try again");
					}
					
				}

				input_message = "Enter a name for the escape room:";
				error_message = "Please use alphabetic characters only";
				roomName = Error_Exception_String(input_message, error_message, false, true, 0, 0, false, "", "");

				EscapeRoomWriteToDatabase();
				Console.Clear();
				Console.Write("Would you like to add another escape room?");
				bool Return = util.CheckYN();
				if (Return == true) { }
				if (Return == false) { LoopAddEscapeRoom = false; return; }
			}
		}
		public static void AddUser()
		{
			bool LoopAddUser = true;
			while (LoopAddUser)
			{
				int NewIndex = usersList.Users.Count;
				if (usersList.Users.Count == 1) { NewIndex = 0; }
				userID = NewIndex + 1;
				Console.Clear();
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Please the required information:");
				Console.WriteLine("-----------------------------");

				input_message = "Enter your username:";
				error_message = "Please enter a valid username";
				userName = Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "");

				input_message = "Enter your password:";
				error_message = "Please enter a valid password";
				password = Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "");

				input_message = "Enter your first name:";
				error_message = "Please enter a valid first name";
				firstName = Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "");

				input_message = "Enter your last name:";
				error_message = "Please enter a valid last name";
				lastName = Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "");

				input_message = "Enter your street name:";
				error_message = "Please enter a valid street name";
				streetName = Error_Exception_String(input_message, error_message, false, false, 1, 100, true, "", "");

				input_message = "Enter your house number:";
				error_message = "Please enter a number between 1 and 99999";
				houseNumber = Error_Exception_Int(input_message, error_message, 1, 99999).ToString();

				input_message = "Enter the first four digits of your postal code:";
				error_message = "Please enter a valid postal code";
				postalCode= Error_Exception_String(input_message, error_message, true, true, 4, 4, false, "", "");

				input_message = "Enter the last two letters of your postal code: ";
				error_message = "Please enter two letters";
				postalCode += Error_Exception_String(input_message, error_message, false, true, 2, 2, false, "", "").ToUpper();

				input_message = "Enter the name of your place of residence:";
				error_message = "Please enter a valid place of residence";
				residencyName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

				input_message = "Enter your e-mail address:";
				error_message = "Please enter a valid e-mail address";
				email = Error_Exception_String(input_message, error_message, false, false, 0, 0, true, "@", ".");

				input_message = "Enter your telephonenumber:";
				error_message = "Please enter a valid telephonenumber";
				phoneNumber = Error_Exception_String(input_message, error_message, true, true, 10, 10, false, "", "");

				UserWriteToDatabase();
				Console.Clear();
				Console.Write("Would you like to add another user?");
				bool Return = util.CheckYN();
				if (Return == true) { }
				if (Return == false) { LoopAddUser = false; return; }
			}
		}
		public static string Error_Exception_String(string message, string errormessage, bool isanumber, bool lengthmatters, int minlength, int maxlength, bool specialcontain, string contains1, string contains2)
		{
			string userInput = "";
			bool Succes = false;
			while (!Succes)
			{
				Console.WriteLine(message);
				userInput = Console.ReadLine();
				if (string.IsNullOrEmpty(userInput)) { Succes = false; }
				else if (!isanumber && userInput.Any(char.IsDigit)) { Succes = false; }
				else if (isanumber && !userInput.Any(char.IsDigit)) { Succes = false; }
				else if (lengthmatters && (userInput.Length < minlength || userInput.Length > maxlength)) { Succes = false; }
				else if (specialcontain && !userInput.Contains(contains1) || !userInput.Contains(contains2)) { Succes = false; }
				else if (userInput.Length < 5 && userInput.Contains(" ")) { Succes = false; }
				else { Succes = true; }
				if (Succes) { }
				else
				{
					Functions.ErrorMessage(errormessage);
				}
			}
			return userInput;
		}
		public static int Error_Exception_Int(string message, string errormessage, int minlength, int maxlength)
		{
			string userInput = "";
			bool Succes = false;
			while (!Succes)
			{
				Console.WriteLine(message);
				userInput = Console.ReadLine();
				Succes = int.TryParse(userInput, out int number);
				if (number >= minlength && number <= maxlength) { Succes = true; }
				else { Succes = false; }
				if (Succes) { }
				else
				{
					Functions.ErrorMessage(errormessage);
				}
			}
			return Int32.Parse(userInput);
		}
		public static double Error_Exception_Double(string message, string errormessage, int minlength, int maxlength)
		{
			string userInput = "";
			bool Succes = false;
			while (!Succes)
			{
				Console.WriteLine(message);
				userInput = Console.ReadLine();
				Succes = Double.TryParse(userInput, out double number);
				if (number >= minlength && number <= maxlength) { Succes = true; }
				else if (userInput.Contains(".")) { Succes = false; }
				if (Succes) { }
				else
				{
					Functions.ErrorMessage(errormessage);
				}
			}
			return Double.Parse(userInput);
		}
	}
}
