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
		public static int roomNumber, ageMinimum, roomMinSize, roomMaxSize, userID, RoomChoice, userParticipants, userFoodArrangement, userArrangement, reservationNumber;
		public static double roomPrice;
		public static TimeSpan roomDuration;
		public static string roomTheme, roomName, input_message, error_message, userName, firstName, lastName, password, streetName, houseNumber, userUniqueID, postalCode, residencyName, email, phoneNumber, resUserName, userLastName, userPostcode, userStreet, userResidency, userHouseNumber, userEmail, userPhoneNumber, userFoodString, userArrangementString;

		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static readonly JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

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
		public static void ReservationWriteToDatabase()
		{

			Reservation reservation = new Reservation
			{
				ReservationNumber = reservationNumber,
				UniqueID = userUniqueID,
				ResRoomName = escapeRoomsList.EscapeRooms[RoomChoice].RoomName,
				FirstName = resUserName,
				LastName = userLastName,
				PostalCode = userPostcode,
				StreetName = userStreet,
				HouseNumber = userHouseNumber,
				ResidencyName = userResidency,
				Email = userEmail,
				PhoneNumber = userPhoneNumber,
				Participants = userParticipants,
				FoodArrangement = userFoodString,
				Arrangement = userArrangementString,
				TotalPrice = Functions.userTotalPrice,
				PaymentMethod = BetaalPagina.PaymentMethod
			};

			reservationsList.Reservations.Add(reservation);
			string json = JsonConvert.SerializeObject(reservationsList, Formatting.Indented);
			File.WriteAllText(PathReservation, json);
		}
		public static void Function()
		{
			bool LoopAddFunction = false;
			while (!LoopAddFunction)
			{
				Console.Clear();
				Console.WriteLine("=======================================\nWelcome to the Add page.\n=======================================\n1) Add an escape room\n2) Add an user\n3) Add a reservation\n4) Return to menu\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("4", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
				Functions.Write("Your input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { AddEscapeRoom(); }
				else if (input.Key == ConsoleKey.D2) { AddUser();  }
				else if (input.Key == ConsoleKey.D3) { AddReservation(); }
				else if (input.Key == ConsoleKey.D4) { return; }
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
				Console.WriteLine("Your userID: " + userID );
				Console.WriteLine("Your username: " + userName);
				Console.WriteLine("Your password: " + password);
				Console.Write("Would you like to register another user?");
				bool Return = util.CheckYN();
				if (Return == true) { }
				if (Return == false) { LoopAddUser = false; return; }
			}
		}
		public static void AddReservation()
		{
			File.ReadAllText(PathReservation);
			bool LoopAddReservation = true;
			while (LoopAddReservation)
			{
				Console.Clear();
				if (escapeRoomsList.EscapeRooms.Count < 1)
				{
					Console.WriteLine("No escaperooms have been added yet so you can't make a reservation yet, you will be returned to the menu.");
					Console.ReadKey(true);
					return;
				}
				else
				{
					int NewIndex = reservationsList.Reservations.Count;
					reservationNumber = NewIndex + 1;
					Console.WriteLine("-----------------------------");
					Console.WriteLine("Incase you want to return to the menu type: 'return'"); //MOEt DIT WORDEN TOEGEVOEGD???
					Console.WriteLine("-----------------------------");
					Console.WriteLine("Please choose your room and fill in the information required:");
					Console.WriteLine("-----------------------------");
					Console.WriteLine("For which of the following rooms would you like to make a reservation? (choose a number between 1" + "-" + escapeRoomsList.EscapeRooms.Count + ")"); // Tussen 1-5

					for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++) { Console.WriteLine(escapeRoomsList.EscapeRooms[i].RoomNumber + " - " + escapeRoomsList.EscapeRooms[i].RoomName + "(" + escapeRoomsList.EscapeRooms[i].RoomMinSize + "-" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + ")"); }

					input_message = "\nRoom:";
					error_message = "Please enter a number between 1 and " + escapeRoomsList.EscapeRooms.Count;
					RoomChoice = Error_Exception_Int(input_message, error_message, 1, escapeRoomsList.EscapeRooms.Count) - 1;

					input_message = "Fill in your first name(e.g. 'Piet'):";
					error_message = "Please enter a valid name";
					resUserName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", ""); //(message, errorMessage, is it a number, does the length matter, minimum length, maximum length

					input_message = "Fill in your last name(e.g. 'de Koning'):";
					error_message = "Please enter a valid name last";
					userLastName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

					input_message = "Fill in the first four digits of your postcode:";
					error_message = "Please enter a valid postcode";
					userPostcode = Error_Exception_String(input_message, error_message, true, true, 4, 4, false, "", "");

					input_message = "Fill in the last two letters of your postcode: ";
					error_message = "Please fill two letters";
					userPostcode += Error_Exception_String(input_message, error_message, false, true, 2, 2, false, "", "").ToUpper();

					input_message = "Fill in your street(e.g. 'Tulpenlaan'):";
					error_message = "Please enter a valid street name";
					userStreet = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

					input_message = "Fill in your housenumber(e.g. '98'):";
					error_message = "Please enter a valid housenumber";
					userHouseNumber = Error_Exception_Int(input_message, error_message, 1, 2000).ToString();

					input_message = "Fill in your place of residence(e.g. 'Pijnacker'):";
					error_message = "Please enter a valid place of residence";
					userResidency = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

					input_message = "Fill in your email(e.g. 'voorbeeld@mail.com'):";
					error_message = "Please enter a valid Email adress";
					userEmail = Error_Exception_String(input_message, error_message, false, false, 0, 0, true, "@", ".");

					input_message = "Fill in your telephonenumber(e.g. '0676319854'):";
					error_message = "Please enter a valid Phonenumber";
					userPhoneNumber = Error_Exception_String(input_message, error_message, true, true, 10, 10, false, "", "");

					input_message = "Fill in how many participants there will be (" + escapeRoomsList.EscapeRooms[RoomChoice].RoomMinSize + "-" + escapeRoomsList.EscapeRooms[RoomChoice].RoomMaxSize + ")";
					error_message = "Please enter a valid number of participants";
					userParticipants = Error_Exception_Int(input_message, error_message, escapeRoomsList.EscapeRooms[RoomChoice].RoomMinSize, escapeRoomsList.EscapeRooms[RoomChoice].RoomMaxSize);

					input_message = "Fill in which food arrangment you want (1. none, 2. just food, 3. just drinks or 4. food and drinks):";
					error_message = "Please enter a number between 1 and 4";
					userFoodArrangement = Error_Exception_Int(input_message, error_message, 1, 4);

					input_message = "Fill in the number of the arrangment that you want( 1. none, 2. kids party, 3. ladies night or 4. work outing):";
					error_message = "Please enter a number between 1 and 4";
					userArrangement = Error_Exception_Int(input_message, error_message, 1, 4);

					Console.Clear();
					if (userArrangement != 0)
					{
						Functions.TotalPrice();
						Functions.ReceiptFunction();
						Console.Write("Would you like to add another reservation?");
						bool Return = util.CheckYN();
						if (Return == true) { }
						if (Return == false) { LoopAddReservation = false; return; }
					}
				}
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
