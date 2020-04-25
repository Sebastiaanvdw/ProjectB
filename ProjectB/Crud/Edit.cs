using System;
using System.Collections.Generic;
using System.Text;
using ProjectB;

namespace ProjectB.Crud
{
	class Edit
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			Console.Clear();
			SpecialShow.Function(RoomsList);
			Console.WriteLine("Choose the room that you want to edit(use a roomnumber 1-" + RoomsList.Count + ")");
			int EditRoomIndex = Convert.ToInt32(Console.ReadLine()) - 1;
			for (int i = 0; i < RoomsList.Count; i++)
			{
				if (i == EditRoomIndex)
				{
					bool Continue_RoomEdit = true;
					while (Continue_RoomEdit)
					{
						Console.Clear();
						Console.WriteLine(RoomsList[EditRoomIndex] + "\n");
						Console.WriteLine("Choose what you would like to change about the room: ");
						Console.WriteLine("1) Change name\n2) Change minimum age\n3) Change amount of players\n4) Change price\n5) Change duration\n6) Change theme\n7) Back to menu");
						int EditRoomChoice = Convert.ToInt32(Console.ReadLine());
						if (EditRoomChoice == 1)
						{
							Console.WriteLine("Enter the name for the escape room:");
							RoomsList[EditRoomIndex].roomName = Console.ReadLine();
						}
						else if (EditRoomChoice == 2)
						{
							Console.WriteLine("Enter the minimum age for the escape room:");
							RoomsList[EditRoomIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());
							while (RoomsList[EditRoomIndex].ageMinimum < 12 || RoomsList[EditRoomIndex].ageMinimum > 100)
							{
								Console.WriteLine("*****ERROR*****\nPlease enter a valid number between 12-100\n");
								Console.WriteLine("Enter the minimum age for the escape room:");
								RoomsList[EditRoomIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());

							}

						}
						else if (EditRoomChoice == 3)
						{
							while (RoomsList[EditRoomIndex].roomMinSize < 2 || RoomsList[EditRoomIndex].roomMinSize > 5)
							{
								Console.WriteLine("Enter the minimum amount of players for the escape room:");
								RoomsList[EditRoomIndex].roomMinSize = Convert.ToInt32(Console.ReadLine());
								if (RoomsList[EditRoomIndex].roomMinSize < 2 || RoomsList[EditRoomIndex].roomMinSize > 5) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween 2-5\n"); }
							}

							while (RoomsList[EditRoomIndex].roomMaxSize < RoomsList[EditRoomIndex].roomMinSize || RoomsList[EditRoomIndex].roomMaxSize > 6)
							{
								Console.WriteLine("Enter the maximum amount of players for the escape room:");
								RoomsList[EditRoomIndex].roomMaxSize = Convert.ToInt32(Console.ReadLine());
								if (RoomsList[EditRoomIndex].roomMaxSize < RoomsList[EditRoomIndex].roomMinSize || RoomsList[EditRoomIndex].roomMaxSize > 6) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween " + RoomsList[EditRoomIndex].roomMinSize + " - 6\n"); }
							}
						}
						else if (EditRoomChoice == 4)
						{
							Console.WriteLine("Enter the price for the escape room:");
							RoomsList[EditRoomIndex].roomPrice = Convert.ToDouble(Console.ReadLine());
						}
						else if (EditRoomChoice == 5)
						{
							Console.WriteLine("Enter the duration for the escape room:");
							RoomsList[EditRoomIndex].roomDuration = Console.ReadLine();
						}
						else if (EditRoomChoice == 6)
						{
							Console.WriteLine("Enter the theme for the escape room:");
							RoomsList[EditRoomIndex].roomTheme = Console.ReadLine();
						}
						else if (EditRoomChoice == 7)
						{
							Continue_RoomEdit = false;
						}
						MainProgramma.ReturnMenuFunction();
					}
				}
			}
		}
	}
}
