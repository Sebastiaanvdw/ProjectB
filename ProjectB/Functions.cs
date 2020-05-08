using System;
using System.Collections.Generic;
using System.Text;
using ProjectB;
using ProjectB.Crud;

namespace ProjectB
{
	class Functions
	{
		public static void Contact()
		{
			Console.Clear();
			Console.WriteLine("Opening hours:\nMon to Thurs: 9:00am - 5:00pm\nFriday: 9:00am - 7:00pm\n\nTelephone number: 01034235423\n\nE-mail: EscapeMail@rooms.com\n\nLocation: Janpieterstraat 49 Rotterdam 3546WQ\n");

			MainProgramma.ReturnMenuFunction();
			
		}

		public static void ReceiptFunction()
		{
			while (true)
			{
				MainProgramma.userUniqueID = Guid.NewGuid().ToString();
				if (!MainProgramma.IDList.Contains(MainProgramma.userUniqueID))
				{
					MainProgramma.IDList.Add(MainProgramma.userUniqueID);
					break;
				}
			}

			var userTotalPrice = MainProgramma.RoomsList[MainProgramma.roomKeuze-1].roomPrice * MainProgramma.userParticipants;//hierbij moet ook nog + arrangementprijs; //Dit wordt in later berekend

			Console.Clear();
			Console.WriteLine("======================");
			Console.WriteLine("\nThe following room has been chosen: " + MainProgramma.RoomsList[Convert.ToInt32(MainProgramma.roomKeuze-1)].roomName);
			Console.WriteLine("Amount of participants: " + MainProgramma.userParticipants);
			Console.WriteLine("\nClient Name: " + MainProgramma.userName + " " + MainProgramma.userLastName);
			Console.WriteLine("\nClient Street: " + MainProgramma.userStreet + " " + MainProgramma.userHouseNumber);
			Console.WriteLine("\nClient Postcode: " + MainProgramma.userPostcode);
			Console.WriteLine("\nClient Woonplaats: " + MainProgramma.userWoonplaats);
			Console.WriteLine("\nClient Phonenumber: " + MainProgramma.userPhoneNumber);
			Console.WriteLine("\nTotal Price: " + userTotalPrice + "(Roomprice * Participants)");
			Console.WriteLine("\nClient UniqueID (Bring this to the desk): " + MainProgramma.userUniqueID);
			Console.WriteLine("\n\nThis will be send to the following email address: " + MainProgramma.userEmail);

			MainProgramma.ReturnMenuFunction();
		}
		public static void ReserveerFunction()
		{

			Console.Clear();

			Console.WriteLine("-----------------------------");
			Console.WriteLine("Please choose your room and fill in the information required:");
			Console.WriteLine("-----------------------------");

			Console.WriteLine("Which of the following room do you want? (choose a number between 1" + "-" + Convert.ToString(MainProgramma.RoomsList.Count) + ")"); // Tussen 1-5

			for (int i = 0; i < MainProgramma.RoomsList.Count; i++) { Console.WriteLine("- " + MainProgramma.RoomsList[i].roomName); }
			Console.WriteLine("\nRoom:");
			MainProgramma.roomKeuze = Convert.ToInt32(Console.ReadLine());
			while (MainProgramma.roomKeuze < 1 || MainProgramma.roomKeuze > MainProgramma.RoomsList.Count)
			{
				Console.WriteLine("*****ERROR*****\nPlease fill in a number between 1-" + Convert.ToString(MainProgramma.RoomsList.Count) + ")");
				MainProgramma.roomKeuze = Convert.ToInt32(Console.ReadLine());
			}

			Console.WriteLine("Fill in your first name(e.g. 'Piet'):"); // Alleen Letters
			MainProgramma.userName = Console.ReadLine();

			Console.WriteLine("Fill in your last name(e.g. 'de Koning'):"); //Alleen Letters
			MainProgramma.userLastName = Console.ReadLine();

			Console.WriteLine("Fill in your postcode(e.g. '2631 JK'):"); //4 Cijfers & 2 Letters
			MainProgramma.userPostcode = Console.ReadLine();

			Console.WriteLine("Fill in your street(e.g. 'Tulpenlaan'):"); // Alleen Letters
			MainProgramma.userStreet = Console.ReadLine();

			Console.WriteLine("Fill in your residence(e.g. 'Pijnacker'):"); // Alleen Letters
			MainProgramma.userWoonplaats = Console.ReadLine();

			Console.WriteLine("Fill in your housenumber(e.g. '98'):"); // Alleen cijfers max. 19999
			MainProgramma.userHouseNumber = Console.ReadLine();

			Console.WriteLine("Fill in your email(e.g. 'voorbeeld@mail.com'):"); // Moet een @ en . hebben
			MainProgramma.userEmail = Console.ReadLine();

			Console.WriteLine("Fill in your telephonenumber(e.g. ' (+31) 6 7631 9854'):"); // Alleen cijfers max. 10 getallen
			MainProgramma.userPhoneNumber = Console.ReadLine();

			Console.WriteLine("Fill in how many participants there will be(" + MainProgramma.RoomsList[Convert.ToInt32(MainProgramma.roomKeuze - 1)].roomMinSize + "-" + MainProgramma.RoomsList[Convert.ToInt32(MainProgramma.roomKeuze - 1)].roomMaxSize + ")"); // 2-6 deelnemers
			MainProgramma.userParticipants = Convert.ToInt32(Console.ReadLine());
			while (MainProgramma.userParticipants < MainProgramma.RoomsList[MainProgramma.roomKeuze-1].roomMinSize || MainProgramma.userParticipants > MainProgramma.RoomsList[MainProgramma.roomKeuze-1].roomMaxSize)
			{
				Console.WriteLine("*****ERROR*****\nPlease fill in a number between " + MainProgramma.RoomsList[Convert.ToInt32(MainProgramma.roomKeuze - 1)].roomMinSize + " - " + MainProgramma.RoomsList[Convert.ToInt32(MainProgramma.roomKeuze - 1)].roomMaxSize + ")");
				MainProgramma.userParticipants = Convert.ToInt32(Console.ReadLine());
			}


			Console.Clear();
			ReceiptFunction();
		}
		public static void ContactFunction()
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Contact and F.A.Q. page.\nPlease select one of the options below:\n\n1: Contact information\n2: F.A.Q.\n");
			string userInputCFAQ = Console.ReadLine();

