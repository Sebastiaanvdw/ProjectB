using System;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class Edit
	{
		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static readonly JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

		private static readonly string PathMenu = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"MenuDatabase.json");
		private static readonly JSONMenuList menusList = JsonConvert.DeserializeObject<JSONMenuList>(File.ReadAllText(PathMenu));

		public static string input_message, error_message, userPostCode;

		public static void Function()
		{
			bool LoopEditFunction = false;
			while (!LoopEditFunction)
			{
				Console.Clear();
				Console.WriteLine("=======================================\nWelcome to the Edit page.\n=======================================\n1) Edit escape room\n2) Edit user\n3) Edit food and drinks menu\n4) Return to menu\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("4", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
				Functions.Write("Your input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { EditEscapeRoom(); }
				else if (input.Key == ConsoleKey.D2) { EditUser(); }
				else if (input.Key == ConsoleKey.D3) { FoodEdit(); }
				else if (input.Key == ConsoleKey.D4) { return; }
				else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
			}
		}
		public static void EditEscapeRoom()
		{
			bool LoopEditRoom = true;
			while (LoopEditRoom)
			{
				string userInput;
				int EditRoomIndex = 0;
				int EditRoomChoice = 0;
				bool RoomIndexSucces = false;

				Console.Clear();
				SpecialShow.EscapeRoom();

				if (escapeRoomsList.EscapeRooms.Count == 0)
				{
					return;
				} 

				Console.WriteLine("Choose the room that you want to edit(use a roomnumber 1-" + escapeRoomsList.EscapeRooms.Count + ")");
				while (!RoomIndexSucces)
				{
					userInput = Console.ReadLine();
					RoomIndexSucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > escapeRoomsList.EscapeRooms.Count) { RoomIndexSucces = false; }
					if (RoomIndexSucces) { EditRoomIndex = number - 1; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 1 and " + escapeRoomsList.EscapeRooms.Count);
					}
				}

				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					if (i == EditRoomIndex)
					{
						bool Continue_RoomEdit = true;
						while (Continue_RoomEdit)
						{
							bool RoomEditSucces = false;
							bool priceSuccess = false;
							bool themeSuccess = false;
							bool minSuccess = false;
							bool maxSuccess = false;
							bool ageSuccess = false;
							bool durationSuccess = false;
							bool nameSuccess = false;
							Console.Clear();
							Console.WriteLine(escapeRoomsList.EscapeRooms[EditRoomIndex].RoomName + "\n");
							Console.WriteLine("Choose what you would like to change about the room: ");
							Console.WriteLine("1) Change name\n2) Change minimum age\n3) Change amount of players\n4) Change price\n5) Change duration\n6) Change theme\n7) Stop editing this room");
							while (!RoomEditSucces)
							{
								userInput = Console.ReadLine();
								RoomEditSucces = int.TryParse(userInput, out int number);
								if (number < 1 || number > 7) { RoomEditSucces = false; }
								if (RoomEditSucces) { EditRoomChoice = number; }
								else
								{
									Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
									Console.WriteLine("Please enter a number between 1 and 7");
								}
							}

							if (EditRoomChoice == 1)
							{
								while (!nameSuccess)
								{
									Console.WriteLine("Enter a name for the escape room:");
									userInput = Console.ReadLine();
									if (string.IsNullOrEmpty(userInput)) { nameSuccess = false; }
									else { nameSuccess = true; }
									if (nameSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomName = userInput; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please use alphabetic characters only");
									}
								}
							}
							else if (EditRoomChoice == 2)
							{
								while (!ageSuccess)
								{
									Console.WriteLine("Enter the minimum age for the escape room (between 12-100):");
									userInput = Console.ReadLine();
									ageSuccess = int.TryParse(userInput, out int number);
									if (number < 12 || number > 100) { ageSuccess = false; }
									if (ageSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].AgeMinimum = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number between 12-100");
									}
								}
							}
							else if (EditRoomChoice == 3)
							{
								while (!minSuccess)
								{
									Console.WriteLine("Enter the minimum amount of players for the escape room (between 2-5):");
									userInput = Console.ReadLine();
									minSuccess = int.TryParse(userInput, out int number);
									if (number < 2 || number > 5) { minSuccess = false; }
									if (minSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number between 2-5");
									}
								}

								while (!maxSuccess)
								{
									Console.WriteLine("Enter the maximum amount of players for the escape room: (between" + (escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize + 1) + "-6");
									userInput = Console.ReadLine();
									maxSuccess = int.TryParse(userInput, out int number);
									if (number <= escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize || number > 6) { maxSuccess = false; }
									if (maxSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMaxSize = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a valid number inbetween " + (escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize + 1) + "-6");
									}
								}
							}
							else if (EditRoomChoice == 4)
							{
								while (!priceSuccess)
								{
									Console.WriteLine("Enter the price for the escape room (price is per participant):");
									userInput = Console.ReadLine();
									priceSuccess = Double.TryParse(userInput, out double number);
									if (number < 1) { priceSuccess = false; }
									else if (userInput.Contains(".")) { priceSuccess = false; }
									if (priceSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomPrice = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number above 0, if it's a decimal number use ','.");
									}
								}
							}
							else if (EditRoomChoice == 5)
							{
								while (!durationSuccess)
								{
									Console.WriteLine("Enter the duration for the escape room in hours (e.g. '1,5'):");
									userInput = Console.ReadLine();
									durationSuccess = double.TryParse(userInput, out double number);
									if (number < 0 || number > 5) { durationSuccess = false; }
									else if (userInput.Contains(".")) { durationSuccess = false; }
									if (durationSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomDuration = new TimeSpan(Convert.ToInt32(Math.Truncate(number)), Convert.ToInt32(Math.Round((number - Math.Truncate(number)) * 60)), 0); }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number between 0 and 5 (if it's a decimal number please use a ',')");
									}
								}
							}
							else if (EditRoomChoice == 6)
							{
								while (!themeSuccess)
								{
									Console.WriteLine("Enter a theme for the escape room:");
									userInput = Console.ReadLine();
									themeSuccess = userInput.All(c => Char.IsLetter(c));
									if (string.IsNullOrEmpty(userInput)) { themeSuccess = false; }
									if (themeSuccess) { escapeRoomsList.EscapeRooms[EditRoomIndex].RoomTheme = userInput; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please use alphabetic characters only");
									}
								}
							}
							else if (EditRoomChoice == 7)
							{
								Continue_RoomEdit = false;
							}
							string json = JsonConvert.SerializeObject(escapeRoomsList, Formatting.Indented);
							File.WriteAllText(PathEscapeRoom, json);
						}
					}
				}
				if (escapeRoomsList.EscapeRooms.Count > 1)
				{
					Console.Write("Would you like to edit another room?");
					bool Return = util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopEditRoom = false; }
				}
				else
				{
					return;
				}
			}
		}
		public static void EditUser()
		{
			bool LoopEditUser = true;
			while (LoopEditUser)
			{
				string userInput;
				int EditUserIndex = 0;
				int EditUserChoice = 0;
				bool UserIndexSucces = false;

				Console.Clear();
				SpecialShow.User();

				if (usersList.Users.Count == 0)
				{
					return;
				}

				Console.WriteLine("Choose the user that you want to edit(1-" + usersList.Users.Count + ")");
				while (!UserIndexSucces)
				{
					userInput = Console.ReadLine();
					UserIndexSucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > usersList.Users.Count) { UserIndexSucces = false; }
					if (UserIndexSucces) { EditUserIndex = number - 1; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 1 and " + usersList.Users.Count);
					}
				}

				for (int i = 0; i < usersList.Users.Count; i++)
				{
					if (i == EditUserIndex)
					{
						bool Continue_UserEdit = true;
						while (Continue_UserEdit)
						{
							bool UserEditSucces = false;
							bool roleSuccess = false;
							Console.Clear();
							Console.WriteLine(usersList.Users[EditUserIndex].UserFirstName + " " + usersList.Users[EditUserIndex].UserLastName + "\n");
							Console.WriteLine("Choose what you would like to change about this user: ");
							Console.WriteLine("1) Change username\n2) Change password\n3) Change first name\n4) Change last name\n5) Change address\n6) Change e-mail\n7) Change phone number\n8) Change role\n9) Stop editing this user\n=======================================");
							while (!UserEditSucces)
							{
								userInput = Console.ReadLine();
								UserEditSucces = int.TryParse(userInput, out int number);
								if (number < 1 || number > 9) { UserEditSucces = false; }
								if (UserEditSucces) { EditUserChoice = number; }
								else
								{
									Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
									Console.WriteLine("Please enter a number between 1 and 9");
								}
							}

							if (EditUserChoice == 1)
							{
								input_message = "Enter a new username:";
								error_message = "Please enter a valid username";
								usersList.Users[EditUserIndex].UserName = Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "");
							}
							else if (EditUserChoice == 2)
							{
								input_message = "Enter a new password:";
								error_message = "Please enter a valid password";
								usersList.Users[EditUserIndex].UserPassword = Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "");
							}
							else if (EditUserChoice == 3)
							{
								input_message = "Enter a new first name:";
								error_message = "Please enter a valid first name";
								usersList.Users[EditUserIndex].UserFirstName = Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "");
							}
							else if (EditUserChoice == 4)
							{
								input_message = "Enter a new last name:";
								error_message = "Please enter a valid last name";
								usersList.Users[EditUserIndex].UserLastName = Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "");
							}
							else if (EditUserChoice == 5)
							{
								input_message = "Enter a new street name:";
								error_message = "Please enter a valid street name";
								usersList.Users[EditUserIndex].UserStreetName = Error_Exception_String(input_message, error_message, false, false, 1, 100, true, "", "");

								input_message = "Enter a new house number:";
								error_message = "Please enter a number between 1 and 99999";
								usersList.Users[EditUserIndex].UserHouseNumber = Error_Exception_Int(input_message, error_message, 1, 99999).ToString();

								input_message = "Enter the first four digits of the new postal code:";
								error_message = "Please enter a valid postal code";
								userPostCode = Error_Exception_String(input_message, error_message, true, true, 4, 4, false, "", "");

								input_message = "Enter the last two letters of the new postal code: ";
								error_message = "Please enter two letters";
								userPostCode += Error_Exception_String(input_message, error_message, false, true, 2, 2, false, "", "").ToUpper();
								usersList.Users[EditUserIndex].UserPostalCode = userPostCode;

								input_message = "Enter your new place of residence:";
								error_message = "Please enter a valid place of residence";
								usersList.Users[EditUserIndex].UserResidencyName = Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "");
							}
							else if (EditUserChoice == 6)
							{
								input_message = "Enter your new e-mail address:";
								error_message = "Please enter a valid e-mail address";
								usersList.Users[EditUserIndex].UserEmail = Error_Exception_String(input_message, error_message, false, false, 0, 0, true, "@", ".");
							}
							else if (EditUserChoice == 7)
							{
								input_message = "Enter your new telephonenumber:";
								error_message = "Please enter a valid telephonenumber";
								usersList.Users[EditUserIndex].UserPhoneNumber = Error_Exception_String(input_message, error_message, true, true, 10, 10, false, "", "");
							}
							else if (EditUserChoice == 8)
							{
								while (!roleSuccess)
								{
									Console.WriteLine("Enter the new role name:");
									userInput = Console.ReadLine();
									if (string.IsNullOrEmpty(userInput)) { roleSuccess = false; }
									else { roleSuccess = true; }
									if (userInput == "customer" || userInput == "employee" || userInput == "admin" && roleSuccess) { usersList.Users[EditUserIndex].UserRole = userInput; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a valid role");
									}
								}
							}
							else if (EditUserChoice == 9)
							{
								Continue_UserEdit = false;
							}
							string json = JsonConvert.SerializeObject(usersList, Formatting.Indented);
							File.WriteAllText(PathUser, json);
						}
					}
				}
				if (usersList.Users.Count > 1)
				{
					Console.Write("Would you like to edit another user?");
					bool Return = util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopEditUser = false; }
				}
				else
				{
					return;
				}
			}
		}
		public static void FoodEdit()
		{
			string userInput;
			int EditFoodChoice = 0;
			bool foodSuccess = false;
			bool drinksSuccess = false;
			bool foodAndDrinksSuccess = false;
			bool menuEditSuccess = false;

			Console.Clear();
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Incase you want to return to the menu type: 'return'");
			Console.WriteLine("-----------------------------\nThese are the current prices for our food arrangements.");
			Console.WriteLine("1) Drinks $" + menusList.Menus[0].DrinksPrice);
			Console.WriteLine("2) Food $" + menusList.Menus[0].FoodPrice);
			Console.WriteLine("3) Food and Drinks $" + menusList.Menus[0].FoodAndDrinksPrice + "\n-----------------------------\n");

			Console.WriteLine("Choose the menu item that you want to edit(use 1-3)");
			while (!menuEditSuccess)
			{
				userInput = Console.ReadLine();
				if (userInput == "return")
				{
					Console.Write("Would you like to return to the menu");
					bool Return = util.CheckYN();
					if (Return == true) { menuEditSuccess = true; return; }
					if (Return == false) { Console.WriteLine("");}
				}
				else
				{
					menuEditSuccess = int.TryParse(userInput, out int number);
					if (number < 1 || number > 3) { menuEditSuccess = false; }
					if (menuEditSuccess) { EditFoodChoice = number; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 1 and 3");
					}
				}
			}
			if (EditFoodChoice == 1)
			{
				while (!drinksSuccess)
				{
					Console.WriteLine("Enter a price for the drinks arrangement:");
					userInput = Console.ReadLine();
					if (userInput == "return")
					{
						Console.Write("Would you like to return to the menu");
						bool Return = util.CheckYN();
						if (Return == true) { drinksSuccess = true; return; }
						if (Return == false) { Console.WriteLine(""); }
					}
					else
					{
						drinksSuccess = double.TryParse(userInput, out double number);
						if (drinksSuccess) { menusList.Menus[0].DrinksPrice = number;
							string json = JsonConvert.SerializeObject(menusList, Formatting.Indented);
							File.WriteAllText(PathMenu, json);
						}
						else
						{
							Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
							Console.WriteLine("Please use digits only");
						}
						Console.Write("Would you like to edit another menu item");
						bool Return = util.CheckYN();
						if (Return == true) { FoodEdit(); }
						if (Return == false) { return; }
					}
				}
			}
			else if (EditFoodChoice == 2)
			{
				while (!foodSuccess)
				{
					Console.WriteLine("Enter a price for the food arrangement:");
					userInput = Console.ReadLine();

					if (userInput == "return")
					{
						Console.Write("Would you like to return to the menu");
						bool Return = util.CheckYN();
						if (Return == true) { foodSuccess = true; return; }
						if (Return == false) { Console.WriteLine("");}
					}
					else
					{
						foodSuccess = double.TryParse(userInput, out double number);
						if (foodSuccess) { menusList.Menus[0].FoodPrice = number;
							string json = JsonConvert.SerializeObject(menusList, Formatting.Indented);
							File.WriteAllText(PathMenu, json);
						}
						else
						{
							Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
							Console.WriteLine("Please use digits only");
						}
						Console.Write("Would you like to edit another menu item");
						bool Return = util.CheckYN();
						if (Return == true) { FoodEdit(); }
						if (Return == false) { return; }
					}
				}
			}
			else if (EditFoodChoice == 3)
			{
				while (!foodAndDrinksSuccess)
				{
					Console.WriteLine("Enter a price for the food and drinks arrangement:");
					userInput = Console.ReadLine();
					if (userInput == "return")
					{
						Console.Write("Would you like to return to the menu");
						bool Return = util.CheckYN();
						if (Return == true) { foodAndDrinksSuccess = true; return; }
						if (Return == false) { Console.WriteLine(""); }
					}
					else
					{
						foodAndDrinksSuccess = double.TryParse(userInput, out double number);
						if (foodAndDrinksSuccess) { menusList.Menus[0].FoodAndDrinksPrice = number;
							string json = JsonConvert.SerializeObject(menusList, Formatting.Indented);
							File.WriteAllText(PathMenu, json);
						}
						else
						{
							Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
							Console.WriteLine("Please use digits only");
						}
						Console.Write("Would you like to edit another menu item");
						bool Return = util.CheckYN();
						if (Return == true) { FoodEdit(); }
						if (Return == false) { return; }
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
					Functions.Write("Oh no, your input did not fit!", ConsoleColor.Red);
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
					Functions.Write("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine(errormessage);
				}
			}
			return Int32.Parse(userInput);
		}
	}
}
