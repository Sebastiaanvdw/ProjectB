using System;
using System.Collections.Generic;
using Y_or_N;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB
{
	class SpecialShow
	{
		private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));
		public static void Function()
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
				Console.WriteLine("Room info:\n");
				for (int i = 0; i < escapeRoomsList.EscapeRooms.Count; i++)
				{
					Console.WriteLine("Room number:			" + escapeRoomsList.EscapeRooms[i].RoomNumber);
					Console.WriteLine("Room:				" + escapeRoomsList.EscapeRooms[i].RoomName);
					Console.WriteLine("Theme:				" + escapeRoomsList.EscapeRooms[i].RoomTheme);
					Console.WriteLine("Price per participant:		" + escapeRoomsList.EscapeRooms[i].RoomPrice);
					Console.WriteLine("Minimum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMinSize);
					Console.WriteLine("Maximum amount of players:	" + escapeRoomsList.EscapeRooms[i].RoomMaxSize + "\n");
				}
			}
		}
	}
}
