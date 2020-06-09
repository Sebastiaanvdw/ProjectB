//using System;
//using System.Collections.Generic;
//using System.Text;
//using Y_or_N;
//using System.Linq;

//namespace ProjectB
//{
//	public class Customer
//	{
//		public static double totalPrice, foodArrangementPrice, arrangementPrice;
//		public static int participants, foodArrangement, arrangement;
//		public static string firstName, lastName, postcode, street, residency, housenumber, email, phoneNumber, foodString, arrangementString, uniqueID, input_message, error_message;
//		public static double foodPrice = 5.00;
//		public static double drinksPrice = 3.50;
//		public static double foodAndDrinksPrice = 7.50;
//		public static bool loopContactFunction = false;

//		public static string Error_Exception_String(string message, string errormessage, bool isanumber, bool lengthmatters, int minlength, int maxlength, bool specialcontain, string contains1, string contains2)
//		{
//			string userInput = "";
//			bool Succes = false;
//			Console.Clear();
//			while (!Succes)
//			{
//				Console.WriteLine(message);
//				userInput = Console.ReadLine();
//				if (string.IsNullOrEmpty(userInput)) { Succes = false; }
//				else if (!isanumber && userInput.Any(char.IsDigit)) { Succes = false; }
//				else if (isanumber && !userInput.Any(char.IsDigit)) { Succes = false; }
//				else if (lengthmatters && (userInput.Length < minlength || userInput.Length > maxlength)) { Succes = false; }
//				else if (specialcontain && !userInput.Contains(contains1) || !userInput.Contains(contains2)) { Succes = false; }
//				else if (userInput.Length < 5 && userInput.Contains(" ")) { Succes = false; }
//				else { Succes = true; }
//				if (Succes) { }
//				else
//				{
//					Functions.Write("Oh no, your input did not fit!", ConsoleColor.Red);
//					Console.WriteLine(errormessage);
//				}
//			}
//			return userInput;
//		}

//		public static int Error_Exception_Int(string message, string errormessage, int minlength, int maxlength)
//		{
//			string userInput = "";
//			bool Succes = false;
//			Console.Clear();
//			while (!Succes)
//			{
//				Console.WriteLine(message);
//				userInput = Console.ReadLine();
//				Succes = int.TryParse(userInput, out int number);
//				if (number >= minlength && number <= maxlength) { Succes = true; }
//				else { Succes = false; }
//				if (Succes) { }
//				else
//				{
//					Functions.Write("Oh no, your input did not fit!", ConsoleColor.Red);
//					Console.WriteLine(errormessage);
//				}
//			}
//			return Int32.Parse(userInput);
//		}

//		Customer()
//		{
//			static void ReserveerFunction()
//			{
//				bool LoopAddReservation = true;
//				while (LoopAddReservation)
//				{
//					Console.Clear();
//					if (MainProgram.RoomsList.Count < 1)
//					{
//						Console.WriteLine("No escaperooms have been added yet so you can't make a reservation yet, you will be returned to the menu.");
//						Console.ReadKey(true);
//						return;
//					}
//					else
//					{
//						Console.WriteLine("-----------------------------");
//						Console.WriteLine("Incase you want to return to the menu type: 'return'");
//						Console.WriteLine("-----------------------------");
//						Console.WriteLine("Please choose your room and fill in the information required:");
//						Console.WriteLine("-----------------------------");
//						Console.WriteLine("For which of the following rooms would you like to make a reservation? (choose a number between 1" + "-" + MainProgram.RoomsList.Count + ")"); // Tussen 1-5

//						for (int i = 0; i < MainProgram.RoomsList.Count; i++) { Console.WriteLine(MainProgram.RoomsList[i].roomNumber + " - " + MainProgram.RoomsList[i].roomName); ; }

//						input_message = "\nRoom:";
//						error_message = "Please enter a number between 1 and " + MainProgram.RoomsList.Count;
//						RoomChoice = Error_Exception_Int(input_message, error_message, 1, MainProgram.RoomsList.Count) - 1;
						
//						input_message = "Fill in your first name(e.g. 'Piet'):";
//						error_message = "Please enter a valid name";
//						firstName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", ""); //(message, errorMessage, is it a number, does the length matter, minimum length, maximum length

//						input_message = "Fill in your last name(e.g. 'de Koning'):";
//						error_message = "Please enter a valid name last";
//						lastName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

//						input_message = "Fill in the first four digits of your postcode:";
//						error_message = "Please enter a valid postcode";
//						postcode = Error_Exception_String(input_message, error_message, true, true, 4, 4, false, "", "");

//						input_message = "Fill in the last two letters of your postcode: ";
//						error_message = "Please fill two letters";
//						postcode += Error_Exception_String(input_message, error_message, false, true, 2, 2, false, "", "").ToUpper();

//						input_message = "Fill in your street(e.g. 'Tulpenlaan'):";
//						error_message = "Please enter a valid street name";
//						street = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

//						input_message = "Fill in your housenumber(e.g. '98'):";
//						error_message = "Please enter a valid housenumber";
//						housenumber = Error_Exception_Int(input_message, error_message, 1, 2000).ToString();

//						input_message = "Fill in your place of residence(e.g. 'Pijnacker'):";
//						error_message = "Please enter a valid place of residence";
//						residency = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");

//						input_message = "Fill in your email(e.g. 'voorbeeld@mail.com'):";
//						error_message = "Please enter a valid Email adress";
//						email = Error_Exception_String(input_message, error_message, false, false, 0, 0, true, "@", ".");

//						input_message = "Fill in your telephonenumber(e.g. '0676319854'):";
//						error_message = "Please enter a valid Phonenumber";
//						phoneNumber = Error_Exception_String(input_message, error_message, true, true, 10, 10, false, "", ""); 

//						input_message = "Fill in how many participants there will be (" + MainProgram.RoomsList[RoomChoice].roomMinSize + "-" + MainProgram.RoomsList[RoomChoice].roomMaxSize + ")";
//						error_message = "Please enter a valid number of participants";
//						participants = Error_Exception_Int(input_message, error_message, MainProgram.RoomsList[RoomChoice].roomMinSize, MainProgram.RoomsList[RoomChoice].roomMaxSize);

//						input_message = "Fill in which food arrangment you want (1. none, 2. just food, 3. just drinks or 4. food and drinks):";
//						error_message = "Please enter a number between 1 and 4";
//						foodArrangement = Error_Exception_Int(input_message, error_message, 1, 4);

//						input_message = "Fill in the number of the arrangment that you want( 1. none, 2. kids party, 3. ladies night or 4. work outing):";
//						error_message = "Please enter a number between 1 and 4";
//						arrangement = Error_Exception_Int(input_message, error_message, 1, 4);

//						Console.Clear();
//						if (arrangement != 0)
//						{
//							Functions.TotalPrice();
//							Functions.ReceiptFunction();
//							Console.Write("Would you like to add another reservation?, press ");
//							Functions.Write("y", ConsoleColor.Yellow);
//							Console.Write(" or ");
//							Functions.Write("n", ConsoleColor.Yellow);
//							bool Return = util.CheckYN();
//							if (Return == true) { }
//							if (Return == false) { LoopAddReservation = false; return; }
//						}
//					}
//				}
//			}
//		}
//	}
//}
