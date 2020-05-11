using ProjectB.Crud;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectB
{
	class Functions
	{
		public static string userinput;
		public static int RoomChoice, userParticipants;
		public static string userName, userLastName, userPostcode, userStreet, userResidency, userHouseNumber, userEmail, userPhoneNumber;
		public static string userUniqueID;
		public static bool RoomChoiceSucces = false;
		public static bool UserNameSucces = false;
		public static bool userLastNameSucces = false;
		public static bool userPostCodeDigitSucces = false;
		public static bool userPostCodeLetterSucces = false;
		public static bool userStreetSucces = false;
		public static bool userResidencySucces = false;
		public static bool userHouseNumberSucces = false;
		public static bool userEmailSucces = false;
		public static bool userPhoneNumberSucces = false;
		public static bool userParticipantsSucces = false;

		public static void Contact()
		{
			Console.Clear();
			Console.WriteLine("Opening hours:\nMon to Thurs: 9:00am - 5:00pm\nFriday: 9:00am - 7:00pm\n\nTelephone number: 01034235423\n\nE-mail: EscapeMail@rooms.com\n\nLocation: Janpieterstraat 49 3546WQ Rotterdam\n");
			Console.ReadKey(true);
		}

		public static void FAQ()
		{
			string FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n\n";
			string FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n\n";
			string FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n\n";

			Console.Clear();
			Console.WriteLine(FAQ1 + FAQ2 + FAQ3 + "\n");
			Console.ReadKey(true);
		}

		public static void ReceiptFunction()
		{
			while (true)
			{
				userUniqueID = Guid.NewGuid().ToString();
				if (!MainProgramma.IDList.Contains(userUniqueID))
				{
					MainProgramma.IDList.Add(userUniqueID);
					break;
				}
			}

			var userTotalPrice = MainProgramma.RoomsList[RoomChoice].roomPrice * userParticipants;//hierbij moet ook nog + arrangementprijs; //Dit wordt in later berekend

			Console.Clear();
			Console.WriteLine("======================");
			Console.WriteLine("\nThe following room has been chosen: " + MainProgramma.RoomsList[RoomChoice].roomName);
			Console.WriteLine("Amount of participants: " + userParticipants);
			Console.WriteLine("\nClient Name: " + userName + " " + userLastName);
			Console.WriteLine("\nClient Street: " + userStreet + " " + userHouseNumber);
			Console.WriteLine("\nClient Postcode: " + userPostcode);
			Console.WriteLine("\nClient Woonplaats: " + userResidency);
			Console.WriteLine("\nClient Phonenumber: " + userPhoneNumber);
			Console.WriteLine("\nTotal Price: $" + userTotalPrice + "(Roomprice * Participants)");
			Console.WriteLine("\nClient UniqueID (Bring this to the desk): " + userUniqueID);
			Console.WriteLine("\n\nThis will be send to the following email address: " + userEmail);
			Console.ReadKey(true);
		}
		public static void ReserveerFunction()
		{
			Console.Clear();
			if (MainProgramma.RoomsList.Count < 1)
			{
				Console.WriteLine("No escaperooms have been added yet so you can't make a reservation yet, you will be returned to the menu.");
				Console.ReadKey(true);
				return;
			}

			Console.WriteLine("-----------------------------");
			Console.WriteLine("Please choose your room and fill in the information required:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("For which of the following rooms would you like to make a reservation? (choose a number between 1" + "-" + MainProgramma.RoomsList.Count + ")"); // Tussen 1-5

			for (int i = 0; i < MainProgramma.RoomsList.Count; i++) { Console.WriteLine(MainProgramma.RoomsList[i].roomNumber + " - " + MainProgramma.RoomsList[i].roomName); ; }
			Console.WriteLine("\nRoom:");
			while (!RoomChoiceSucces)
			{
				userinput = Console.ReadLine();
				RoomChoiceSucces = int.TryParse(userinput, out int number);
				if (number < 1 || number > MainProgramma.RoomsList.Count) { RoomChoiceSucces = false; }
				if (RoomChoiceSucces) { RoomChoice = number - 1; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a number between 1 and " + MainProgramma.RoomsList.Count);
				}
			}

			while (!UserNameSucces)
			{
				Console.WriteLine("Fill in your first name(e.g. 'Piet'):"); // Alleen Letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { UserNameSucces = false; }
				else if (userinput.Any(char.IsDigit)) { UserNameSucces = false; }
				else { UserNameSucces = true; }
				if (UserNameSucces) { userName = userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid name");
				}
			}

			while (!userLastNameSucces)
			{
				Console.WriteLine("Fill in your last name(e.g. 'de Koning'):"); //Alleen Letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userLastNameSucces = false; }
				else if (userinput.Any(char.IsDigit)) { userLastNameSucces = false; }
				else { userLastNameSucces = true; }
				if (userLastNameSucces) { userLastName = userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid name last");
				}
			}

			while (!userPostCodeDigitSucces)
			{
				Console.WriteLine("Fill in the first four digits of your postcode:"); //4 Cijfers
				userinput = Console.ReadLine();
				userPostCodeDigitSucces = int.TryParse(userinput, out int number);
				if (number.ToString().Length == 4) { userPostCodeDigitSucces = true; }
				else { userPostCodeDigitSucces = false; }
				if (userPostCodeDigitSucces == true) { userPostcode = userinput.ToString(); }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid postcode");
				}
			}

			while (!userPostCodeLetterSucces)
			{
				Console.WriteLine("Fill in the last 2 Letters of your postcode:"); //2 letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userPostCodeLetterSucces = false; }
				else if (userinput.Any(char.IsDigit)) { userPostCodeLetterSucces = false; }
				else { userPostCodeLetterSucces = true; }
				if (userPostCodeLetterSucces) { userPostcode += userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid name last");
				}
			}

			while (!userStreetSucces)
			{
				Console.WriteLine("Fill in your street(e.g. 'Tulpenlaan'):"); // Alleen Letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userStreetSucces = false; }
				else if (userinput.Any(char.IsDigit)) { userStreetSucces = false; }
				else { userStreetSucces = true; }
				if (userStreetSucces) { userStreet = userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid street name");
				}
			}

			while (!userHouseNumberSucces)
			{
				Console.WriteLine("Fill in your housenumber(e.g. '98'):"); // Alleen cijfers max. 19999
				userinput = Console.ReadLine();
				userHouseNumberSucces = int.TryParse(userinput, out int number);
				if (number > 0 && number < 2000) { userHouseNumberSucces = true; }
				else { userHouseNumberSucces = false; }
				if (userHouseNumberSucces == true) { userHouseNumber = number.ToString(); }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid housenumber");
				}
			}
			while (!userResidencySucces)
			{
				Console.WriteLine("Fill in your place of residence(e.g. 'Pijnacker'):"); // Alleen Letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userResidencySucces = false; }
				else if (userinput.Any(char.IsDigit)) { userResidencySucces = false; }
				else { userResidencySucces = true; }
				if (userResidencySucces) { userResidency = userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid street name");
				}
			}


			while (!userEmailSucces)
			{
				Console.WriteLine("Fill in your email(e.g. 'voorbeeld@mail.com'):"); // Moet een @ en . hebben
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userEmailSucces = false; }
				else if (userinput.Contains("@")&&userinput.Contains(".")) { userEmailSucces = true; }
				else { userEmailSucces = false; }
				if (userEmailSucces) { userEmail = userinput; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid Email adress");
				}
			}

			while (!userPhoneNumberSucces)
			{
				Console.WriteLine("Fill in your telephonenumber(e.g. '06 7631 9854', the 06 will automaticly be added):"); // Alleen cijfers max. 10 getallen
				userinput = Console.ReadLine();
				userPhoneNumberSucces = int.TryParse(userinput, out int number);
				if (number.ToString().Length == 8) { userPhoneNumberSucces = true; }
				else { userPhoneNumberSucces = false; }
				if (userPhoneNumberSucces == true) { userPhoneNumber = "06" + number.ToString(); }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid Phonenumber");
				}
			}
			
			while (!userParticipantsSucces)
			{
				Console.WriteLine("Fill in how many participants there will be(" + MainProgramma.RoomsList[RoomChoice].roomMinSize + "-" + MainProgramma.RoomsList[RoomChoice].roomMaxSize + ")"); // 2-6 deelnemers
				userinput = Console.ReadLine();
				userParticipantsSucces = int.TryParse(userinput, out int number);
				if (number >= MainProgramma.RoomsList[RoomChoice].roomMinSize && number <= MainProgramma.RoomsList[RoomChoice].roomMaxSize) { userParticipantsSucces = true; }
				else { userParticipantsSucces = false; }
				if (userParticipantsSucces == true) { userParticipants = number; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid number of participants");
				}
			}
			Console.Clear();
			ReceiptFunction();
		}
		public static void CustomerOverview()
		{
			Console.Clear();
			Console.WriteLine(userName + "," + userLastName + "," + userPostcode + "," + userStreet + "," + userResidency + "," + userEmail + "\n");
			Console.WriteLine("Press any key to return to continue.\n");
			Console.ReadKey(true);
		}



		public static void ContactFunction()
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Contact and F.A.Q. page.\nPlease select one of the options below:\n\n1: Contact information\n2: F.A.Q.\n");
			string userInputCFAQ = Console.ReadLine();

			if (userInputCFAQ == "1")
			{
				Contact();
			}
			if (userInputCFAQ == "2")
			{
				FAQ();
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
			Console.ReadKey(true);
		}

		public static void ShowFunction(List<EscapeRoom> RoomsList)
		{
			Console.Clear();
			if (RoomsList.Count <= 0)
			{
					Console.WriteLine("No rooms have been created yet, you will be returned to the menu, press any key to continue");
					Console.ReadKey(true);
					return; ;
			}
			else
			{
				Console.WriteLine("Room info:\n");
				for (int i = 0; i < RoomsList.Count; i++)
				{
					Console.WriteLine(RoomsList[i] + "\n");
				}
			}
			Console.ReadKey(true);
		}

		public static void WriteLine(object obj, ConsoleColor? color = null)
		{
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.WriteLine(obj);
			Console.ResetColor();
		}

		public static void error()
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

	}
}

