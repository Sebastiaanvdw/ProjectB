using System;
using System.Collections.Generic;
using System.Text;
using ProjectB;

namespace ProjectB.Crud
{
	class Add
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			if (RoomsList.Count >= 0 & RoomsList.Count < 5)
			{
				Console.Clear();
				RoomsList.Add(new EscapeRoom() { });
				int NewIndex = RoomsList.Count - 1;
				if (RoomsList.Count == 1) { NewIndex = 0; }
				RoomsList[NewIndex].roomNumber = NewIndex + 1;

				Console.WriteLine("Enter the minimum age for the escape room:");
				RoomsList[NewIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());
				while (RoomsList[NewIndex].ageMinimum < 12 || RoomsList[NewIndex].ageMinimum > 100)
				{
					Console.WriteLine("*****ERROR*****\nPlease enter a valid number between 12-100\n");
					Console.WriteLine("Enter the minimum age for the escape room:");
					RoomsList[NewIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());

				}

				while (RoomsList[NewIndex].roomMinSize < 2 || RoomsList[NewIndex].roomMinSize > 5)
				{
					Console.WriteLine("Enter the minimum amount of players for the escape room:");
					RoomsList[NewIndex].roomMinSize = Convert.ToInt32(Console.ReadLine());
					if (RoomsList[NewIndex].roomMinSize < 2 || RoomsList[NewIndex].roomMinSize > 5) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween 2-5\n"); }
				}

				while (RoomsList[NewIndex].roomMaxSize < RoomsList[NewIndex].roomMinSize || RoomsList[NewIndex].roomMaxSize > 6)
				{
					Console.WriteLine("Enter the maximum amount of players for the escape room:");
					RoomsList[NewIndex].roomMaxSize = Convert.ToInt32(Console.ReadLine());
					if (RoomsList[NewIndex].roomMaxSize <= RoomsList[NewIndex].roomMinSize || RoomsList[NewIndex].roomMaxSize > 6) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween " + (RoomsList[NewIndex].roomMinSize + 1) + "-6\n"); }
				}

				Console.WriteLine("Enter the price for the escape room:");
				RoomsList[NewIndex].roomPrice = Convert.ToDouble(Console.ReadLine());

				Console.WriteLine("Enter the theme for the escape room:");
				RoomsList[NewIndex].roomTheme = Console.ReadLine();

				Console.WriteLine("Enter the duration for the escape room:");
				RoomsList[NewIndex].roomDuration = Console.ReadLine();

				Console.WriteLine("Enter the name for the escape room:");
				RoomsList[NewIndex].roomName = Console.ReadLine();

				Console.WriteLine("Room Complete!");

			}

			else
			{
				Console.WriteLine("There are already 5 EscapeRooms existing!");
			}
			MainProgramma.ReturnMenuFunction();
		}
	}
}
