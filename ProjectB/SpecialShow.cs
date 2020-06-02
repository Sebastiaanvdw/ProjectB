using System;
using System.Collections.Generic;
using Y_or_N;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class SpecialShow
	{
		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

		private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
		private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
		public static void EscapeRoom()
		{
			Console.Clear();
			if (escapeRoomsList.EscapeRooms.Count <= 0)
			{
					Console.WriteLine("No rooms have been created yet, you will be returned to the menu, press any key to continue");
					Console.ReadKey(true);
					return;
				}
			else
			{
				string json = JsonConvert.SerializeObject(escapeRoomsList, Formatting.Indented);
				Console.Clear();
				Console.WriteLine(json);
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
		}

		public static void User()
		{
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
		}
	}
}
