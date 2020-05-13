﻿using System;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;
namespace ProjectB.Crud
{
	class Edit
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			bool LoopEditRoom = true;
			while (LoopEditRoom)
			{
				string userInput;
				int EditRoomIndex = 0;
				int EditRoomChoice = 0;
				bool RoomIndexSucces = false;

				Console.Clear();
				SpecialShow.Function(RoomsList);

				if (RoomsList.Count == 0) 
				{
					return;
				} //MainProgramma.ReturnMenuFunction(); }

				Console.WriteLine("Choose the room that you want to edit(use a roomnumber 1-" + RoomsList.Count + ")");
				while (!RoomIndexSucces)
				{
					userInput = Console.ReadLine();
					RoomIndexSucces = int.TryParse(userInput, out int number);
					if (number < 1 || number > RoomsList.Count) { RoomIndexSucces = false; }
					if (RoomIndexSucces) { EditRoomIndex = number - 1; }
					else
					{
						Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
						Console.WriteLine("Please enter a number between 1 and " + RoomsList.Count);
					}
				}

				for (int i = 0; i < RoomsList.Count; i++)
				{
					if (i == EditRoomIndex)
					{
						bool Continue_RoomEdit = true;
						while (Continue_RoomEdit)
						{
							bool RoomEditSucces = false;
							bool priceSuccess = false;
							bool themeSuccess = false;
							bool minSuccess = false;
							bool maxSuccess = false;
							bool ageSuccess = false;
							bool durationSuccess = false;
							bool nameSuccess = false;
							Console.Clear();
							Console.WriteLine(RoomsList[EditRoomIndex] + "\n");
							Console.WriteLine("Choose what you would like to change about the room: ");
							Console.WriteLine("1) Change name\n2) Change minimum age\n3) Change amount of players\n4) Change price\n5) Change duration\n6) Change theme\n7) Stop editing this room");
							while (!RoomEditSucces)
							{
								userInput = Console.ReadLine();
								RoomEditSucces = int.TryParse(userInput, out int number);
								if (number < 1 || number > 7) { RoomEditSucces = false; }
								if (RoomEditSucces) { EditRoomChoice = number; }
								else
								{
									Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
									Console.WriteLine("Please enter a number between 1 and 7");
								}
							}

							if (EditRoomChoice == 1)
							{
								while (!nameSuccess)
								{
									Console.WriteLine("Enter a name for the escape room:");
									userInput = Console.ReadLine();
									if (string.IsNullOrEmpty(userInput)) { nameSuccess = false; }
									else { nameSuccess = true; }
									if (nameSuccess) { RoomsList[EditRoomIndex].roomName = userInput; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please use alphabetic characters only");
									}
								}
							}
							else if (EditRoomChoice == 2)
							{
								while (!ageSuccess)
								{
									Console.WriteLine("Enter the minimum age for the escape room (between 12-100):");
									userInput = Console.ReadLine();
									ageSuccess = int.TryParse(userInput, out int number);
									if (number < 12 || number > 100) { ageSuccess = false; }
									if (ageSuccess) { RoomsList[EditRoomIndex].ageMinimum = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number between 12-100");
									}
								}
							}
							else if (EditRoomChoice == 3)
							{
								while (!minSuccess)
								{
									Console.WriteLine("Enter the minimum amount of players for the escape room (between 2-5):");
									userInput = Console.ReadLine();
									minSuccess = int.TryParse(userInput, out int number);
									if (number < 2 || number > 5) { minSuccess = false; }
									if (minSuccess) { RoomsList[EditRoomIndex].roomMinSize = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number between 2-5");
									}
								}

								while (!maxSuccess)
								{
									Console.WriteLine("Enter the maximum amount of players for the escape room: (between" + (RoomsList[EditRoomIndex].roomMinSize + 1) + "-6");
									userInput = Console.ReadLine();
									maxSuccess = int.TryParse(userInput, out int number);
									if (number <= RoomsList[EditRoomIndex].roomMinSize || number > 6) { maxSuccess = false; }
									if (maxSuccess) { RoomsList[EditRoomIndex].roomMaxSize = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a valid number inbetween " + (RoomsList[EditRoomIndex].roomMinSize + 1) + "-6");
									}
								}
							}
							else if (EditRoomChoice == 4)
							{
								while (!priceSuccess)
								{
									Console.WriteLine("Enter the price for the escape room (price is per participant):");
									userInput = Console.ReadLine();
									priceSuccess = Double.TryParse(userInput, out double number);
									if (number < 1) { priceSuccess = false; }
									if (priceSuccess) { RoomsList[EditRoomIndex].roomPrice = number; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please enter a number above 0.");
									}
								}
							}
							else if (EditRoomChoice == 5)
							{
								while (!durationSuccess)
								{
									Console.WriteLine("Enter the duration for the escape room in hours (e.g. '1,5'):");
									userInput = Console.ReadLine();
									durationSuccess = double.TryParse(userInput, out double number);
									if (number < 0 || number > 5) { durationSuccess = true; }
									if (durationSuccess) { RoomsList[EditRoomIndex].roomDuration = Math.Truncate(number).ToString() + " hour(s) and " + Math.Round((number - Math.Truncate(number)) * 60).ToString() + " minutes"; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please try again");
									}
								}
							}
							else if (EditRoomChoice == 6)
							{
								while (!themeSuccess)
								{
									Console.WriteLine("Enter a theme for the escape room:");
									userInput = Console.ReadLine();
									themeSuccess = userInput.All(c => Char.IsLetter(c));
									if (string.IsNullOrEmpty(userInput)) { themeSuccess = false; }
									if (themeSuccess) { RoomsList[EditRoomIndex].roomTheme = userInput; }
									else
									{
										Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
										Console.WriteLine("Please use alphabetic characters only");
									}
								}
							}
							else if (EditRoomChoice == 7)
							{
								Continue_RoomEdit = false;
							}
						}
					}
				}
				if (RoomsList.Count > 1)
				{
					Console.Write("Would you like to edit another room, press");
					Functions.Write("y", ConsoleColor.Yellow);
					Console.Write(" or ");
					Functions.Write("n", ConsoleColor.Yellow);
					bool Return = util.CheckYN();
					if (Return == true) { }
					if (Return == false) { LoopEditRoom = false; }
				}
				else
				{
					return;
				}
			}
		}
	}
}