			if (userInputCFAQ == "1")
			{
				Functions.Contact();
			}
			if (userInputCFAQ == "2")
			{
				MainProgramma.FAQ();
			}

		}

		public static void InfoFunction()
		{
			Console.Clear();
			Console.WriteLine("What is an escape room?\n\nIn an escape room the door wil be closed and locked and it is up to you to escape the room as quickly as possible.Usually you wil have around 60 minutes to escape.\nWhile you are inside you wil have to solve puzzle's that wil bring you close to the 'key' or code that wil help you open the door.\nIf you manage to open the door within the given time, you win.");
			Console.WriteLine("\nHouserules:\n1) It is forbidden to enter the escape rooms under the influence of drugs and/or alcohol.");
			Console.WriteLine("2) Inside the escape room you won't have to use force to open something.");
			Console.WriteLine("3) The only way to advance in the game is with a key or by correctly executing an assignment. Don't move the furniture or any what is hanging on the walls.");
			Console.WriteLine("4) Smoking is forbidden in the whole building");
			Console.WriteLine("5) It is not allowed to bring your own food and/or drinks.");
			Console.WriteLine("6) Phone's and other personal belongings are to be left in the locker in the entranceroom. You wil take the key to this locker with you inside the escape room.");
			Console.WriteLine("7) It is forbidden to take photo's inside the escape room");
			Console.WriteLine("8) If something happens, or someone wants to leave the room, then you are allowed to leave the room, the door is open.");
			Console.WriteLine("9) If you decide to leave the room, you wil no longer be allowed to enter the room.");
			Console.WriteLine("10) The game leader wil be watching the game via camera's. If you break any og the rules, he/she can decide to end the game.");
			Console.WriteLine("11) You play the game at your own risk. Damage or injury can not be recovered from the escape room");

			MainProgramma.ReturnMenuFunction();
		}

		public static void ShowFunction(List<EscapeRoom> RoomsList)
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
			MainProgramma.ReturnMenuFunction();
		}

		public static void WriteLine(object obj, ConsoleColor? color = null)
		{
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.WriteLine(obj);
			Console.ResetColor();
		}

		public static void error()
		{
			Functions.WriteLine("Oh no, your input did not fit!", ConsoleColor.Red);
		}

		public static void Write(object obj, ConsoleColor? color = null)
		{
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.Write(obj);
			Console.ResetColor();
		}

	}
}

