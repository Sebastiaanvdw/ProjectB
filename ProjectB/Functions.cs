using ProjectB.Crud;
using System;
using System.Linq;
using System.Collections.Generic;
using Y_or_N;
using BetaalPagina_Jelmer;

namespace ProjectB
{
	class Functions
	{
		public static string userInput;
		public static double userTotalPrice, userFoodArrangementPrice, userArrangementPrice;
		public static int RoomChoice, userParticipants, userFoodArrangement, userArrangement;
		public static string userName, userLastName, userPostcode, userStreet, userResidency, userHouseNumber, userEmail, userPhoneNumber, userFoodString, userArrangementString;
		public static string userUniqueID;
		public static double foodPrice = 5.00;
		public static double drinksPrice = 3.50;
		public static double foodAndDrinksPrice= 7.50;
		public static bool LoopContactFunction = false;
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
			Console.WriteLine("======================");
			Console.WriteLine("\nThe following room has been chosen: " + MainProgram.RoomsList[RoomChoice].roomName);
			Console.WriteLine("Amount of participants: " + userParticipants);
			Console.WriteLine("\nClient Name: " + userName + " " + userLastName);
			Console.WriteLine("\nClient Street: " + userStreet + " " + userHouseNumber);
			Console.WriteLine("\nClient Postcode: " + userPostcode);
			Console.WriteLine("\nClient Woonplaats: " + userResidency);
			Console.WriteLine("\nClient Phonenumber: " + userPhoneNumber);
			Console.WriteLine("\nClient Food Arrangement: " + userFoodString);
			Console.WriteLine("\nClient Arrangement: " + userArrangementString);
			Console.WriteLine("\nTotal Price: $" + userTotalPrice);
			Console.WriteLine("\nClient UniqueID (Bring this to the desk): " + userUniqueID);
			Console.WriteLine("\n\nThis will be sent to the following email address: " + userEmail);
			Console.WriteLine("\n\n\nPress any key to return to continue to the payment page...\n");
			Console.ReadKey(true);

			userTotalPrice = 0;
			userFoodArrangement = 0;
			userFoodString = "";
			userArrangementString = "";
			userArrangement = 0;
			Program.payment();
		}
		public static void ReserveerFunction()
		{
			bool LoopAddReservation = true;
			while (LoopAddReservation)
			{
				bool RoomChoiceSucces = false;
				bool UserNameSucces = false;
				bool userLastNameSucces = false;
				bool userPostCodeDigitSucces = false;
				bool userPostCodeLetterSucces = false;
				bool userStreetSucces = false;
				bool userResidencySucces = false;
				bool userHouseNumberSucces = false;
				bool userEmailSucces = false;
				bool userPhoneNumberSucces = false;
				bool userParticipantsSucces = false;
				bool userFoodArrangementSucces = false;
				bool userArrangementSucces = false;
				Console.Clear();
				if (MainProgram.RoomsList.Count < 1)
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
					Console.WriteLine("For which of the following rooms would you like to make a reservation? (choose a number between 1" + "-" + MainProgram.RoomsList.Count + ")"); // Tussen 1-5

					for (int i = 0; i < MainProgram.RoomsList.Count; i++) { Console.WriteLine(MainProgram.RoomsList[i].roomNumber + " - " + MainProgram.RoomsList[i].roomName); ; }
					Console.WriteLine("\nRoom:");
					while (!RoomChoiceSucces)
					{
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							RoomChoiceSucces = int.TryParse(userInput, out int number);
							if (number < 1 || number > MainProgram.RoomsList.Count) { RoomChoiceSucces = false; }
							if (RoomChoiceSucces) { RoomChoice = number - 1; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a number between 1 and " + MainProgram.RoomsList.Count);
							}
						}
					}

					while (!UserNameSucces)
					{
						Console.WriteLine("Fill in your first name(e.g. 'Piet'):"); // Alleen Letters
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { UserNameSucces = false; }
							else if (userInput.Any(char.IsDigit)) { UserNameSucces = false; }
							else { UserNameSucces = true; }
							if (UserNameSucces) { userName = userInput; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid name");
							}
						}
					}

