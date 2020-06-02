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
		private static readonly JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));
		public static void Function()
		{
			bool LoopDeleteRoom = true;
			while (LoopDeleteRoom)
			{
				string userInput;
				int DeleteIndex = 0;
				bool DeleteInput = false;
				bool Roomchoicesucces = false;
				bool Deleteroomsucces = false;
				Console.Clear();
				SpecialShow.EscapeRoom();
				if (escapeRoomsList.EscapeRooms.Count == 0) { return; } //MainProgramma.ReturnMenuFunction(); }
				Console.WriteLine("Enter the room number of the room you want to delete");
				while (!Roomchoicesucces)
				{
					userInput = Console.ReadLine();
					if (userInput == "")
					{
						bool Return = util.ReturnToMenu();
						if (Return == true) { return; }
						if (Return == false) { }
					}
					Roomchoicesucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > escapeRoomsList.EscapeRooms.Count) { Roomchoicesucces = false; }
					if (Roomchoicesucces) { DeleteIndex = number; }
					else
					{
						Functions.Error();
						Console.WriteLine("Please enter a number between 1 and " + escapeRoomsList.EscapeRooms.Count);
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
							Deleteroomsucces = util.CheckYN();
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
					bool Return = util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopDeleteRoom = false; }
				}
				else
				{
					return;
				}
			}
		}
	}
}
