using ProjectB;
using ProjectB.Crud;
using System;
using System.Collections.Generic;
using Y_or_N;



class MainProgramma
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


	public static void Main()
	{
		while (ContinueProgram)
		{
			while (Mainpage)
			{
				LoopCustomerLogin = true;
				LoopEmployeeLogin = true;
				LoopAdminLogin = true;
				Console.Clear();
				Console.WriteLine("Welcome to our Escape Room application!\n=======================================\n1) Customer login\n2) Employee login\n3) Admin login\n=======================================\n");
				Console.Write("Please press [1], [2] or [3] on the keyboard\n");
				Console.Write("Your input - ");
				var input = Console.ReadKey();

				switch (input.Key) //Switch on Key enum
				{
					case ConsoleKey.D1:
						CustomerLoginFunction();
						Mainpage = false;
						break;
					case ConsoleKey.D2:
						EmployeeLoginFunction();
						Mainpage = false;
						break;
					case ConsoleKey.D3:
						AdminFunction();
						Mainpage = false;
						break;
					default:
						Console.WriteLine("Unknown Command");
						break;
				}
			}
			Console.Clear();
			Console.Write("Would you like to continue the program? Press");
			Functions.Write("y", ConsoleColor.Yellow);
			Console.Write(" or ");
			Functions.Write("n", ConsoleColor.Yellow);
			bool Return = util.CheckYN();
			if (Return == true) { Mainpage = true; }
			if (Return == false)
			{
				ContinueProgram = false;
			}
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
		while(LoopCustomerLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Customer login page, please enter your username and the right password:\n===================================================================================\n");
			Console.WriteLine("Username:");
			string UserNameLogin = Console.ReadLine();
			Console.WriteLine("Password:");
			string UserPassWordLogin = Console.ReadLine();
			if (UserNameLogin == "" && UserPassWordLogin == "")
			{
				Console.Write("Return to the main menu? press ");
				Functions.Write("y", ConsoleColor.Yellow);
				Console.Write(" or ");
				Functions.Write("n", ConsoleColor.Yellow);
				bool Return = util.CheckYN();
				if (Return == true) { return; }
				if (Return == false) {}
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
				Console.Write("Return to the main menu? press ");
				Functions.Write("y", ConsoleColor.Yellow);
				Console.Write(" or ");
				Functions.Write("n", ConsoleColor.Yellow);
				bool Return = util.CheckYN();
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
			switch (Console.ReadLine())
			{
				case "1":
					Functions.CustomerShowFunction(RoomsList);
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
					break;
				default:
					Console.WriteLine("\n*****ERROR*****\nPlease enter a valid option");
					break;
			}
		}
	}

	public static void EmployeeMenu()
	{
		while (EmployeeSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the Employee menu!\n=======================================\n1. Escape Rooms\n2. Info \n3. Contact and F.A.Q.\n4. Reservations (IN PROGRESS)\n5. Logout\n=======================================\n");
			int InterFaceInput = Convert.ToInt32(Console.ReadLine());

			if (InterFaceInput == 1) { Functions.ShowFunction(RoomsList); }
			if (InterFaceInput == 2) { Functions.InfoFunction(); }
			if (InterFaceInput == 3) { Functions.ContactFunction(); }
			if (InterFaceInput == 4)
			{
				Console.Clear();
				Console.WriteLine("W.I.P, press any key to continue.\n");
				Console.ReadKey(true);
				EmployeeMenu();
			}
			if (InterFaceInput == 5)
			{
				EmployeeSuccess -= 1;
			}
		}
	}

	public static void AdminPage()
	{
		while (AdminSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the admin page, please select what you would like to do today:\n=======================================\n1. Customer overview (IN PROGRESS)\n2. Add an escape room\n3. Edit an escape room\n4. Delete an escape room\n5. Show escape rooms\n6. Logout\n=======================================\n");
			string InterFaceInput = Console.ReadLine();
			if (!int.TryParse(InterFaceInput, out int number)) { Functions.Error(); }

			if (number == 1) { Functions.CustomerOverview(); }
			if (number == 2) { Add.Function(RoomsList); }
			if (number == 3) { Edit.Function(RoomsList); }
			if (number == 4) { Delete.Function(RoomsList); }
			if (number == 5) { Functions.ShowFunction(RoomsList); }
			if (number == 6)
			{
				LoginTries = 4;
				AdminSuccess -= 1;
			}
		}
	}
}