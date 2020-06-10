using ProjectB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Y_or_N;
using System.IO;
using System.Text;
using System.Linq;



class MainProgram
{
	public static List<string> IDList = new List<string>();

	private static readonly string PathEscapeRoom = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"EscapeRoomDatabase.json");
	private static JSONEscapeRoomList escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));

	private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
	private static JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

	private static readonly string PathReservation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"ReservationDatabase.json");
	private static JSONReservationList reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));
	
	public static int ID;
	public static int LoginTries = 4;
	public static int AdminSuccess = 0;
	public static int CustomerSuccess = 0;
	public static int EmployeeSuccess = 0;
	public static string error_message, input_message;
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
		while (Mainpage)
		{
			escapeRoomsList = JsonConvert.DeserializeObject<JSONEscapeRoomList>(File.ReadAllText(PathEscapeRoom));
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			reservationsList = JsonConvert.DeserializeObject<JSONReservationList>(File.ReadAllText(PathReservation));
			LoopCustomerLogin = true;
			LoopEmployeeLogin = true;
			LoopAdminLogin = true;
			Console.Clear();
			Util.Log("");
			Console.WriteLine("Welcome to our Escape Room application!\n=======================================\n1) Customer login\n2) Employee login\n3) Admin login\n4) Register\n5) Exit Application\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.Write("] on the keyboard");	
			Functions.Write("\nYour input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { CustomerLoginFunction(); customerFalse = false; }
			else if (input.Key == ConsoleKey.D2) { EmployeeLoginFunction(); employeeFalse = false; }
			else if (input.Key == ConsoleKey.D3) { AdminLoginFunction(); adminFalse = false; }
			else if (input.Key == ConsoleKey.D4) { Add.AddUser(); }
			else if (input.Key == ConsoleKey.D5) { break; }
		}
	}
	public static void AdminLoginFunction()
	{
		while (LoopAdminLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the admin login page, please enter your login credentials:\n=======================================================================");
			if (LoginTries > 0)
			{
				input_message = "ID:";
				error_message = "Please enter a valid ID";
				ID = Functions.Error_Exception_Int(input_message, error_message, 1, 99999);
				Console.WriteLine("Username:");
				string AdminNameLogin = Console.ReadLine();
				Console.WriteLine("Password:");
				string AdminPassWordLogin = Console.ReadLine();

				if (ID == usersList.Users[ID-1].UserID && AdminNameLogin == usersList.Users[ID - 1].UserName && AdminPassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole == "admin")
				{
					AdminSuccess += 1;
					AdminMenu();
					LoopAdminLogin = false;
				}
				else if (ID == usersList.Users[ID - 1].UserID && AdminNameLogin == usersList.Users[ID - 1].UserName && AdminPassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole != "admin")
				{
					LoginTries -= 1;
					Console.WriteLine("You are not an admin, nice try.... You have " + LoginTries + " attempts left.\n=======================================================================\n");
					Functions.ATC();
				}
				else
				{
					LoginTries -= 1;
					Console.WriteLine("These are not the correct login credentials! Try again, you have " + LoginTries + " attempts left.\n=======================================================================\n");
					Functions.ATC();
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
	public static void CustomerLoginFunction()
	{
		while (LoopCustomerLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the customer login page, please enter your login credentials:\n===================================================================================");
			input_message = "ID:";
			error_message = "Please enter a valid ID";
			ID = Functions.Error_Exception_Int(input_message, error_message, 1, 99999);
			Console.WriteLine("Username:");
			string UserNameLogin = Console.ReadLine();
			Console.WriteLine("Password:");
			string UserPassWordLogin = Console.ReadLine();
			if (ID == usersList.Users[ID - 1].UserID && UserNameLogin == usersList.Users[ID - 1].UserName && UserPassWordLogin == usersList.Users[ID - 1].UserPassword)
			{
				CustomerSuccess += 1;
				CustomerMenu();
				LoopCustomerLogin = false;
			}
			else if (UserNameLogin == "" && UserPassWordLogin == "")
			{
				bool Return = Util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else
			{
				Console.WriteLine("Wrong login credentials, please try again.");
				Functions.ATC();
			}
		}
	}
	public static void EmployeeLoginFunction()
	{
		while (LoopEmployeeLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the employee login page, please enter your login credentials:\n=========================================================================");
			input_message = "ID:";
			error_message = "Please enter a valid ID";
			ID = Functions.Error_Exception_Int(input_message, error_message, 1, 99999);
			Console.WriteLine("Username:");
			string EmployeeNameLogin = Console.ReadLine();
			Console.WriteLine("Password:");
			string EmployeePassWordLogin = Console.ReadLine();

			if (ID == usersList.Users[ID - 1].UserID && EmployeeNameLogin == usersList.Users[ID - 1].UserName && EmployeePassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole == "employee")
			{
				EmployeeSuccess += 1;
				EmployeeMenu();
				LoopEmployeeLogin = false;
			}
			else if (ID == usersList.Users[ID - 1].UserID && EmployeeNameLogin == usersList.Users[ID - 1].UserName && EmployeePassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole == "admin")
			{
				EmployeeSuccess += 1;
				EmployeeMenu();
				LoopEmployeeLogin = false;
			}
			else if (ID == usersList.Users[ID - 1].UserID && EmployeeNameLogin == usersList.Users[ID - 1].UserName && EmployeePassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole != "employee" || usersList.Users[ID - 1].UserRole != "admin")
			{
				Console.WriteLine("You are not an employee, nice try.... Try again.\n===================================================================================\n");
				Functions.ATC();
			}
			else if (EmployeeNameLogin == "" && EmployeePassWordLogin == "")
			{
				bool Return = Util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else
			{
				Console.WriteLine("These are not the correct login credentials! Try again.\n===================================================================================");
				Functions.ATC();
			}
		}
	}
	public static void CustomerMenu()
	{
		while (CustomerSuccess == 1)
		{
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			Console.Clear();
			Console.WriteLine("Welcome to the customer menu!\n=======================================");
			Functions.Write(usersList.Users[ID - 1].UserFirstName + " " + usersList.Users[ID - 1].UserLastName, ConsoleColor.Green);
			Console.WriteLine("\n=======================================\n1) Escape room overview\n2) Info \n3) Contact and F.A.Q.\n4) Reserveren\n5) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (customerFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerShowFunction(); }
			else if (input.Key == ConsoleKey.D2) { Functions.InfoFunction(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D4) { Add.AddReservation(); }
			else if (input.Key == ConsoleKey.D5) { CustomerSuccess -= 1; }
			else { Console.Write("\n"); Functions.Error(); Functions.ATC(); }
		}
	}
	public static void EmployeeMenu()
	{
		while (EmployeeSuccess == 1)
		{
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			Console.Clear();
			Console.WriteLine("Welcome to the employee menu!\n=======================================");
			Functions.Write(usersList.Users[ID - 1].UserFirstName + " " + usersList.Users[ID - 1].UserLastName, ConsoleColor.Green);
			Console.WriteLine("\n=======================================\n1) User overview\n2) Reservation overview\n3) Escape room overview\n4) Contact and F.A.Q.\n5) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (employeeFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerOverview(); }
			else if (input.Key == ConsoleKey.D2) { Functions.ReservationOverview(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ShowFunction(); }
			else if (input.Key == ConsoleKey.D4){ Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D5) { EmployeeSuccess -= 1;}
			else { Console.Write("\n"); Functions.Error(); Functions.ATC(); }
		}
	}
	public static void AdminMenu()
	{
		while (AdminSuccess == 1)
		{
			usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
			Console.Clear();
			Console.WriteLine("Welcome to the admin menu!\n=======================================");
			Functions.Write(usersList.Users[ID - 1].UserFirstName + " " + usersList.Users[ID - 1].UserLastName, ConsoleColor.Green);
			Console.WriteLine("\n=======================================\n1) User overview\n2) Reservation overview\n3) Escape room overview\n4) Info\n5) Contact and F.A.Q.\n6) Add menu\n7) Edit menu\n8) Delete menu \n9) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("5", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("6", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("7", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("8", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("9", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (adminFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerOverview(); }
			else if (input.Key == ConsoleKey.D2) { Functions.ReservationOverview(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ShowFunction(); }
			else if (input.Key == ConsoleKey.D4) { Functions.InfoFunction(); }
			else if (input.Key == ConsoleKey.D5) { Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D6) { Add.Function(); }
			else if (input.Key == ConsoleKey.D7) { Edit.Function(); }
			else if (input.Key == ConsoleKey.D8) { Delete.Function();}
			else if (input.Key == ConsoleKey.D9) { LoginTries = 4; AdminSuccess -= 1;}
			else { adminFalse = true;}
		}
	}
}