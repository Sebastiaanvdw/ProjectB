using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class Delete
	{
		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
		private static JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
		public static void Function()
		{
			bool LoopDeleteFunction = false;
			while (!LoopDeleteFunction)
			{
				Console.Clear();
				Console.WriteLine("=======================================\nWelcome to the Delete page.\n=======================================\n1) Delete an escape room\n2) Delete an user\n3) Delete a reservation\n4) Return to menu\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("4", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
				Functions.Write("Your input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { DeleteRoom(); }
				else if (input.Key == ConsoleKey.D2) { DeleteUser(); }
				else if (input.Key == ConsoleKey.D3) { DeleteReservation(); }
				else if (input.Key == ConsoleKey.D4) { return; }
				else { Console.Write("\n"); Functions.Error(); Functions.ATC(); }

			}
		}
		public static void DeleteRoom()
		{
			escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));
			bool LoopDeleteRoom = true;
			while (LoopDeleteRoom)
			{
				string userInput;
				int DeleteIndex = 0;
				bool DeleteInput = false;
				bool Roomchoicesucces = false;
				bool Deleteroomsucces = false;
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
						Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
						Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
						Console.WriteLine("Price per participant:		" + "€" + escapeRoomsList.EscapeRooms[i].RoomPrice);
						Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
						Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n==============================================================================");
					}
				}
				Console.WriteLine("Enter the room number of the room you want to delete");
				while (!Roomchoicesucces)
				{
					userInput = Console.ReadLine();
					if (userInput == "")
					{
						bool Return = Util.ReturnToMenu();
						if (Return == true) { return; }
						if (Return == false) { }
					}
					Roomchoicesucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > escapeRoomsList.EscapeRooms.Count) { Roomchoicesucces = false; }
					if (Roomchoicesucces) { DeleteIndex = number; }
					else
					{
						Functions.ErrorMessage("Please enter a number between 1 and " + escapeRoomsList.EscapeRooms.Count);
					}
				}
				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					if (i == DeleteIndex - 1)
					{
						Console.Write("You are about to delete room : ");
						Functions.Write(DeleteIndex, ConsoleColor.Yellow);
						Console.Write(", are you sure?");
						while (!Deleteroomsucces)
						{
							Deleteroomsucces = Util.CheckYN();
							DeleteInput = Deleteroomsucces;
							Deleteroomsucces = true;
						}
						if (DeleteInput == true)
						{
							escapeRoomsList.EscapeRooms.RemoveAt(DeleteIndex - 1);
							Console.Write("\nThe room has ");
							Functions.Write("succesfully ", ConsoleColor.Green);
							Console.Write("been Deleted\n");
						}
						if (DeleteInput == false)
						{
							Console.Write("\nThe room has ");
							Functions.Write("not ", ConsoleColor.Red);
							Console.Write("been deleted\n");
						}
						string json = JsonConvert.SerializeObject(escapeRoomsList, Formatting.Indented);
						File.WriteAllText(PathEscapeRoom, json);
					}
				}
				if (escapeRoomsList.EscapeRooms.Count > 0)
				{
					for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
					{
						escapeRoomsList.EscapeRooms[i].RoomNumber = i + 1;
					}
				}
				if (escapeRoomsList.EscapeRooms.Count > 0)
				{
					Console.Write("Would you like to choose another room to delete?");
					bool Return = Util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopDeleteRoom = false; }
				}
				else
				{
					return;
				}
			}
		}
		public static void DeleteUser()
		{
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			bool LoopDeleteUser = true;
			while (LoopDeleteUser)
			{
				string userInput;
				int DeleteIndex = 0;
				bool DeleteInput = false;
				bool UserChoiceSucces = false;
				bool DeleteUserSucces = false;
				Console.Clear();
				Console.OutputEncoding = Encoding.UTF8;
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
				Console.WriteLine("Enter the userID of the user you want to delete");
				while (!UserChoiceSucces)
				{
					userInput = Console.ReadLine();
					if (userInput == "")
					{
						bool Return = Util.ReturnToMenu();
						if (Return == true) { return; }
						if (Return == false) { }
					}
					UserChoiceSucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > usersList.Users.Count) { UserChoiceSucces = false; }
					if (UserChoiceSucces) { DeleteIndex = number; }
					else
					{
						Functions.ErrorMessage("Please enter a number between 1 and " + usersList.Users.Count);
					}
				}
				for (int i = 0; i < usersList.Users.Count; i++)
				{
					if (i == DeleteIndex - 1)
					{
						Console.Write("You are about to delete user: ");
						Functions.Write(DeleteIndex, ConsoleColor.Yellow);
						Console.Write(", are you sure?");
						while (!DeleteUserSucces)
						{
							DeleteUserSucces = Util.CheckYN();
							DeleteInput = DeleteUserSucces;
							DeleteUserSucces = true;
						}
						if (DeleteInput == true)
						{
							usersList.Users.RemoveAt(DeleteIndex - 1);
							Console.Write("\nThe user has ");
							Functions.Write("succesfully ", ConsoleColor.Green);
							Console.Write("been deleted\n");
						}
						if (DeleteInput == false)
						{
							Console.Write("\nThe user has ");
							Functions.Write("not ", ConsoleColor.Red);
							Console.Write("been deleted\n");
						}
						string json = JsonConvert.SerializeObject(usersList, Formatting.Indented);
						File.WriteAllText(PathUser, json);
					}
				}
				if (usersList.Users.Count > 0)
				{
					for (int i = 0; i < usersList.Users.Count; i++)
					{
						usersList.Users[i].UserID = i + 1;
					}
				}
				if (usersList.Users.Count > 0)
				{
					Console.Write("Would you like to delete another user?");
					bool Return = Util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopDeleteUser = false; }
				}
				else
				{
					return;
				}
			}
		}
		public static void DeleteReservation()
		{
			reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));
			bool LoopDeleteReservation = true;
			while (LoopDeleteReservation)
			{
				string userInput;
				int DeleteIndex = 0;
				bool DeleteInput = false;
				bool ReservationChoiceSucces = false;
				bool DeleteReservationSucces = false;
				Console.Clear();
				if (reservationsList.Reservations.Count <= 0)
				{
					Console.WriteLine("No reservations have been created yet, you will be returned to the menu");
					Functions.ATC();
					return;
				}
				else
				{
					Console.OutputEncoding = Encoding.UTF8;
					Console.WriteLine("Reservation info:\n=======================================");
					for (int i = 0; i < reservationsList.Reservations.Count; i++)
					{
						Console.WriteLine("Reservation Number:	" + reservationsList.Reservations[i].ReservationNumber);
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
				}
				Console.WriteLine("Enter the number of the reservation you want to delete");
				while (!ReservationChoiceSucces)
				{
					userInput = Console.ReadLine();
					if (userInput == "")
					{
						bool Return = Util.ReturnToMenu();
						if (Return == true) { return; }
						if (Return == false) { }
					}
					ReservationChoiceSucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > reservationsList.Reservations.Count) { ReservationChoiceSucces = false; }
					if (ReservationChoiceSucces) { DeleteIndex = number; }
					else
					{
						Functions.ErrorMessage("Please enter a number between 1 and " + reservationsList.Reservations.Count);
					}
				}
				for (int i = 0; i < reservationsList.Reservations.Count; i++)
				{
					if (i == DeleteIndex - 1)
					{
						Console.Write("You are about to delete reservation: ");
						Functions.Write(DeleteIndex, ConsoleColor.Yellow);
						Console.Write(", are you sure?");
						while (!DeleteReservationSucces)
						{
							DeleteReservationSucces = Util.CheckYN();
							DeleteInput = DeleteReservationSucces;
							DeleteReservationSucces = true;
						}
						if (DeleteInput == true)
						{
							reservationsList.Reservations.RemoveAt(DeleteIndex - 1);
							Console.Write("\nThe reservation has ");
							Functions.Write("succesfully ", ConsoleColor.Green);
							Console.Write("been deleted\n");
						}
						if (DeleteInput == false)
						{
							Console.Write("\nThe reservation has ");
							Functions.Write("not ", ConsoleColor.Red);
							Console.Write("been deleted\n");
						}
						string json = JsonConvert.SerializeObject(reservationsList, Formatting.Indented);
						File.WriteAllText(PathReservation, json);
					}
				}
				if (reservationsList.Reservations.Count > 0)
				{
					for (int i = 0; i < reservationsList.Reservations.Count; i++)
					{
						reservationsList.Reservations[i].ReservationNumber = i + 1;
					}
				}
				if (reservationsList.Reservations.Count > 0)
				{
					Console.Write("Would you like to delete another reservation?");
					bool Return = Util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopDeleteReservation = false; }
				}
				else
				{
					return;
				}
			}
		}
	}
}
