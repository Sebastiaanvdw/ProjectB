using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class Edit
	{
		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

		private static readonly string PathMenu = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"MenuDatabase.json");
		private static JSONMenuList menusList = JsonConvert.DeserializeObject<JSONMenuList>(File.ReadAllText(PathMenu));

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
				else { Console.Write("\n"); Functions.Error(); Functions.ATC();}
				
			}
		}
		public static void EditEscapeRoom()
		{
			escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));
			bool LoopEditRoom = true;
			while (LoopEditRoom)
			{
				Console.Clear();
				if (escapeRoomsList.EscapeRooms.Count <= 0)
				{
					Console.WriteLine("No rooms have been created yet, you will be returned to the menu");
					Functions.ATC();
					return;
				}
				else
				{
					Console.Clear();
					Console.OutputEncoding = Encoding.UTF8;
					Console.WriteLine("Room info:\n==============================================================================");
					for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
					{
						Console.WriteLine("Room number			" + escapeRoomsList.EscapeRooms[i].RoomNumber);
						Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
						Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
						Console.WriteLine("Price per participant:		" + "€" + escapeRoomsList.EscapeRooms[i].RoomPrice);
						Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
						Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n==============================================================================");
					}
				}

				input_message = "Choose which room you want to edit(use a roomnumber 1-" + escapeRoomsList.EscapeRooms.Count + ")";
				error_message = "Please enter a number between 1 and " + escapeRoomsList.EscapeRooms.Count;
				int EditRoomIndex = Functions.Error_Exception_Int(input_message, error_message, 1, escapeRoomsList.EscapeRooms.Count) - 1;

				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					if (i == EditRoomIndex)
					{
						bool Continue_RoomEdit = true;
						while (Continue_RoomEdit)
						{
							string json = JsonConvert.SerializeObject(escapeRoomsList, Formatting.Indented);
							Console.Clear();
							Console.WriteLine(escapeRoomsList.EscapeRooms[EditRoomIndex].RoomName + "\n");

							input_message = "Choose what you would like to change about the room: \n1) Change name\n2) Change minimum age\n3) Change amount of players\n4) Change price\n5) Change duration\n6) Change theme\n7) Stop editing this room";
							error_message = "Please enter a number between 1 and 7";
							int EditRoomChoice = Functions.Error_Exception_Int(input_message, error_message, 1, 7);

							if (EditRoomChoice == 1)
							{
								input_message = "Enter a name for the escape room:";
								error_message = "Please use alphabetic characters only";
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomName = Functions.Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "", false);
							}
							else if (EditRoomChoice == 2)
							{
								input_message = "Enter the minimum age for the escape room (between 12-100:";
								error_message = "Please enter a number between 12-100";
								escapeRoomsList.EscapeRooms[EditRoomIndex].AgeMinimum = Functions.Error_Exception_Int(input_message, error_message, 12, 100);
							}
							else if (EditRoomChoice == 3)
							{
								input_message = "Enter the minimum amount of players for the escape room (between 2-5):";
								error_message = "Please enter a number between 2-5";
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize = Functions.Error_Exception_Int(input_message, error_message, 2, 5);

								input_message = "Enter the maximum amount of players for the escape room: (between" + (escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize + 1) + "-6";
								error_message = "Please enter a valid number inbetween " + (escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize + 1) + "-6";
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMaxSize = Functions.Error_Exception_Int(input_message, error_message, escapeRoomsList.EscapeRooms[EditRoomIndex].RoomMinSize, 6);
							}
							else if (EditRoomChoice == 4)
							{
								input_message = "Enter the price for the escape room (price is per participant):";
								error_message = "Please enter a number above 0, if it's a decimal number use ','.";
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomPrice = Functions.Error_Exception_Double(input_message, error_message, 1, 99999);
							}
							else if (EditRoomChoice == 5)
							{
								input_message = "Enter the duration for the esacpe room in hours (max 2 hours)";
								error_message = "Please enter a positive number, if you want to enter a decimal number use a ','";
								var temp = Functions.Error_Exception_Double(input_message, error_message, 0.1, 2);
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomDuration = new TimeSpan(Convert.ToInt32(Math.Truncate(temp)), Convert.ToInt32(Math.Round((temp - Math.Truncate(temp)) * 60)), 0);
							}
							else if (EditRoomChoice == 6)
							{
								input_message = "Enter a theme for the escape room:";
								error_message = "Please use alphabetic characters only";
								escapeRoomsList.EscapeRooms[EditRoomIndex].RoomTheme = Functions.Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "", false);
							}
							else if (EditRoomChoice == 7)
							{
								File.WriteAllText(PathEscapeRoom, json);
								Continue_RoomEdit = false;
							}
							File.WriteAllText(PathEscapeRoom, json);
						}
					}
				}
				if (escapeRoomsList.EscapeRooms.Count > 1)
				{
					Console.Write("Would you like to edit another room?");
					bool Return = Util.CheckYN();
					if (Return == true) { File.ReadAllText(PathEscapeRoom); }
					if (Return == false) { File.ReadAllText(PathEscapeRoom); return; }
				}
				else
				{
					return;
				}
			}
		}
		public static void EditUser()
		{
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			bool LoopEditUser = true;
			while (LoopEditUser)
			{
				string userInput;
				Console.Clear();
				if (usersList.Users.Count <= 0)
				{
					Console.WriteLine("No users have been created yet, you will be returned to the menu, press any key to continue");
					Console.ReadKey(true);
					return;
				}
				else
				{
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
				}

				input_message = "Choose the user that you want to edit(1-" + usersList.Users.Count + ")";
				error_message = "Please enter a number between 1 and " + usersList.Users.Count;
				int EditUserIndex = Functions.Error_Exception_Int(input_message, error_message, 1, usersList.Users.Count);

				for (int i = 0; i < usersList.Users.Count; i++)
				{
					if (i == EditUserIndex)
					{
						bool Continue_UserEdit = true;
						while (Continue_UserEdit)
						{
							string json = JsonConvert.SerializeObject(usersList, Formatting.Indented);
							bool roleSuccess = false;
							Console.Clear();
							Console.WriteLine(usersList.Users[EditUserIndex].UserFirstName + " " + usersList.Users[EditUserIndex].UserLastName + "\n");

							input_message = "Choose what you would like to change about this user: \n1) Change username\n2) Change password\n3) Change first name\n4) Change last name\n5) Change address\n6) Change e-mail\n7) Change phone number\n8) Change role\n9) Stop editing this user\n=======================================";
							error_message = "Please enter a number between 1 and 9";
							int EditUserChoice = Functions.Error_Exception_Int(input_message, error_message, 1, 9);

							if (EditUserChoice == 1)
							{
								input_message = "Enter a new username:";
								error_message = "Please enter a valid username";
								usersList.Users[EditUserIndex].UserName = Functions.Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "", true);
							}
							else if (EditUserChoice == 2)
							{
								input_message = "Enter a new password:";
								error_message = "Please enter a valid password";
								usersList.Users[EditUserIndex].UserPassword = Functions.Error_Exception_String(input_message, error_message, false, false, 1, 20, true, "", "", true);
							}
							else if (EditUserChoice == 3)
							{
								input_message = "Enter a new first name:";
								error_message = "Please enter a valid first name";
								usersList.Users[EditUserIndex].UserFirstName = Functions.Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "", false);
							}
							else if (EditUserChoice == 4)
							{
								input_message = "Enter a new last name:";
								error_message = "Please enter a valid last name";
								usersList.Users[EditUserIndex].UserLastName = Functions.Error_Exception_String(input_message, error_message, false, false, 1, 50, true, "", "", false);
							}
							else if (EditUserChoice == 5)
							{
								input_message = "Enter a new street name:";
								error_message = "Please enter a valid street name";
								usersList.Users[EditUserIndex].UserStreetName = Functions.Error_Exception_String(input_message, error_message, false, false, 1, 100, true, "", "", false);

								input_message = "Enter a new house number:";
								error_message = "Please enter a number between 1 and 99999";
								usersList.Users[EditUserIndex].UserHouseNumber = Functions.Error_Exception_Int(input_message, error_message, 1, 99999).ToString();

								input_message = "Enter the first four digits of the new postal code:";
								error_message = "Please enter a valid postal code";
								userPostCode = Functions.Error_Exception_String(input_message, error_message, true, true, 4, 4, false, "", "", false);

								input_message = "Enter the last two letters of the new postal code: ";
								error_message = "Please enter two letters";
								userPostCode += Functions.Error_Exception_String(input_message, error_message, false, true, 2, 2, false, "", "", false).ToUpper();
								usersList.Users[EditUserIndex].UserPostalCode = userPostCode;

								input_message = "Enter your new place of residence:";
								error_message = "Please enter a valid place of residence";
								usersList.Users[EditUserIndex].UserResidencyName = Functions.Error_Exception_String(input_message, error_message, false, false, 0, 0, false, "", "", false);
							}
							else if (EditUserChoice == 6)
							{
								input_message = "Enter your new e-mail address:";
								error_message = "Please enter a valid e-mail address";
								usersList.Users[EditUserIndex].UserEmail = Functions.Error_Exception_String(input_message, error_message, false, false, 0, 0, true, "@", ".", true);
							}
							else if (EditUserChoice == 7)
							{
								input_message = "Enter your new telephonenumber:";
								error_message = "Please enter a valid telephonenumber";
								usersList.Users[EditUserIndex].UserPhoneNumber = Functions.Error_Exception_String(input_message, error_message, true, true, 10, 10, false, "", "", false);
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
										Functions.ErrorMessage("Please enter a valid role");
									}
								}
							}
							else if (EditUserChoice == 9)
							{
								File.WriteAllText(PathUser, json);
								Continue_UserEdit = false;
							}
							File.WriteAllText(PathUser, json);
						}
					}
				}
				if (usersList.Users.Count > 1)
				{
					Console.Write("Would you like to edit another user?");
					bool Return = Util.CheckYN();
					if (Return == true) { File.ReadAllText(PathUser); }
					if (Return == false) { File.ReadAllText(PathUser); LoopEditUser = false;}
				}
				else
				{
					return;
				}
			}
		}
		public static void FoodEdit()
		{
			bool LoopFoodEdit = true;
			while (LoopFoodEdit)
			{
				menusList = JsonConvert.DeserializeObject<JSONMenuList>(File.ReadAllText(PathMenu));
				Console.Clear();
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Incase you want to return to the menu type: 'return'");
				Console.WriteLine("-----------------------------\nThese are the current prices for our food arrangements.");
				Console.WriteLine("1) Drinks $" + menusList.Menus[0].DrinksPrice);
				Console.WriteLine("2) Food $" + menusList.Menus[0].FoodPrice);
				Console.WriteLine("3) Food and Drinks $" + menusList.Menus[0].FoodAndDrinksPrice + "\n-----------------------------\n");

				input_message = "Choose the menu item that you want to edit (use 1-3)";
				error_message = "Please enter a number between 1 and 3";
				int EditFoodChoice = Functions.Error_Exception_Int(input_message, error_message, 1, 3);

				if (EditFoodChoice == 1)
				{
					input_message = "Enter a price for the drinks arrangement:";
					error_message = "Please use digits only";
					menusList.Menus[0].DrinksPrice = Functions.Error_Exception_Double(input_message, error_message, 1, 9999);
				}
				else if (EditFoodChoice == 2)
				{
					input_message = "Enter a price for the food arragement:";
					error_message = "Please use digits only";
					menusList.Menus[0].FoodPrice = Functions.Error_Exception_Int(input_message, error_message, 1, 99999);
				}
				else if (EditFoodChoice == 3)
				{
					input_message = "Enter a price for the food a drinks arrangement:";
					error_message = "Please use digits only";
					menusList.Menus[0].FoodAndDrinksPrice = Functions.Error_Exception_Int(input_message, error_message, 1, 99999);
				}
				string json = JsonConvert.SerializeObject(menusList, Formatting.Indented);
				File.WriteAllText(PathMenu, json);
				Console.Write("Would you like to edit another menu item?");
				bool Return = Util.CheckYN();
				if (Return == true) { }
				if (Return == false) { return; }
			}

		}
	}
}
