using System;
using System.Collections.Generic;

namespace ProjectB.Crud
{
	class SpecialShow
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			Console.Clear();
			if (RoomsList.Count <= 0)
			{
				Console.WriteLine("ERROR NO ROOM HAS BEEN CREATED YET!");
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
