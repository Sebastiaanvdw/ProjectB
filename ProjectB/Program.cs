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

	private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UserDatabase.json");
	private static readonly JSONUserList usersList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

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
			else if (input.Key == ConsoleKey.D3) { AdminLoginFunction(); adminFalse = false; }
			else if (input.Key == ConsoleKey.D4) { break; }
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
				ID = Error_Exception_Int(input_message, error_message, 1, 99999);
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
				else if (ID == usersList.Users[ID].UserID && AdminNameLogin == usersList.Users[ID].UserName && AdminPassWordLogin == usersList.Users[ID].UserPassword && usersList.Users[ID].UserRole != "admin")
				{
					LoginTries -= 1;
					Console.WriteLine("You are not an admin, nice try.... You have " + LoginTries + " attempts left.\n=======================================================================\nPress any key to continue...\n");
					Console.ReadKey(true);
				}
				else
				{
					LoginTries -= 1;
					Console.WriteLine("These are not the correct login credentials! Try again, you have " + LoginTries + " attempts left.\n=======================================================================\nPress any key to continue...\n");
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
	public static void CustomerLoginFunction()
	{
		while (LoopCustomerLogin)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the customer login page, please enter your login credentials:\n===================================================================================");
			input_message = "ID:";
			error_message = "Please enter a valid ID";
			ID = Error_Exception_Int(input_message, error_message, 1, 99999);
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
				bool Return = util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else
			{
				Console.WriteLine("Wrong login credentials, press any key and try again.");
				Console.ReadKey(true);
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
			ID = Error_Exception_Int(input_message, error_message, 1, 99999);
			Console.WriteLine("Username:");
			string EmployeeNameLogin = Console.ReadLine();
			Console.WriteLine("Password:");
			string EmployeePassWordLogin = Console.ReadLine();

			if (ID == usersList.Users[ID - 1].UserID && EmployeeNameLogin == usersList.Users[ID - 1].UserName && EmployeePassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole == "employee" || usersList.Users[ID - 1].UserRole == "admin")
			{
				EmployeeSuccess += 1;
				EmployeeMenu();
				LoopEmployeeLogin = false;
			}
			else if (ID == usersList.Users[ID - 1].UserID && EmployeeNameLogin == usersList.Users[ID - 1].UserName && EmployeePassWordLogin == usersList.Users[ID - 1].UserPassword && usersList.Users[ID - 1].UserRole != "employee" || usersList.Users[ID - 1].UserRole != "admin")
			{
				Console.WriteLine("You are not an employee, nice try.... Try again.\n===================================================================================\nPress any key to continue...\n");
				Console.ReadKey(true);
			}
			else if (EmployeeNameLogin == "" && EmployeePassWordLogin == "")
			{
				bool Return = util.ReturnToMenu();
				if (Return == true) { return; }
				if (Return == false) { }
			}
			else
			{
				Console.WriteLine("These are not the correct login credentials! Try again.\n===================================================================================\nPress any key to continue...\n");
				Console.ReadKey(true);
			}
		}
	}
	public static void CustomerMenu()
	{
		while (CustomerSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the customer menu!\n=======================================\n1) Escape room overview\n2) Info \n3) Contact and F.A.Q.\n4) Reserveren\n5) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (customerFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerShowFunction(); }
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
			Console.WriteLine("Welcome to the employee menu!\n=======================================\n1) User overview\n2) Reservation overview\n3) Escape room overview\n4) Contact and F.A.Q.\n5) Logout\n=======================================\n");
			Console.Write("Please press ["); Functions.Write("1", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("2", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("3", ConsoleColor.Yellow); Console.Write("], ["); Functions.Write("4", ConsoleColor.Yellow); Console.Write("] or ["); Functions.Write("5", ConsoleColor.Yellow); Console.WriteLine("] on the keyboard");
			if (employeeFalse == true) { Functions.Error(); }
			Functions.Write("Your input - ", ConsoleColor.Yellow);
			var input = Console.ReadKey();
			if (input.Key == ConsoleKey.D1) { Functions.CustomerOverview(); }
			else if (input.Key == ConsoleKey.D2) { Functions.ReservationOverview(); }
			else if (input.Key == ConsoleKey.D3) { Functions.ShowFunction(); }
			else if (input.Key == ConsoleKey.D4){ Functions.ContactFunction(); }
			else if (input.Key == ConsoleKey.D5) { EmployeeSuccess -= 1;}
			else { Console.Write("\n"); Functions.Error(); Console.Write("\nPress any key to continue...\n"); Console.ReadLine(); }
		}
	}
	public static void AdminMenu()
	{
		while (AdminSuccess == 1)
		{
			Console.Clear();
			Console.WriteLine("Welcome to the admin menu!\n=======================================\n1) User overview\n2) Reservation overview\n3) Escape room overview\n4) Info\n5) Contact and F.A.Q.\n6) Add an escape room\n7) Edit menu\n8) Delete menu \n9) Logout\n=======================================\n");
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
	public static void WriteLine(object obj, ConsoleColor? color = null)
	{
		if (color != null)
			Console.ForegroundColor = color.Value;
		Console.WriteLine(obj);
		Console.ResetColor();
	}
	public static void Error()
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
	public static string Error_Exception_String(string message, string errormessage, bool isanumber, bool lengthmatters, int minlength, int maxlength, bool specialcontain, string contains1, string contains2)
	{
		string userInput = "";
		bool Succes = false;
		while (!Succes)
		{
			Console.WriteLine(message);
			userInput = Console.ReadLine();
			if (string.IsNullOrEmpty(userInput)) { Succes = false; }
			else if (!isanumber && userInput.Any(char.IsDigit)) { Succes = false; }
			else if (isanumber && !userInput.Any(char.IsDigit)) { Succes = false; }
			else if (lengthmatters && (userInput.Length < minlength || userInput.Length > maxlength)) { Succes = false; }
			else if (specialcontain && !userInput.Contains(contains1) || !userInput.Contains(contains2)) { Succes = false; }
			else if (userInput.Length < 5 && userInput.Contains(" ")) { Succes = false; }
			else { Succes = true; }
			if (Succes) { }
			else
			{
				Write("Oh no, your input did not fit!", ConsoleColor.Red);
				Console.WriteLine(errormessage);
			}
		}
		return userInput;
	}
	public static int Error_Exception_Int(string message, string errormessage, int minlength, int maxlength)
	{
		string userInput = "";
		bool Succes = false;
		while (!Succes)
		{
			Console.WriteLine(message);
			userInput = Console.ReadLine();
			Succes = int.TryParse(userInput, out int number);
			if (number >= minlength && number <= maxlength) { Succes = true; }
			else { Succes = false; }
			if (Succes) { }
			else
			{
				Write("Oh no, your input did not fit!", ConsoleColor.Red);
				Console.WriteLine(errormessage);
			}
		}
		return Int32.Parse(userInput);
	}
}