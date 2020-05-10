using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectB.Crud
{
	class Delete
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			string userInput;
			int DeleteIndex = 0;
			string DeleteInput = null;
			bool Roomchoicesucces = false;
			bool Deleteroomsucces = false;
			Console.Clear();
			SpecialShow.Function(RoomsList);
			if (RoomsList.Count == 0) { MainProgramma.ReturnMenuFunction(); }
			Console.WriteLine("Enter the room number of the room you want to delete");
			while (!Roomchoicesucces)
			{
				userInput = Console.ReadLine();
				Roomchoicesucces = int.TryParse(userInput, out int number);
				if (number < 1 || number > RoomsList.Count) { Roomchoicesucces = false; }
				if (Roomchoicesucces) { DeleteIndex = number; }
				else
				{
					Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
					Console.WriteLine("Please enter a number between 1 and " + RoomsList.Count);
				}
			}
			for (int i = 0; i < RoomsList.Count; i++)
			{
				if (i == DeleteIndex - 1)
				{
					Console.WriteLine("You are about to delete room : " + DeleteIndex + ", are you sure? enter y or n");
					while (!Deleteroomsucces)
					{
						userInput = Console.ReadLine();
						userInput = userInput.ToLower();
						if (userInput == "y" || userInput == "n") { Deleteroomsucces = true; }
						if (Deleteroomsucces) { DeleteInput = userInput; }
						else
						{
							Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
							Console.WriteLine("Please enter 'y' or 'n'");
						}
						
					}
					if (DeleteInput == "y")
					{
						RoomsList.RemoveAt(DeleteIndex-1);
						Console.WriteLine("The room has succesfully been Deleted");
					}
					if (DeleteInput == "n")
					{
						Console.WriteLine("The room has NOT been deleted");
					}
				}

			}
			if (RoomsList.Count > 0)
			{
				for (int i = 0; i < RoomsList.Count; i++)
				{
					RoomsList[i].roomNumber = i + 1;
				}
			}
			MainProgramma.ReturnMenuFunction();
		}
	}
}
