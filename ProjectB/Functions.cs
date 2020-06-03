using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;



namespace ProjectB
{
	class Functions
	{
		public static string input_message, error_message;
		public static double userTotalPrice, userFoodArrangementPrice, userArrangementPrice;
		public static bool LoopContactFunction = false;

		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static readonly JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

		private static readonly string PathMenu = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"MenuDatabase.json");
		private static readonly JSONMenuList menusList = JsonConvert.DeserializeObject<JSONMenuList>(File.ReadAllText(PathMenu));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
		public static void Contact()
		{
			Console.Clear();
			Console.WriteLine("=======================================\nOpening hours:\nMonday through Friday:	9:00am - 5:00pm\n\nTelephone number:	01034235423\nE-mail:			EscapeMail@rooms.com\nAddress:		Janpieterstraat 49 3546WQ Rotterdam\n=======================================\n");
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void FAQ()
		{
			string FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n";
			string FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n";
			string FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n=======================================\n";

			Console.Clear();
			Console.WriteLine("=======================================");
			Console.WriteLine(FAQ1 + "\n" + FAQ2 + "\n" + FAQ3);
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void ReceiptFunction()
		{
			while (true)
			{
				Add.userUniqueID = Guid.NewGuid().ToString();
				if (!MainProgram.IDList.Contains(Add.userUniqueID))
				{
					MainProgram.IDList.Add(Add.userUniqueID);
					break;
				}
			}

			Console.Clear();
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("============================================");
			Console.WriteLine("The following room has been chosen: " + escapeRoomsList.EscapeRooms[Add.RoomChoice].RoomName);
			Console.WriteLine("\nAmount of participants: " + Add.userParticipants);
			Console.WriteLine("============================================");
			Console.WriteLine("Name:			" + Add.resUserName + " " + Add.userLastName);
			Console.WriteLine("Street:			" + Add.userStreet + " " + Add.userHouseNumber);
			Console.WriteLine("Postalcode:		" + Add.userPostcode);
			Console.WriteLine("Place of residence:	" + Add.userResidency);
			Console.WriteLine("Phonenumber:		" + Add.userPhoneNumber);
			Console.WriteLine("Food arrangement:	" + Add.userFoodString);
			Console.WriteLine("Arrangement:		" + Add.userArrangementString);
			Console.WriteLine("\nTotal Price:		€" + userTotalPrice);
			Console.Write("\nClient UniqueID (Bring this to the desk): ");
			Write(Add.userUniqueID, ConsoleColor.Green);
			Console.WriteLine("\nThis will be sent to the following email address: " + Add.userEmail);
			Write("\nPress any key to continue to the payment page...\n", ConsoleColor.Green);
			Console.WriteLine("============================================");
			Console.ReadKey(true);
			BetaalPagina.payment();
			if (BetaalPagina.PaymentSuccess == true) 
			{
				Add.ReservationWriteToDatabase();
			}
			userTotalPrice = 0;
			Add.userFoodArrangement = 0;
			Add.userFoodString = "";
			Add.userArrangementString = "";
			Add.userArrangement = 0;
		}
		public static void TotalPrice()
		{
			if (Add.userFoodArrangement == 1) //none
			{
				Add.userFoodString = "None";
				userFoodArrangementPrice = 0;
			}
			if (Add.userFoodArrangement == 2) //just food
			{
				Add.userFoodString = "Just Food";
				userFoodArrangementPrice = menusList.Menus[0].FoodPrice * Add.userParticipants;
			}
			if (Add.userFoodArrangement == 3) //just drinks
			{
				Add.userFoodString = "Just Drinks";
				userFoodArrangementPrice = menusList.Menus[0].DrinksPrice * Add.userParticipants;
			}
			if (Add.userFoodArrangement == 4) //food and drinks
			{
				Add.userFoodString = "Food and Drinks";
				userFoodArrangementPrice = menusList.Menus[0].FoodAndDrinksPrice * Add.userParticipants;
			}

			if (Add.userArrangement == 1) //none
			{
				Add.userArrangementString = "None";
				userArrangementPrice = 0;
			}
			if (Add.userArrangement == 2) //kids party
			{
				Add.userArrangementString = "Kids Party";
				userArrangementPrice = escapeRoomsList.EscapeRooms[Add.RoomChoice].RoomPrice * 1.4;
			}
			if (Add.userArrangement == 3) //ladies night
			{
				Add.userArrangementString = "Ladies Night";
				userArrangementPrice = escapeRoomsList.EscapeRooms[Add.RoomChoice].RoomPrice * 1.5;
			}
			if (Add.userArrangement == 4) //work outing
			{
				Add.userArrangementString = "Work Outing";
				userArrangementPrice = escapeRoomsList.EscapeRooms[Add.RoomChoice].RoomPrice * 1.3;
			}
			userTotalPrice = escapeRoomsList.EscapeRooms[Add.RoomChoice].RoomPrice * Add.userParticipants + userFoodArrangementPrice - userArrangementPrice;
			
		}
		public static void CustomerOverview()
		{
			File.ReadAllText(PathUser);
			Console.Clear();
			Console.WriteLine("User info:\n=======================================");
			for (int i = 0; i < usersList.Users.Count; i++)
			{
				Console.WriteLine("UserID:		" + usersList.Users[i].UserID);
				Console.WriteLine("Username:	" + usersList.Users[i].UserName);
				Console.WriteLine("First name:	" + usersList.Users[i].UserFirstName);
				Console.WriteLine("Last name:	" + usersList.Users[i].UserLastName);
				Console.WriteLine("Address:	" + usersList.Users[i].UserStreetName + " " + usersList.Users[i].UserHouseNumber + " " + usersList.Users[i].UserPostalCode + " " + usersList.Users[i].UserResidencyName);
				Console.WriteLine("Phone number:	" + usersList.Users[i].UserPhoneNumber);
				Console.WriteLine("E-mail:		" + usersList.Users[i].UserEmail);
				Console.WriteLine("Role:		" + usersList.Users[i].UserRole + "\n=======================================");
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey(true);
		}
		public static void ReservationOverview()
		{
			File.ReadAllText(PathReservation);
			Console.Clear();
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("Reservation info:\n=======================================");
			for (int i = 0; i < reservationsList.Reservations.Count; i++)
			{
				Console.WriteLine("UniqueID:	" + reservationsList.Reservations[i].UniqueID);
				Console.WriteLine("Room name:	" + reservationsList.Reservations[i].ResRoomName);
				Console.WriteLine("Food:		" + reservationsList.Reservations[i].FoodArrangement);
				Console.WriteLine("Arrangement:	" + reservationsList.Reservations[i].Arrangement);
				Console.WriteLine("First name:	" + reservationsList.Reservations[i].FirstName);
				Console.WriteLine("Last name:	" + reservationsList.Reservations[i].LastName);
				Console.WriteLine("Address:	" + reservationsList.Reservations[i].StreetName + " " + reservationsList.Reservations[i].HouseNumber + " " + reservationsList.Reservations[i].PostalCode + " " + reservationsList.Reservations[i].ResidencyName);
				Console.WriteLine("Phone number:	" + reservationsList.Reservations[i].PhoneNumber);
				Console.WriteLine("E-mail:		" + reservationsList.Reservations[i].Email);
				Console.WriteLine("Total price:	" + "€" + reservationsList.Reservations[i].TotalPrice);
				Console.WriteLine("Payment method:	" + reservationsList.Reservations[i].PaymentMethod + "\n=======================================");
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey(true);
		}
		public static void ContactFunction()
		{
			while (!LoopContactFunction)
			{
				Console.Clear();
				Console.WriteLine("=======================================\nWelcome to the Contact and F.A.Q. page.\n=======================================\n1) Contact information\n2) F.A.Q.\n3) Return to menu\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow);Console.Write("] or ["); Functions.Write("3", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
				Functions.Write("Your input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { Contact(); }
				else if (input.Key == ConsoleKey.D2) { FAQ(); }
				else if (input.Key == ConsoleKey.D3) { return; }
				else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
			}
		}
		public static void InfoFunction()
		{
			Console.Clear();
			Write("What is an escape room?", ConsoleColor.Green);
			WriteLine("\n=======================================\nIn an escape room the door wil be closed and locked and it is up to you to escape the room as quickly as possible.\nUsually you wil have around 60 minutes to escape.\nWhile you are inside you wil have to solve puzzles that wil bring you close to the 'key' or code that wil help you open the door.\nIf you manage to open the door within the given time, you win.\n=======================================");
			Write("Houserules:", ConsoleColor.Green);
			WriteLine("\n=======================================\n1) It is not allowed to enter the escape rooms under the influence of drugs and/or alcohol.");
			WriteLine("2) Inside the escape room you won't have to use force to open something.");
			WriteLine("3) The only way to advance in the game is with a key or by correctly executing an assignment. Don't move any furniture!");
			WriteLine("4) Smoking is not allowed inside the whole building");
			WriteLine("5) It is not allowed to bring your own food and/or drinks.");
			WriteLine("6) Phones and other personal belongings are to be left in a locker provided by us. You wil take the key with you inside the escape room.");
			WriteLine("7) It is not allowed to take photo's inside the escape room");
			WriteLine("8) If someone wants to leave the room, you are allowed to leave the room, the door is open.");
			WriteLine("9) If you decide to leave the room, you are no longer allowed to enter back into the room.");
			WriteLine("10) The game leader wil be watching the game via cameras.\nIf you break any of the rules, he/she can decide to end the game.");
			WriteLine("11) You play the game at your own risk. We are not responsible for any injuries.");
			Write("TIP: We have special discount arrangements! Kids Party 40%, Ladies Night 50%, Work Outing 30%.\n", ConsoleColor.Green);
			Write("DISCLAIMER: Please note that these discounts are on the base price of an escape room.\n", ConsoleColor.Yellow);
			WriteLine("=======================================\nPress any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void ShowFunction()
		{
			File.ReadAllText(PathEscapeRoom);
			Console.Clear();
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("Room info:\n==============================================================================");
			for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
			{
				Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
				Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
				Console.WriteLine("Price per participant:		" + "€" + escapeRoomsList.EscapeRooms[i].RoomPrice);
				Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
				Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n==============================================================================");
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(true);
		}
		public static void CustomerShowFunction()
		{
			File.ReadAllText(PathEscapeRoom);
			Console.Clear();
			Console.OutputEncoding = Encoding.UTF8;
			if (escapeRoomsList.EscapeRooms.Count <= 0)
			{
				Console.WriteLine("No rooms have been created yet, you will be returned to the menu, press any key to continue");
				Console.ReadKey(true);
				return; ;
			}
			else
			{
				Console.WriteLine("Room info:\n==============================================================================");
				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
					Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
					Console.WriteLine("Price per participant:		" + "€" + escapeRoomsList.EscapeRooms[i].RoomPrice);
					Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
					Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n==============================================================================");
				}

			}
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void WriteLine(object obj, ConsoleColor? color = null)
		{
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.WriteLine(obj);
			Console.ResetColor();
		}
		public static void ErrorMessage(object obj)
		{
			Error();
			Console.WriteLine(obj);
		}
		public static void Error()
		{
			Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
		}
		public static void Write(object obj, ConsoleColor? color = null)
		{
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.Write(obj);
			Console.ResetColor();
		}
		public static string Error_Exception_String(string message, string errormessage, bool isanumber , bool lengthmatters, int minlength, int maxlength, bool specialcontain, string contains1, string contains2)
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
					ErrorMessage(errormessage);
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
					ErrorMessage(errormessage);
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
					ErrorMessage(errormessage);
				}
			}
			return Double.Parse(userInput);
		}
	}
}