using ProjectB;
using ProjectB.Crud;
using System;
using System.Collections.Generic;
using Y_or_N;



class MainProgram
{
	public static List<EscapeRoom> RoomsList = new List<EscapeRoom>();
	public static List<string> IDList = new List<string>();
	public static List<string> CustomerList = new List<string>();


	public static int LoginTries = 4;
	public static int AdminSuccess = 0;
	public static int CustomerSuccess = 0;
	public static int EmployeeSuccess = 0;
	public static string AdminLogin = "";
	public static string UserNameLogin = "";
	public static string UserPassWordLogin = "";
	public static string EmployeeLogin = "";
	public static bool ContinueProgram = true;
	public static bool Mainpage = true;
	public static bool LoopCustomerLogin = true;
	public static bool LoopEmployeeLogin = true;
	public static bool LoopAdminLogin = true;
	public static bool customerFalse = false;
	public static bool employeeFalse = false;
	public static bool adminFalse = false;
	


	public static void Main()
	{
		//temporary room for testing
		RoomsList.Add(new EscapeRoom() { });
		RoomsList[0].roomNumber = 1;
		RoomsList[0].ageMinimum = 14;
		RoomsList[0].roomMinSize = 4;
		RoomsList[0].roomMaxSize = 6;
		RoomsList[0].roomDuration = new TimeSpan(1, 30, 0);
		RoomsList[0].roomName = "Horror Room";
		RoomsList[0].roomPrice = 7.50;
		RoomsList[0].roomTheme = "Horror";
		//temporary room for testing
			while (Mainpage)
			{
				LoopCustomerLogin = true;
				LoopEmployeeLogin = true;
				LoopAdminLogin = true;
				Console.Clear();
				util.Log("");
				Console.WriteLine("Welcome to our Escape Room application!\n=======================================\n1) Customer login\n2) Employee login\n3) Admin login\n4) Exit Application\n=======================================\n");
				Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] on the keyboard");	
				Functions.Write("\nYour input - ", ConsoleColor.Yellow);
				var input = Console.ReadKey();
				if (input.Key == ConsoleKey.D1) { CustomerLoginFunction(); customerFalse = false; }
				else if (input.Key == ConsoleKey.D2) { EmployeeLoginFunction(); employeeFalse = false; }
				else if (input.Key == ConsoleKey.D3) { AdminFunction(); adminFalse = false; }
				else if (input.Key == ConsoleKey.D4) { break; }
			}
	}

	static void AdminFunction()
	{
		while (LoopAdminLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Admin login page, please enter the right password:\n");
			if (LoginTries > 0)
			{
				Console.WriteLine("Password:");
				string AdminLogin = Console.ReadLine();
				if (AdminLogin == "admin")
				{
					AdminSuccess += 1;
					AdminPage();
					LoopAdminLogin = false;
				}
				else
				{
					LoginTries -= 1;
					Console.WriteLine("This is not the password! Try again, you have " + LoginTries + " attempts left.\nPress any key to continue...\n");
					Console.ReadKey(true);
				}
			}
			else
			{
				Console.WriteLine("You have no more login attempts anymore, press any key to return to the main menu.\n");
				Console.ReadKey(true);
				LoopAdminLogin = false;
			}
		}
	}

	static void CustomerLoginFunction()
	{
		while (LoopCustomerLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Customer login page, please enter your username and the right password:\n===================================================================================\n");
			Console.WriteLine("Username:");
			string UserNameLogin = Console.ReadLine();
			Console.WriteLine("Password:");
			string UserPassWordLogin = Console.ReadLine();
			if (UserNameLogin == "" && UserPassWordLogin == "")
			{
				bool Return = util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else if (UserNameLogin != "user" || UserPassWordLogin != "12345")
			{
				Console.WriteLine("\nWrong login credentials, press any key and try again.");
				Console.ReadKey(true);
			}

			else if (UserNameLogin == "user" && UserPassWordLogin == "12345")
			{
				CustomerSuccess += 1;
				CustomerMenu();
				LoopCustomerLogin = false;
			}
		}
	}

	static void EmployeeLoginFunction()
	{
		while (LoopEmployeeLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Employee login page, please enter the right password:\n=========================================================================\n");
			Console.WriteLine("Password:");
			string EmployeeLogin = Console.ReadLine();
			if (EmployeeLogin == "employee")
			{
				EmployeeSuccess += 1;
				EmployeeMenu();
				LoopEmployeeLogin = false;
			}
			else if (EmployeeLogin == "")
			{
				bool Return = util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else if (EmployeeLogin != "employee")
			{
				Console.WriteLine("Wrong login credentials, press any key and try again.");
				Console.ReadKey(true);
			}
		}
	}

	static void CustomerMenu()
	{
		while (CustomerSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Customer menu!\n=======================================\n1. Escape Rooms\n2. Info \n3. Contact and F.A.Q.\n4. Reserveren\n5. Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (customerFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerShowFunction(RoomsList); }
			else if (input.Key == ConsoleKey.D2) { Functions.InfoFunction(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D4) { Functions.ReserveerFunction();  }
			else if (input.Key == ConsoleKey.D5) { CustomerSuccess -= 1;}
			else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
		}
	}

	public static void EmployeeMenu()
	{
		while (EmployeeSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Employee menu!\n=======================================\n1. Escape Rooms\n2. Info \n3. Contact and F.A.Q.\n4. Reservations (IN PROGRESS)\n5. Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (employeeFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerShowFunction(RoomsList); }
			else if (input.Key == ConsoleKey.D2) { Functions.InfoFunction(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D4)
			{
				Console.Clear();
				Console.WriteLine("W.I.P, press any key to continue.\n");
				Console.ReadKey(true);
			}
			else if (input.Key == ConsoleKey.D5) { EmployeeSuccess -= 1;}
			else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
		}
	}

	public static void AdminPage()
	{
		while (AdminSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the admin page, please select what you would like to do today:\n=======================================\n1) Customer overview (IN PROGRESS)\n2) Add an escape room\n3) Edit an escape room\n4) Delete an escape room\n5) Show escape rooms\n6) Edit menu\n7) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("5", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("6", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("7", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (adminFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerOverview(); }
			else if (input.Key == ConsoleKey.D2) { Add.Function(RoomsList); }
			else if (input.Key == ConsoleKey.D3) { Edit.Function(RoomsList); }
			else if (input.Key == ConsoleKey.D4) { Delete.Function(RoomsList); }
			else if (input.Key == ConsoleKey.D5) { Functions.ShowFunction(RoomsList); }
			else if (input.Key == ConsoleKey.D6) { FoodPrice.Editmenu(); }
			else if (input.Key == ConsoleKey.D7) { LoginTries = 4; AdminSuccess -= 1;}
			else { adminFalse = true;}
		}
	}

}