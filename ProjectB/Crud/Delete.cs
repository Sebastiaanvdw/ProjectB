using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Crud
{
	class Delete
	{
		public static void Function(List<EscapeRoom> RoomsList)
		{
			Console.Clear();
			SpecialShow.Function(RoomsList);
			Console.WriteLine("Enter the room number of the room you want to delete");
			int DeleteIndex = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < RoomsList.Count; i++)
			{
				if (i == DeleteIndex - 1)
				{
					Console.WriteLine("You are about to delete room : " + DeleteIndex + ", are you sure? enter y or n");
					string DeleteInput = Console.ReadLine();
					if (DeleteInput == "y")
					{
						RoomsList.RemoveAt(DeleteIndex-1);
						Console.WriteLine("The room has succesfully been Deleted");
					}
					else
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
