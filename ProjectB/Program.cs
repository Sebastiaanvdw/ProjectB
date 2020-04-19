using System;
using System.Collections.Generic;
using System.Text;
using ProjectB.Crud;



class MainProgramma
{
	public static List<EscapeRoom> RoomsList = new List<EscapeRoom>();
	public static List<int> IDList = new List<int>();
	public static List<string> CustomerList = new List<string>();
	
	public static int userUniqueID, roomKeuze, userParticipants;
	public static int LoginTries = 4;
	public static int AdminSuccess = 0;
	public static int CustomerSuccess = 0;
	public static int EmployeeSuccess = 0;
	public static string AdminLogin = "";
	public static string UserNameLogin = "";
	public static string UserPassWordLogin = "";
	public static string EmployeeLogin = "";
	public static string userName, userLastName, userPostcode, userStreet, userWoonplaats, userHouseNumber, userEmail, userPhoneNumber;
	

	public static void Main()
	{
		Console.Clear();
		Console.WriteLine("Welcome to our Escape Room application!\n=======================================\n1: Customer login\n2: Employee login\n3: Admin login\n=======================================\n");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());

		if (InterFaceInput == 1) { CustomerLoginFunction(); }
		if (InterFaceInput == 2) { EmployeeLoginFunction(); }
		if (InterFaceInput == 3) { AdminFunction(); }
	}

	static void AddFunction(List<EscapeRoom> RoomsList)
	{
		if (RoomsList.Count >= 0 & RoomsList.Count < 5)
		{
			Console.Clear();
			RoomsList.Add(new EscapeRoom() { });
			int NewIndex = RoomsList.Count - 1;
			if (RoomsList.Count == 1) { NewIndex = 0; }
			RoomsList[NewIndex].roomNumber = NewIndex + 1;

			Console.WriteLine("Enter the minimum age for the escape room:");
			RoomsList[NewIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());
			while (RoomsList[NewIndex].ageMinimum < 12 || RoomsList[NewIndex].ageMinimum > 100)
			{
				Console.WriteLine("*****ERROR*****\nPlease enter a valid number between 12-100\n");
				Console.WriteLine("Enter the minimum age for the escape room:");
				RoomsList[NewIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());

			}

			while (RoomsList[NewIndex].roomMinSize < 2 || RoomsList[NewIndex].roomMinSize > 5)
			{
				Console.WriteLine("Enter the minimum amount of players for the escape room:");
				RoomsList[NewIndex].roomMinSize = Convert.ToInt32(Console.ReadLine());
				if (RoomsList[NewIndex].roomMinSize < 2 || RoomsList[NewIndex].roomMinSize > 5) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween 2-5\n"); }
			}

			while (RoomsList[NewIndex].roomMaxSize < RoomsList[NewIndex].roomMinSize || RoomsList[NewIndex].roomMaxSize > 6)
			{
				Console.WriteLine("Enter the maximum amount of players for the escape room:");
				RoomsList[NewIndex].roomMaxSize = Convert.ToInt32(Console.ReadLine());
				if (RoomsList[NewIndex].roomMaxSize < RoomsList[NewIndex].roomMinSize || RoomsList[NewIndex].roomMaxSize > 6) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween " + RoomsList[NewIndex].roomMinSize + "-6\n"); }
			}

			Console.WriteLine("Enter the price for the escape room:");
			RoomsList[NewIndex].roomPrice = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("Enter the theme for the escape room:");
			RoomsList[NewIndex].roomTheme = Console.ReadLine();

			Console.WriteLine("Enter the duration for the escape room:");
			RoomsList[NewIndex].roomDuration = Console.ReadLine();

			Console.WriteLine("Enter the name for the escape room:");
			RoomsList[NewIndex].roomName = Console.ReadLine();

			Console.WriteLine("Room Complete!");

		}

		else
		{
			Console.WriteLine("There are already 5 EscapeRooms existing!");
		}
		ReturnMenuFunction();
	}

	static void EditFunction(List<EscapeRoom> RoomsList)
	{
		Console.Clear();
		ShowFunction(RoomsList);
		Console.WriteLine("Choose the room that you want to edit(use the roomnumber 1-5)");
		int EditRoomIndex = Convert.ToInt32(Console.ReadLine()) - 1;
		for (int i = 0; i < RoomsList.Count; i++)
		{
			if (i == EditRoomIndex)
			{
				bool Continue_RoomEdit = true;
				while (Continue_RoomEdit)
				{
					Console.Clear();
					Console.WriteLine(RoomsList[EditRoomIndex] + "\n");
					Console.WriteLine("Choose what you would like to change about the room: ");
					Console.WriteLine("1) Change name\n2) Change minimum age\n3) Change amount of players\n4) Change price\n5) Change duration\n6) Change theme\n7) Back to menu");
					int EditRoomChoice = Convert.ToInt32(Console.ReadLine());
					if (EditRoomChoice == 1)
					{
						Console.WriteLine("Enter the name for the escape room:");
						RoomsList[EditRoomIndex].roomName = Console.ReadLine();
					}
					else if (EditRoomChoice == 2)
					{

						Console.WriteLine("Enter the minimum age for the escape room:");
						RoomsList[EditRoomIndex].ageMinimum = Convert.ToInt32(Console.ReadLine());
						if (RoomsList[EditRoomIndex].ageMinimum < 0 || RoomsList[EditRoomIndex].ageMinimum > 120) { Console.WriteLine("Please enter a valid age"); }


					}
					else if (EditRoomChoice == 3)
					{
						while (RoomsList[EditRoomIndex].roomMinSize < 2 || RoomsList[EditRoomIndex].roomMinSize > 5)
						{
							Console.WriteLine("Enter the minimum amount of players for the escape room:");
							RoomsList[EditRoomIndex].roomMinSize = Convert.ToInt32(Console.ReadLine());
							if (RoomsList[EditRoomIndex].roomMinSize < 2 || RoomsList[EditRoomIndex].roomMinSize > 5) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween 2-5\n"); }
						}

						while (RoomsList[EditRoomIndex].roomMaxSize < RoomsList[EditRoomIndex].roomMinSize || RoomsList[EditRoomIndex].roomMaxSize > 6)
						{
							Console.WriteLine("Enter the maximum amount of players for the escape room:");
							RoomsList[EditRoomIndex].roomMaxSize = Convert.ToInt32(Console.ReadLine());
							if (RoomsList[EditRoomIndex].roomMaxSize < RoomsList[EditRoomIndex].roomMinSize || RoomsList[EditRoomIndex].roomMaxSize > 6) { Console.WriteLine("*****ERROR*****\nPlease enter a valid number inbetween " + RoomsList[EditRoomIndex].roomMinSize + " - 6\n"); }
						}
					}
					else if (EditRoomChoice == 4)
					{
						Console.WriteLine("Enter the price for the escape room:");
						RoomsList[EditRoomIndex].roomPrice = Convert.ToDouble(Console.ReadLine());
					}
					else if (EditRoomChoice == 5)
					{
						Console.WriteLine("Enter the duration for the escape room:");
						RoomsList[EditRoomIndex].roomDuration = Console.ReadLine();
					}
					else if (EditRoomChoice == 6)
					{
						Console.WriteLine("Enter the theme for the escape room:");
						RoomsList[EditRoomIndex].roomTheme = Console.ReadLine();
					}
					else if (EditRoomChoice == 7)
					{
						Continue_RoomEdit = false;
					}
					ReturnMenuFunction();
				}
			}
		}
	}

	static void DeleteFunction(List<EscapeRoom> RoomsList)
	{
		Console.Clear();
		ShowFunction(RoomsList);
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
					RoomsList.RemoveAt(DeleteIndex);
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
		ReturnMenuFunction();
	}

	static void ShowFunction(List<EscapeRoom> RoomsList)
	{
		Console.Clear();
		Console.WriteLine("Room info:\n");
		for (int i = 0; i < RoomsList.Count; i++)
		{
			Console.WriteLine(RoomsList[i] + "\n");
		}
		ReturnMenuFunction();
	}


	static void InfoFunction()
	{
		Console.Clear();
		Console.WriteLine("Wat is een escape room?\n\nIn een escaperoom gaat de deur tijdelijk op slot en jij moet (samen met anderen) zo snel mogelijk uit de kamer(s) ontsnappen.");
		Console.WriteLine("Meestal is dit binnen 60 minuten. Uiteraard kun je eenmaal binnen gebruik maken van cryptische aanwijzingen, die je stapje voor stapje richting de uiteindelijke");
		Console.WriteLine("‘sleutel’ of code helpen om de ‘deur’ te kunnen openen.Slaag je daar binnen de gestelde tijd in? Gefeliciteerd!");
		Console.WriteLine("\nHuisregels:\n1) Het is verboden om de escape rooms te betreden onder invloed van alcohol en/of drugs.\n2) In onze escape room hoef je niets met kracht of forceren te openen.");
		Console.WriteLine("3) Je komt alleen verder in het spel met een passende sleutel of met een goed uitgevoerde opdracht. Meubels niet verplaatsen en wat aan de muren hangt laten hangen.");
		Console.WriteLine("4) Roken is verboden in het hele gebouw.\n5) Het is niet toegestaan om zelf eten en/of drinken mee naar binnen te nemen.");
		Console.WriteLine("6) Telefoons en andere persoonlijke spullen worden achtergelaten in de locker in de ontvangstruimte. De sleutel van deze locker nemen jullie zelf mee)");
		Console.WriteLine("7) Geen foto's maken in de escape room.\n8) Mocht er iets naars gebeuren, of iemand wil uit de kamer, dan kan je de Escaperoom verlaten, de deur is open.\n9) Wanneer je besluit de Escaperoom te verlaten, heb je daarna geen toegang meer om het spel verder te spelen.");
		Console.WriteLine("10) De spelleider kijkt via camera's mee naar het spel. Bij het overtreden van de huisregels, kan hij/zij besluiten het spel te beëindigen. Hierover kan niet worden gediscussieerd.");
		Console.WriteLine("11) Je speelt het spel op eigen risico. Schade of letsel kan niet worden verhaald op de Escaperoom.");

		ReturnMenuFunction();
	}
	static void ContactFunction()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Contact and F.A.Q. page.\nPlease select one of the options below:\n\n1: Contact information\n2: F.A.Q.\n");
		string userInputCFAQ = Console.ReadLine();

		if (userInputCFAQ == "1")
		{
			Contact();
		}
		if (userInputCFAQ == "2")
		{
			FAQ();
		}

	}
	static void Contact()
	{
		Console.Clear();
		Console.WriteLine("Opening hours:\nMon to Thurs: 9:00am - 5:00pm\nFriday: 9:00am - 7:00pm\n\nTelephone number: 01034235423\n\nE-mail: EscapeMail@rooms.com\n\nLocation: Janpieterstraat 49 Rotterdam 3546WQ\n");

		ReturnMenuFunction();
	}
	static void FAQ()
	{
		String FAQ1 = "Q: Do you provide food during or after the Escape Room?\nA: We can provide food and drinks after the Escape Room is done via a special arrangement you can order.\n\n";
		String FAQ2 = "Q: Do I have to bring 5 people if the Escape Room specifically says its for 5 people?\nA: No you don't have to bring 5 people, but we recommend bringing as many people as possible up to the maximum amount.\n\n";
		String FAQ3 = "Q: Do you have Escape Rooms capable for someone inside a wheelchair?\nA: We try to make as many rooms available to everyone, even for people with certain disabilities.\n\n";

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
				AdminSuccess = AdminSuccess + 1;
				AdminPage();
			}
			else
			{
				LoginTries = LoginTries - 1;
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
		if (UserNameLogin != "user" || UserPassWordLogin != "12345")
		{
			Console.WriteLine("Wrong login credentials, press any key and try again.");
			Console.ReadKey(true);
			CustomerLoginFunction();
		}
	
		if (UserNameLogin == "user" && UserPassWordLogin == "12345")
		{
			CustomerSuccess = CustomerSuccess + 1;
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
			EmployeeSuccess = EmployeeSuccess + 1;
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
		Console.WriteLine("Welcome to the Customer menu!\n=======================================\n1: Escape Rooms\n2: Info \n3: Contact and F.A.Q.\n4: Receipt Example\n5: Reserveren\n6: Logout\n=======================================\n");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());
		
		if (InterFaceInput == 1) { ShowFunction(RoomsList); }
		if (InterFaceInput == 2) { InfoFunction(); }
		if (InterFaceInput == 3) { ContactFunction(); }
		if (InterFaceInput == 4) { ReceiptFunction(); }
		if (InterFaceInput == 5) { ReserveerFunction(); }
		if (InterFaceInput == 6) {
			CustomerSuccess = CustomerSuccess - 1;
			Main();
		}

	}

	static void EmployeeMenu()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the Employee menu!\n=======================================\n1: Escape Rooms\n2: Info \n3: Contact and F.A.Q.\n4: Reservations\n5: Logout\n=======================================\n");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());

		if (InterFaceInput == 1) { ShowFunction(RoomsList); }
		if (InterFaceInput == 2) { InfoFunction(); }
		if (InterFaceInput == 3) { ContactFunction(); }
		if (InterFaceInput == 4) { 
			Console.Clear();
			Console.WriteLine("W.I.P, press any key to continue.\n");
			Console.ReadKey(true);
			EmployeeMenu();
		}
		if (InterFaceInput == 5)
		{
			EmployeeSuccess = EmployeeSuccess - 1;
			Main();
		}
	}

	static void AdminPage()
	{
		Console.Clear();
		Console.WriteLine("Welcome to the admin page, please select what you would like to do today:\n=======================================\n1: Customer overview\n2: Add an escape room\n3: Edit an escape room\n4: Delete an escape room\n5: Show escape rooms\n6: Logout\n=======================================\n");
		int InterFaceInput = Convert.ToInt32(Console.ReadLine());

		if (InterFaceInput == 1) { CustomerOverview(); }
		if (InterFaceInput == 2) { AddFunction(RoomsList); }
		if (InterFaceInput == 3) { EditFunction(RoomsList); }
		if (InterFaceInput == 4) { DeleteFunction(RoomsList); }
		if (InterFaceInput == 5) { ShowFunction(RoomsList); }
		if (InterFaceInput == 6) 
		{ 
			LoginTries = 4;
			AdminSuccess = AdminSuccess - 1;
			Main();
		}
	}

	static void CustomerOverview()
	{
		Console.Clear();
		string userName = "Chris", userPostcode = "3067 PB", userLastName = "Man", userStreet = "teststraat", userWoonplaats = "Rotterdam", userEmail = "testemail@gmail.com";
		Console.WriteLine(userName + " " + userLastName + "," + userPostcode + "," + userStreet + "," + userWoonplaats + "," + userEmail + "\n");

		ReturnMenuFunction();
	}

	static void ReturnMenuFunction()
	{
		if (AdminSuccess == 1)
		{
			Console.WriteLine("======================\nGo back to the menu? y or n");
			string return_to_menu = Console.ReadLine();
			if (return_to_menu == "y")
			{
				Console.Clear();
				AdminPage();
			}
			if (return_to_menu != "n")
			{
				Console.Clear();
				Console.WriteLine("Error, you didn't press y or n.\nAs a failsafe you will be returned to the main menu.\nPress any key to return to the main menu.");
				Console.ReadKey(true);
				Main();
			}
		}
		if (EmployeeSuccess == 1)
		{
			Console.WriteLine("======================\nGo back to the menu? y or n");
			string return_to_menu = Console.ReadLine();
			if (return_to_menu == "y")
			{
				Console.Clear();
				EmployeeMenu();
			}
			if (return_to_menu != "n")
			{
				Console.Clear();
				Console.WriteLine("Error, you didn't press y or n.\nAs a failsafe you will be returned to the main menu.\nPress any key to return to the main menu.");
				Console.ReadKey(true);
				Main();
			}
		}
		if (CustomerSuccess == 1)
		{
			Console.WriteLine("======================\nGo back to the menu? y or n");
			string return_to_menu = Console.ReadLine();
			if (return_to_menu == "y")
			{
				Console.Clear();
				CustomerMenu();
			}
			if (return_to_menu != "n")
			{
				Console.Clear();
				Console.WriteLine("Error, you didn't press y or n.\nAs a failsafe you have been logged out and will be returned to the main menu.\n\nPress any key to return to the main menu.");
				Console.ReadKey(true);
				Main();
			}
		}
	}

	static void ReserveerFunction()
	{

		Console.Clear();

		Console.WriteLine("-----------------------------");
		Console.WriteLine("Please Choose your room and fill in the information required:");
		Console.WriteLine("-----------------------------");

		Console.WriteLine("Which of the following room do you want? (choose a number between 1" + "-" + Convert.ToString(RoomsList.Count) + ")"); // Tussen 1-5
		
		for (int i = 0; i < RoomsList.Count; i++) {Console.WriteLine("- " + RoomsList[i].roomName);}
		Console.WriteLine("\nRoom:");
		roomKeuze = Convert.ToInt32(Console.ReadLine());
		while (roomKeuze < 1 || roomKeuze > RoomsList.Count)
		{
			Console.WriteLine("*****ERROR*****\nPlease fill in a number between 1-" + Convert.ToString(RoomsList.Count) + ")");
			roomKeuze = Convert.ToInt32(Console.ReadLine());
		}

		Console.WriteLine("Fill in your first name(e.g. 'Piet'):"); // Alleen Letters
		userName = Console.ReadLine();

		Console.WriteLine("Fill in your last name(e.g. 'de Koning'):"); //Alleen Letters
		userLastName = Console.ReadLine();
		
		Console.WriteLine("Fill in your postcode(e.g. '2631 JK'):"); //4 Cijfers & 2 Letters
		userPostcode = Console.ReadLine();

		Console.WriteLine("Fill in your street(e.g. 'Tulpenlaan'):"); // Alleen Letters
		userStreet = Console.ReadLine();

		Console.WriteLine("Fill in your residence(e.g. 'Pijnacker'):"); // Alleen Letters
		userWoonplaats = Console.ReadLine();

		Console.WriteLine("Fill in your housenumber(e.g. '98'):"); // Alleen cijfers max. 19999
		userHouseNumber = Console.ReadLine();

		Console.WriteLine("Fill in your email(e.g. 'voorbeeld@mail.com'):"); // Moet een @ en . hebben
		userEmail = Console.ReadLine();

		Console.WriteLine("Fill in your telephonenumber(e.g. ' (+31) 6 7631 9854'):"); // Alleen cijfers max. 10 getallen
		userPhoneNumber = Console.ReadLine();

		Console.WriteLine("Fill in how many participants there will be(" + RoomsList[Convert.ToInt32(roomKeuze-1)].roomMinSize + "-" + RoomsList[Convert.ToInt32(roomKeuze-1)].roomMaxSize + ")"); // 2-6 deelnemers
		userParticipants = Convert.ToInt32(Console.ReadLine());
		while (userParticipants < RoomsList[Convert.ToInt32(roomKeuze-1)].roomMinSize || userParticipants > RoomsList[Convert.ToInt32(roomKeuze)].roomMaxSize)
		{
			Console.WriteLine("*****ERROR*****\nPlease fill in a number between " + RoomsList[Convert.ToInt32(roomKeuze-1)].roomMinSize + " - " + RoomsList[Convert.ToInt32(roomKeuze-1)].roomMaxSize + ")");
			userParticipants = Convert.ToInt32(Console.ReadLine());
		}



		Console.Clear();
		ReceiptFunction();
	}

	static void ReceiptFunction()
	{
		bool IDcheck = false;
		while (IDcheck == false)
		{
			for (int i = 0; i < IDList.Count + 1; i++)
			{
				if (!IDList.Contains(i))
				{
					userUniqueID = i;
					IDList.Add(i);
					IDcheck = true;
				}

			}
		}
		double userTotalPrice = 53.95; //Dit wordt in later berekend

		Console.Clear();
		Console.WriteLine("======================");
		Console.WriteLine("\nThe following room has been chosen: " + RoomsList[Convert.ToInt32(roomKeuze)].roomName);
		Console.WriteLine("Amount of participants: " + userParticipants);
		Console.WriteLine("\nClient Name: " + userName + " " + userLastName);
		Console.WriteLine("\nClient Street: " + userStreet + " " + userHouseNumber);
		Console.WriteLine("\nClient Postcode: " + userPostcode);
		Console.WriteLine("\nClient Woonplaats: " + userWoonplaats);
		Console.WriteLine("\nClient Phonenumber: " + userPhoneNumber);
		Console.WriteLine("\nTotal Price: " + userTotalPrice);
		Console.WriteLine("\nClient UniqueID (Bring this to the desk): " + userUniqueID);
		Console.WriteLine("\n\nThis will be send to the following email address: " + userEmail);

		ReturnMenuFunction();
	}
}