					while (!userLastNameSucces)
					{
						Console.WriteLine("Fill in your last name(e.g. 'de Koning'):"); //Alleen Letters
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userLastNameSucces = false; }
							else if (userInput.Any(char.IsDigit)) { userLastNameSucces = false; }
							else { userLastNameSucces = true; }
							if (userLastNameSucces) { userLastName = userInput; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid name last");
							}
						}
					}

					while (!userPostCodeDigitSucces)
					{
						Console.WriteLine("Fill in the first four digits of your postcode:"); //4 Cijfers
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							userPostCodeDigitSucces = int.TryParse(userInput, out int number);
							if (number.ToString().Length == 4) { userPostCodeDigitSucces = true; }
							else { userPostCodeDigitSucces = false; }
							if (userPostCodeDigitSucces == true) { userPostcode = userInput.ToString(); }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid postcode");
							}
						}
					}

					while (!userPostCodeLetterSucces)
					{
						Console.WriteLine("Fill in the last 2 Letters of your postcode:"); //2 letters
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userPostCodeLetterSucces = false; }
							else if (userInput.Any(char.IsDigit)) { userPostCodeLetterSucces = false; }
							else { userPostCodeLetterSucces = true; }
							if (userPostCodeLetterSucces) { userPostcode += userInput.ToUpper(); }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid name last");
							}
						}
					}
			while (!userPostCodeLetterSucces)
			{
				Console.WriteLine("Fill in the last 2 Letters of your postcode:"); //2 letters
				userinput = Console.ReadLine();
				if (string.IsNullOrEmpty(userinput)) { userPostCodeLetterSucces = false; }
				else if (userinput.Any(char.IsDigit) | userinput.Length != 2 ) { userPostCodeLetterSucces = false; }
				else { userPostCodeLetterSucces = true; }
				if (userPostCodeLetterSucces) { userPostcode += userinput.ToUpper() ; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a valid name last");
				}
			}

					while (!userStreetSucces)
					{
						Console.WriteLine("Fill in your street(e.g. 'Tulpenlaan'):"); // Alleen Letters
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userStreetSucces = false; }
							else if (userInput.Any(char.IsDigit)) { userStreetSucces = false; }
							else { userStreetSucces = true; }
							if (userStreetSucces) { userStreet = userInput; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid street name");
							}
						}
					}

					while (!userHouseNumberSucces)
					{
						Console.WriteLine("Fill in your housenumber(e.g. '98'):"); // Alleen cijfers max. 19999
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							userHouseNumberSucces = int.TryParse(userInput, out int number);
							if (number > 0 && number < 2000) { userHouseNumberSucces = true; }
							else { userHouseNumberSucces = false; }
							if (userHouseNumberSucces == true) { userHouseNumber = number.ToString(); }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid housenumber");
							}
						}
					}
					while (!userResidencySucces)
					{
						Console.WriteLine("Fill in your place of residence(e.g. 'Pijnacker'):"); // Alleen Letters
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userResidencySucces = false; }
							else if (userInput.Any(char.IsDigit)) { userResidencySucces = false; }
							else { userResidencySucces = true; }
							if (userResidencySucces) { userResidency = userInput; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid street name");
							}
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
					Console.WriteLine("Please enter a valid place of residence");
				}
			}


					while (!userEmailSucces)
					{
						Console.WriteLine("Fill in your email(e.g. 'voorbeeld@mail.com'):"); // Moet een @ en . hebben
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userEmailSucces = false; }
							else if (userInput.Contains("@") && userInput.Contains(".")) { userEmailSucces = true; }
							else { userEmailSucces = false; }
							if (userEmailSucces) { userEmail = userInput; }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid Email adress");
							}
						}
					}

					while (!userPhoneNumberSucces)
					{
						Console.WriteLine("Fill in your telephonenumber(e.g. '0676319854'):"); // Alleen cijfers max. 10 getallen
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							if (string.IsNullOrEmpty(userInput)) { userPhoneNumberSucces = false; }
							else if (userInput.Length == 10 & userInput.All(Char.IsDigit)) { userPhoneNumberSucces = true; }
							else { userPhoneNumberSucces = false; }
							if (userPhoneNumberSucces == true) { userPhoneNumber = userInput.ToString(); }
							else
							{
								Console.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid Phonenumber");
							}
						}
					}

					while (!userParticipantsSucces)
					{
						Console.WriteLine("Fill in how many participants there will be (" + MainProgram.RoomsList[RoomChoice].roomMinSize + "-" + MainProgram.RoomsList[RoomChoice].roomMaxSize + ")"); // 2-6 deelnemers
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							userParticipantsSucces = int.TryParse(userInput, out int number);
							if (number >= MainProgram.RoomsList[RoomChoice].roomMinSize && number <= MainProgram.RoomsList[RoomChoice].roomMaxSize) { userParticipantsSucces = true; }
							else { userParticipantsSucces = false; }
							if (userParticipantsSucces == true) { userParticipants = number; }
							else
							{
								WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a valid number of participants");
							}
						}
					}

					while (!userFoodArrangementSucces)
					{
						Console.WriteLine("Fill in which food arrangment you want (1. none, 2. just food, 3. just drinks or 4. food and drinks):"); // Alleen 1 van de 4 opties
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							userFoodArrangementSucces = int.TryParse(userInput, out int number);
							if (number < 0 | number > 5) { userFoodArrangementSucces = false; }
							else { userFoodArrangementSucces = true; }
							if (userFoodArrangementSucces) { userFoodArrangement = number; }
							else
							{
								WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a number between 1 and 4");
							}
						}
					}
			while (!userFoodArrangementSucces)
			{
				Console.WriteLine("Fill in which food arrangment you want (1. none, 2. just food, 3. just drinks or 4. food and drinks):"); // Alleen 1 van de 4 opties
				userinput = Console.ReadLine();
				userFoodArrangementSucces = int.TryParse(userinput, out int number);
				if (number > 0 & number < 5) { userFoodArrangementSucces = true; }
				else { userFoodArrangementSucces = false; }
				if (userFoodArrangementSucces) { userFoodArrangement = number; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a number between 1 and 4");
				}
			}

					while (!userArrangementSucces)
					{
						Console.WriteLine("Fill in the number of the arrangment that you want( 1. none, 2. kids party, 3. ladies night or 4. work outing):"); // Alleen 1 van de 4 opties
						userInput = Console.ReadLine();
						if (userInput == "return")
						{
							Console.Write("Would you like to return to the menu, press ");
							Functions.Write("y", ConsoleColor.Yellow);
							Console.Write(" or ");
							Functions.Write("n", ConsoleColor.Yellow);
							bool Return = util.CheckYN();
							if (Return == true) { RoomChoiceSucces = false; return; }
							if (Return == false) { Console.WriteLine(""); LoopAddReservation = false; }
						}
						else
						{
							userArrangementSucces = int.TryParse(userInput, out int number);
							if (number < 0 | number > 5) { userArrangementSucces = false; }
							else { userArrangementSucces = true; }
							if (userArrangementSucces) { userArrangement = number; }
							else
							{
								WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
								Console.WriteLine("Please enter a number between 1 and 4");
							}
						}
					}
					Console.Clear();
					if (userArrangement != 0)
					{
						TotalPrice();
						ReceiptFunction();
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
			while (!userArrangementSucces)
			{
				Console.WriteLine("Fill in the number of the arrangment that you want( 1. none, 2. kids party, 3. ladies night or 4. work outing):"); // Alleen 1 van de 4 opties
				userinput = Console.ReadLine();
				userArrangementSucces = int.TryParse(userinput, out int number);
				if (number > 0 & number < 5) { userArrangementSucces = true; }
				else { userArrangementSucces = false; }
				if (userArrangementSucces) { userArrangement = number; }
				else
				{
					WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a number between 1 and 4");
				}
			}
			Console.Clear();
			TotalPrice();
			ReceiptFunction();
		}
		public static void TotalPrice()
		{
			if (userFoodArrangement == 1) //none
			{
				userFoodString = "None";
				userFoodArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * userParticipants;
			}
			if (userFoodArrangement == 2) //just food
			{
				userFoodString = "Just Food";
				userFoodArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * userParticipants + foodPrice * userParticipants;
			}
			if (userFoodArrangement == 3) //just drinks
			{
				userFoodString = "Just Drinks";
				userFoodArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * userParticipants + drinksPrice * userParticipants;
			}
			if (userFoodArrangement == 4) //food and drinks
			{
				userFoodString = "Food and Drinks";
				userFoodArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * userParticipants + foodAndDrinksPrice * userParticipants;
			}

			if (userArrangement == 1) //none
			{
				userArrangementString = "None";
				userArrangementPrice = 0;
			}
			if (userArrangement == 2) //kids party
			{
				userArrangementString = "Kids Party";
				userArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * 1.4;
			}
			if (userArrangement == 3) //ladies night
			{
				userArrangementString = "Ladies Night";
				userArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * 1.5;
			}
			if (userArrangement == 4) //work outing
			{
				userArrangementString = "Work Outing";
				userArrangementPrice = MainProgram.RoomsList[RoomChoice].roomPrice * 1.3;
			}
			userTotalPrice = userFoodArrangementPrice - userArrangementPrice;
			
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
		public static void ShowFunction(List<EscapeRoom> RoomsList)
		{
			bool showBool = false;
			Console.Clear();
			if (RoomsList.Count <= 0)
			{
				Functions.WriteLine("Oh no, it looks like noone has created a room yet!", ConsoleColor.Red);
				Console.Write("Press ");Functions.Write("c", ConsoleColor.Yellow);Console.Write(" to create a room or ");Functions.Write("m ", ConsoleColor.Yellow);Console.Write("to return to menu.");
				showBool = util.CheckCM();
				if(showBool == true) {Add.Function(MainProgram.RoomsList); }
				else { return; }
			}
			else
			{
				Console.WriteLine("Room info:\n");
				for (int i = 0; i < RoomsList.Count; i++)
				{
					Console.WriteLine(RoomsList[i] + "\n");
				}

			}
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(true);
		}
		public static void CustomerShowFunction(List<EscapeRoom> RoomsList)
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
			Functions.WriteLine("Oh no, your input did not fit!",ConsoleColor.Red);
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

