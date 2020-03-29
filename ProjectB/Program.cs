using System;
using System.Collections.Generic;
using ProjectB.Crud;

class MainProgramma
{
	public static List<EscapeRoom> RoomsList = new List<EscapeRoom>();

	public static void Main()
	{


		Console.WriteLine("1: Add room\n2: Edit room\n3: Delete room");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());

		if (InterFaceInput == 1) { AddFunction(RoomsList); }
		if (InterFaceInput == 2) { EditFunction(RoomsList); }
		if (InterFaceInput == 3) { DeleteFunction(RoomsList); }

		static void AddFunction(List<EscapeRoom> RoomsList)
		{
			if (RoomsList.Count > 0 & RoomsList.Count < 4)
			{
				RoomsList.Add(new EscapeRoom() { });
				int NewIndex = RoomsList.Count - 1;
				if (RoomsList.Count == 1) { NewIndex = 0; }
				RoomsList[NewIndex].roomNumber = NewIndex + 1;

				Console.WriteLine("Enter the minimum age for the escape room:");
				RoomsList[NewIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());

				while (!(RoomsList[NewIndex].roomSize > 6 & RoomsList[NewIndex].roomSize < 2))
					Console.WriteLine("Enter the amount of players for the escape room:");
				if (RoomsList[NewIndex].roomSize < 2 & RoomsList[NewIndex].roomSize > 6) { RoomsList[NewIndex].roomSize = Convert.ToInt32(Console.ReadLine()); }
				else { Console.WriteLine("Please enter a valid number inbetween 2-6"); }

				Console.WriteLine("Enter the price for the escape room:");
				RoomsList[NewIndex].roomPrice = Convert.ToDouble(Console.ReadLine());

				Console.WriteLine("Enter the theme for the escape room:");
				RoomsList[NewIndex].roomTheme = Console.ReadLine();

				Console.WriteLine("Enter the duration for the escape room:");
				RoomsList[NewIndex].roomDuration = Console.ReadLine();

				Console.WriteLine("Enter the name for the escape room:");
				RoomsList[NewIndex].roomName = Console.ReadLine();

				Console.WriteLine("Room Complete!");
				Console.Clear();
				Main();
			}

			else
			{
				Console.WriteLine("There are already 5 EscapeRooms existing!");
			}
		}

		static void EditFunction(List<EscapeRoom> RoomsList)
		{

		}

		static void DeleteFunction(List<EscapeRoom> RoomsList)
		{

		}
	}

}
