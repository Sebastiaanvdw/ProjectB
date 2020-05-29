//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Y_or_N;

//namespace ProjectB.Crud
//{
//	class Delete
//	{
//		public static void Function(List<EscapeRoom> RoomsList)
//		{
//			bool LoopDeleteRoom = true;
//			while (LoopDeleteRoom)
//			{	
//				string userInput;
//				int DeleteIndex = 0;
//				bool DeleteInput = false;
//				bool Roomchoicesucces = false;
//				bool Deleteroomsucces = false;
//				Console.Clear();
//				SpecialShow.Function(RoomsList);
//				if (RoomsList.Count == 0) { return; } //MainProgramma.ReturnMenuFunction(); }
//				Console.WriteLine("Enter the room number of the room you want to delete");
//				while (!Roomchoicesucces)
//				{
//					userInput = Console.ReadLine();
//					if (userInput == "")
//					{
//						Console.Write("Return to the main menu? press ");
//						Functions.Write("y", ConsoleColor.Yellow);
//						Console.Write(" or ");
//						Functions.Write("n", ConsoleColor.Yellow);
//						bool Return = util.CheckYN();
//						if (Return == true) { return; }
//						if (Return == false) { }
//					}
//					Roomchoicesucces = int.TryParse(userInput, out int number);
//					if (number < 1 || number > RoomsList.Count) { Roomchoicesucces = false; }
//					if (Roomchoicesucces) { DeleteIndex = number; }
//					else
//					{
//						Functions.Error();
//						Console.WriteLine("Please enter a number between 1 and " + RoomsList.Count);
//					}
//				}
//				for (int i = 0; i < RoomsList.Count; i++)
//				{
//					if (i == DeleteIndex - 1)
//					{
//						Console.Write("You are about to delete room : ");
//						Functions.Write(DeleteIndex, ConsoleColor.Yellow);
//						Console.Write(", are you sure? press ");
//						Functions.Write("y", ConsoleColor.Yellow);
//						Console.Write(" or ");
//						Functions.Write("n", ConsoleColor.Yellow);

//						while (!Deleteroomsucces)
//						{
//							Deleteroomsucces = util.CheckYN();
//							DeleteInput = Deleteroomsucces;
//							Deleteroomsucces = true;
//						}
//						if (DeleteInput == true)
//						{
//							RoomsList.RemoveAt(DeleteIndex - 1);
//							Console.Write("\nThe room has ");
//							Functions.Write("succesfully ", ConsoleColor.Green);
//							Console.Write("been Deleted\n");
//						}
//						if (DeleteInput == false)
//						{
//							Console.Write("\nThe room has ");
//							Functions.Write("not ", ConsoleColor.Red);
//							Console.Write("been deleted\n");
//						}
//					}
//				}
//				if (RoomsList.Count > 0)
//				{
//					for (int i = 0; i < RoomsList.Count; i++)
//					{
//						RoomsList[i].roomNumber = i + 1;
//					}
//				}
//				if (RoomsList.Count > 0)
//				{
//					Console.Write("Would you like to choose another room to delete, press ");
//					Functions.Write("y", ConsoleColor.Yellow);
//					Console.Write(" or ");
//					Functions.Write("n", ConsoleColor.Yellow);
//					bool Return = util.CheckYN();
//					if (Return == true) { }
//					if (Return == false) { LoopDeleteRoom = false; }
//				}
//				else
//				{
//					return;
//				}
//			}
//		}
//	}
//}
