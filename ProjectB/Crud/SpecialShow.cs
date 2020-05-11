using System;
using System.Collections.Generic;
using System.Text;
using ProjectB;

namespace ProjectB.Crud
{
	class SpecialShow
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			Console.Clear();
			if (RoomsList.Count <= 0)
			{
					Console.WriteLine("No rooms have been created yet, you will be returned to the menu, press any key to continue");
					Console.ReadKey(true);
					return;
				}
			else
			{
				Console.WriteLine("Room info:\n");
				for (int i = 0; i < RoomsList.Count; i++)
				{
					Console.WriteLine(RoomsList[i] + "\n");
				}
			}
		}
	}
}
