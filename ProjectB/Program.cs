using System;
using System.Collections.Generic;
using System.Text;
using ProjectB;
using ProjectB.Crud;
using Y_or_N;

class MainProgramma
{
	public static List<EscapeRoom> RoomsList = new List<EscapeRoom>();
	public static List<string> IDList = new List<string>();
	public static List<string> CustomerList = new List<string>();
	
	public static int roomKeuze, userParticipants;
	public static int LoginTries = 4;
	public static int AdminSuccess = 0;
	public static int CustomerSuccess = 0;
	public static int EmployeeSuccess = 0;
	public static string AdminLogin = "";
	public static string UserNameLogin = "";
	public static string UserPassWordLogin = "";
	public static string EmployeeLogin = "";
	public static string userName, userLastName, userPostcode, userStreet, userWoonplaats, userHouseNumber, userEmail, userPhoneNumber, userArrangement;
	public static string userUniqueID;
	public static double userTotalPrice = 0;

	public static void Main()
	{
		Console.Clear();
		Console.WriteLine("Welcome to our Escape Room application!\n=======================================\n1) Customer login\n2) Employee login\n3) Admin login\n=======================================\n");
		Console.WriteLine("Please press [1], [2] or [3] on the keyboard");
		Console.Write("Your input - ");
		var input = Console.ReadKey();

		switch (input.Key) //Switch on Key enum
		{
			case ConsoleKey.D1:
				CustomerLoginFunction();
				break;
			case ConsoleKey.D2:
				EmployeeLoginFunction();
				break;
			case ConsoleKey.D3:
				AdminFunction();
				break;
			default:
				Console.WriteLine("Unknown Command");
				break;
		}
	}

	public static void FAQ()
	{
		string FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n\n";
		string FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n\n";
		string FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n\n";

		Console.Clear();
		Console.WriteLine(FAQ1 + FAQ2 + FAQ3 + "\n");
		ReturnMenuFunction();
		
	}

