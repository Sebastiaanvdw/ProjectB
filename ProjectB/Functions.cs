using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Y_or_N;
using BetaalPagina_Jelmer;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class Functions
	{
		public static string input_message, error_message;
		public static double userTotalPrice, userFoodArrangementPrice, userArrangementPrice;
		public static int RoomChoice, userParticipants, userFoodArrangement, userArrangement;
		public static string userName, userLastName, userPostcode, userStreet, userResidency, userHouseNumber, userEmail, userPhoneNumber, userFoodString, userArrangementString;
		public static string userUniqueID;
		public static bool LoopContactFunction = false;

		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static readonly JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

		private static readonly string PathMenu = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"MenuDatabase.json");
		private static readonly JSONMenuList menusList = JsonConvert.DeserializeObject<JSONMenuList>(File.ReadAllText(PathMenu));
		public static void ReservationWriteToDatabase()
		{

			Reservation reservation = new Reservation
			{
				UniqueID = userUniqueID,
				ResRoomName = escapeRoomsList.EscapeRooms[RoomChoice].RoomName,
				FirstName = userName,
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
				TotalPrice = userTotalPrice,
				PaymentMethod = BetaalPagina.PaymentMethod
			};

			reservationsList.Reservations.Add(reservation);
			string json = JsonConvert.SerializeObject(reservationsList, Formatting.Indented);
			File.WriteAllText(PathReservation, json);
		}
		public static void Contact()
		{
			Console.Clear();
			Console.WriteLine("Opening hours:\nMon to Thurs: 9:00am - 5:00pm\nFriday: 9:00am - 7:00pm\n\nTelephone number: 01034235423\n\nE-mail: EscapeMail@rooms.com\n\nLocation: Janpieterstraat 49 3546WQ Rotterdam\n");
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void FAQ()
		{
			string FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n\n";
			string FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n\n";
			string FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n\n";

			Console.Clear();
			Console.WriteLine(FAQ1 + FAQ2 + FAQ3 + "\n");
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void ReceiptFunction()
		{
			while (true)
			{
				userUniqueID = Guid.NewGuid().ToString();
				if (!MainProgram.IDList.Contains(userUniqueID))
				{
					MainProgram.IDList.Add(userUniqueID);
					break;
				}
			}

			Console.Clear();
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("============================================");
			Console.WriteLine("The following room has been chosen: " + escapeRoomsList.EscapeRooms[RoomChoice].RoomName);
			Console.WriteLine("\nAmount of participants: " + userParticipants);
			Console.WriteLine("============================================");
			Console.WriteLine("Name:			" + userName + " " + userLastName);
			Console.WriteLine("Street:			" + userStreet + " " + userHouseNumber);
			Console.WriteLine("Postalcode:		" + userPostcode);
			Console.WriteLine("Place of residence:	" + userResidency);
			Console.WriteLine("Phonenumber:		" + userPhoneNumber);
			Console.WriteLine("Food arrangement:	" + userFoodString);
			Console.WriteLine("Arrangement:		" + userArrangementString);
			Console.WriteLine("\nTotal Price:		€" + userTotalPrice);
			Console.Write("\nClient UniqueID (Bring this to the desk): ");
			Write(userUniqueID, ConsoleColor.Green);
			Console.WriteLine("\nThis will be sent to the following email address: " + userEmail);
			Write("\nPress any key to continue to the payment page...\n", ConsoleColor.Green);
			Console.WriteLine("============================================");
			Console.ReadKey(true);
			BetaalPagina.payment();
			if (BetaalPagina.PaymentSuccess == true) 
			{
				ReservationWriteToDatabase();
			}
			userTotalPrice = 0;
			userFoodArrangement = 0;
			userFoodString = "";
			userArrangementString = "";
			userArrangement = 0;
		}
		public static void ReserveerFunction()
		{
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
					Console.WriteLine("-----------------------------");
					Console.WriteLine("Incase you want to return to the menu type: 'return'");
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
					userName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", ""); //(message, errorMessage, is it a number, does the length matter, minimum length, maximum length

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
						TotalPrice();
						ReceiptFunction();
						Console.Clear();
						Console.Write("Would you like to add another reservation?, press ");
						Functions.Write("y", ConsoleColor.Yellow);
						Console.Write(" or ");
						Functions.Write("n", ConsoleColor.Yellow);
						bool Return = util.CheckYN();
						if (Return == true) { }
						if (Return == false) { LoopAddReservation = false; return; }
					}
				}
			}
		}
		public static void TotalPrice()
		{
			if (userFoodArrangement == 1) //none
			{
				userFoodString = "None";
				userFoodArrangementPrice = 0;
			}
			if (userFoodArrangement == 2) //just food
			{
				userFoodString = "Just Food";
				userFoodArrangementPrice = menusList.Menus[0].FoodPrice * userParticipants;
			}
			if (userFoodArrangement == 3) //just drinks
			{
				userFoodString = "Just Drinks";
				userFoodArrangementPrice = menusList.Menus[0].DrinksPrice * userParticipants;
			}
			if (userFoodArrangement == 4) //food and drinks
			{
				userFoodString = "Food and Drinks";
				userFoodArrangementPrice = menusList.Menus[0].FoodAndDrinksPrice * userParticipants;
			}

			if (userArrangement == 1) //none
			{
				userArrangementString = "None";
				userArrangementPrice = 0;
			}
			if (userArrangement == 2) //kids party
			{
				userArrangementString = "Kids Party";
				userArrangementPrice = escapeRoomsList.EscapeRooms[RoomChoice].RoomPrice * 1.4;
			}
			if (userArrangement == 3) //ladies night
			{
				userArrangementString = "Ladies Night";
				userArrangementPrice = escapeRoomsList.EscapeRooms[RoomChoice].RoomPrice * 1.5;
			}
			if (userArrangement == 4) //work outing
			{
				userArrangementString = "Work Outing";
				userArrangementPrice = escapeRoomsList.EscapeRooms[RoomChoice].RoomPrice * 1.3;
			}
			userTotalPrice = escapeRoomsList.EscapeRooms[RoomChoice].RoomPrice * userParticipants + userFoodArrangementPrice - userArrangementPrice;
			
		}
		public static void CustomerOverview()
		{
			Console.Clear();
			Console.WriteLine(userName + "," + userLastName + "," + userPostcode + "," + userStreet + "," + userResidency + "," + userEmail + "\n");
			Console.WriteLine("press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void ContactFunction()
		{
			while (!LoopContactFunction)
			{
				Console.Clear();
				Console.WriteLine("Welcome to the Contact and F.A.Q. page.\nPlease select one of the options below:\n\n1: Contact information\n2: F.A.Q.\n3: Exit");
				string userInputCFAQ = Console.ReadLine();

				if (userInputCFAQ == "1")
				{
					Contact();
				}
				if (userInputCFAQ == "2")
				{
					FAQ();
				}
				if (userInputCFAQ == "3")
				{
					return;
				}
			}
		}
		public static void InfoFunction()
		{
			Console.Clear();
			Console.WriteLine("What is an escape room?\n\nIn an escape room the door wil be closed and locked and it is up to you to escape the room as quickly as possible.Usually you wil have around 60 minutes to escape.\nWhile you are inside you wil have to solve puzzle's that wil bring you close to the 'key' or code that wil help you open the door.\nIf you manage to open the door within the given time, you win.");
			Console.WriteLine("\nHouserules:\n1) It is forbidden to enter the escape rooms under the influence of drugs and/or alcohol.");
			Console.WriteLine("2) Inside the escape room you won't have to use force to open something.");
			Console.WriteLine("3) The only way to advance in the game is with a key or by correctly executing an assignment. Don't move the furniture or any what is hanging on the walls.");
			Console.WriteLine("4) Smoking is forbidden in the whole building");
			Console.WriteLine("5) It is not allowed to bring your own food and/or drinks.");
			Console.WriteLine("6) Phone's and other personal belongings are to be left in the locker in the entranceroom. You wil take the key to this locker with you inside the escape room.");
			Console.WriteLine("7) It is forbidden to take photo's inside the escape room");
			Console.WriteLine("8) If something happens, or someone wants to leave the room, then you are allowed to leave the room, the door is open.");
			Console.WriteLine("9) If you decide to leave the room, you wil no longer be allowed to enter the room.");
			Console.WriteLine("10) The game leader wil be watching the game via camera's. If you break any og the rules, he/she can decide to end the game.");
			Console.WriteLine("11) You play the game at your own risk. Damage or injury can not be recovered from the escape room");
			Console.WriteLine("12) You can arrange a special arrangement with discounts! These are the arrangements we offer: Kids Party 40% discount, Ladies Night 50% discount, Work Outing 30% discount.");
			Console.WriteLine("DISCLAIMER: Please note that these discounts are discounts on the base price of an escape room.");
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}
		public static void ShowFunction()
		{
			Console.Clear();

			Console.WriteLine("Room info:\n");
			for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
			{
				Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
				Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
				Console.WriteLine("Price per participant:		" + escapeRoomsList.EscapeRooms[i].RoomPrice);
				Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
				Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n");
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(true);
		}
		public static void CustomerShowFunction()
		{
			Console.Clear();
			if (escapeRoomsList.EscapeRooms.Count <= 0)
			{
				Console.WriteLine("No rooms have been created yet, you will be returned to the menu, press any key to continue");
				Console.ReadKey(true);
				return; ;
			}
			else
			{
				Console.WriteLine("Room info:\n");
				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
					Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
					Console.WriteLine("Price per participant:		" + escapeRoomsList.EscapeRooms[i].RoomPrice);
					Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
					Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n");
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
					Write("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine(errormessage);
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
					Write("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine(errormessage);
				}
			}
			return Int32.Parse(userInput);
		}
	}
}