	static void AdminFunction()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Admin login page, please enter the right password:\n");
		Console.WriteLine("Password:");
		if (LoginTries > 0)
		{
			string AdminLogin = Console.ReadLine();
			if (AdminLogin == "admin")
			{
				AdminSuccess += 1;
				AdminPage();
			}
			else
			{
				LoginTries -= 1;
				Console.WriteLine("This is not the password! Try again, you have " + LoginTries + " attempts left.\nPress any key to continue...\n");
				Console.ReadKey(true);
				AdminFunction();
			}
		}
		else
		{
			Console.WriteLine("You have no more login attempts anymore, press any key to return to the main menu.\n");
			Console.ReadKey(true);
			Main();
		}
	}

	static void CustomerLoginFunction()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Customer login page, please enter your username and the right password:\n===================================================================================\n");
		Console.WriteLine("Username:");
		string UserNameLogin = Console.ReadLine();
		Console.WriteLine("Password");
		string UserPassWordLogin = Console.ReadLine();
		if (UserNameLogin == "" && UserPassWordLogin == "")
		{
			Console.Write("Return to the main menu? press ");
			Functions.Write("y", ConsoleColor.Yellow);
			Console.Write(" or ");
			Functions.Write("n", ConsoleColor.Yellow);
			bool Return = util.CheckYN();
			if (Return == true)
			{
				Main();
			}
			if (Return != false)
			{
				Console.Clear();
				Console.WriteLine("Error, you didn't press y or n.\nAs a failsafe you will be returned to the main menu.\nPress any key to return to the main menu.");
				Console.ReadKey(true);
				Main();
			}
		}
		if (UserNameLogin != "user" || UserPassWordLogin != "12345")
		{
			Console.WriteLine("\nWrong login credentials, press any key and try again.");
			Console.ReadKey(true);
			CustomerLoginFunction();
		}
	
		if (UserNameLogin == "user" && UserPassWordLogin == "12345")
		{
			CustomerSuccess += 1;
			CustomerMenu();
		}
	}

	static void EmployeeLoginFunction()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Employee login page, please enter the right password:\n=========================================================================\n");
		string EmployeeLogin = Console.ReadLine();
		if (EmployeeLogin == "employee")
		{
			EmployeeSuccess += 1;
			EmployeeMenu();
		}
		if (EmployeeLogin == "")
		{
			Console.WriteLine("Return to the main menu? y or n");
			string Return = Console.ReadLine();
			if (Return == "y")
			{
				Main();
			}
			if (Return != "n")
			{
				Console.Clear();
				Console.WriteLine("Error, you didn't press y or n.\nAs a failsafe you will be returned to the main menu.\nPress any key to return to the main menu.");
				Console.ReadKey(true);
				Main();
			}
		}
		else
		{
			Console.WriteLine("Wrong login credentials, press any key and try again.");
			Console.ReadKey(true);
			EmployeeLoginFunction();
		}
	}

	static void CustomerMenu() {
		Console.Clear();
		Console.WriteLine("Welcome to the Customer menu!\n=======================================\n1. Escape Rooms\n2. Info \n3. Contact and F.A.Q.\n4. Reserveren\n5. Logout\n=======================================\n");
		switch (Console.ReadLine())
		{
			case "1":
				Functions.ShowFunction(RoomsList);
				break;
			case "2":
				Functions.InfoFunction();
				break;
			case "3":
				Functions.ContactFunction();
				break;
			case "4":
				Functions.ReserveerFunction();
				break;
			case "5":
				CustomerSuccess -= 1;
				Main();
				break;
			default:
				Console.WriteLine("\n*****ERROR*****\nPlease enter a valid option");
				break;
				
		}
	

	}

	static void EmployeeMenu()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Employee menu!\n=======================================\n1. Escape Rooms\n2. Info \n3. Contact and F.A.Q.\n4. Reservations (IN PROGRESS)\n5. Logout\n=======================================\n");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());

		if (InterFaceInput == 1) { Functions.ShowFunction(RoomsList); }
		if (InterFaceInput == 2) { Functions.InfoFunction(); }
		if (InterFaceInput == 3) { Functions.ContactFunction(); }
		if (InterFaceInput == 4) { 
			Console.Clear();
			Console.WriteLine("W.I.P, press any key to continue.\n");
			Console.ReadKey(true);
			EmployeeMenu();
		}
		if (InterFaceInput == 5)
		{
			EmployeeSuccess -= 1;
			Main();
		}
	}

	static void AdminPage()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the admin page, please select what you would like to do today:\n=======================================\n1. Customer overview (IN PROGRESS)\n2. Add an escape room\n3. Edit an escape room\n4. Delete an escape room\n5. Show escape rooms\n6. Logout\n=======================================\n");
		string InterFaceInput = Console.ReadLine();
		if (!int.TryParse(InterFaceInput, out int number)) { Functions.error(); }

		if (number == 1) { CustomerOverview(); }
		if (number == 2) { Add.Function(RoomsList); }
		if (number == 3) { Edit.Function(RoomsList); }
		if (number == 4) { Delete.Function(RoomsList); }
		if (number == 5) { Functions.ShowFunction(RoomsList); }
		if (number == 6)
		{
			LoginTries = 4;
			AdminSuccess -= 1;
			Main();
		}
	}

	static void CustomerOverview()
	{
		Console.Clear();
		Console.WriteLine(userName + "," + userLastName + "," + userPostcode + "," + userStreet + "," + userWoonplaats + "," + userEmail + "\n");

		ReturnMenuFunction();
	}

	public static void ReturnMenuFunction()
	{
		bool ReturnToMenu = util.CheckML();
		

		if (ReturnToMenu == true)
		{
			if (AdminSuccess == 1) { Console.Clear(); AdminPage(); }
			if (EmployeeSuccess == 1) { Console.Clear(); EmployeeMenu(); }
			if (CustomerSuccess == 1) { Console.Clear(); CustomerMenu(); }
		}

		else if (ReturnToMenu == false)
		{
			Console.Clear();
			AdminSuccess = 0;
			EmployeeSuccess = 0;
			CustomerSuccess = 0;
			Main();
		}
	}


}




