using System;

namespace Reservering_Pagina
{
    class Program
    {
        static void ReserveringPagina()
        {

            Console.Clear();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Vul al uw gegevens in:");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Welke room kiest u:"); // Tussen 1-5
            Console.WriteLine("Room 1)" + "\n" + "Room 2)" + "\n" + "Room 3)" + "\n" + "Room 4)" + "\n" + "Room 5)");
            string roomKeuze = Console.ReadLine();

            Console.WriteLine("Vul uw naam in(Voorb. 'Piet'):"); // Alleen Letters
            string userName = Console.ReadLine();

            Console.WriteLine("Vul uw achternaam in(Voorb. 'de Koning'):"); //Alleen Letters
            string userLastName = Console.ReadLine();

            Console.WriteLine("Vul uw postcode in(Voorb. '2631 JK'):"); //4 Cijfers & 2 Letters
            string userPostcode = Console.ReadLine();

            Console.WriteLine("Vul uw straatnaam in(Voorb. 'Tulpenlaan'):"); // Alleen Letters
            string userStreet = Console.ReadLine();

            Console.WriteLine("Vul uw woonplaats in(Voorb. 'Pijnacker'):"); // Alleen Letters
            string userWoonplaats = Console.ReadLine();

            Console.WriteLine("Vul uw huisnummer in(Voorb. '98'):"); // Alleen cijfers max. 19999
            string userHouseNumber = Console.ReadLine();

            Console.WriteLine("Vul uw email in(Voorb. 'voorbeeld@mail.com'):"); // Moet een @ en . hebben
            string userEmail = Console.ReadLine();

            Console.WriteLine("Vul uw telefoonnummer in(Voorb. ' (+31) 6 7631 9854'):"); // Alleen cijfers max. 10 getallen
            string userPhoneNumber = Console.ReadLine();

            Console.WriteLine("Hoeveel deelnemers zijn er(2-5):"); // 2-5 deelnemers
            string userParticipants = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Check of al uw ingevulde gegevens correct zijn!");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Kamer:");
            Console.WriteLine(roomKeuze);
            Console.WriteLine("Naam:");
            Console.WriteLine(userName);
            Console.WriteLine("Achternaam:");
            Console.WriteLine(userLastName);
            Console.WriteLine("Postcode:");
            Console.WriteLine(userPostcode);
            Console.WriteLine("Straatnaam:");
            Console.WriteLine(userStreet);
            Console.WriteLine("Woonplaats:");
            Console.WriteLine(userWoonplaats);
            Console.WriteLine("Huisnummer:");
            Console.WriteLine(userHouseNumber);
            Console.WriteLine("Email:");
            Console.WriteLine(userEmail);
            Console.WriteLine("Telefoonnummer:");
            Console.WriteLine(userPhoneNumber);
            Console.WriteLine("Deelnemers:");
            Console.WriteLine(userParticipants);

            //Console.WriteLine("");
            //Console.WriteLine("Zijn al uw gegevens correct ingevuld?");
            //string correctInfo = Console.ReadLine();

            //switch (Console.ReadLine())
            //{
            //case "nee":
            //Console.Clear();
            //Console.WriteLine("Wat is niet goed ingevuld: ");
            //Console.WriteLine("1) Kamer");
            //Console.WriteLine("2) Naam");
            //Console.WriteLine("3) Achternaam");
            //Console.WriteLine("4) Postcode");
            //Console.WriteLine("5) Straatnaam");
            //Console.WriteLine("6) Woonplaats");
            //Console.WriteLine("7) Huisnummer");
            //Console.WriteLine("8) Email");
            //Console.WriteLine("9) Telefoonnummer");
            //Console.WriteLine("10) Deelnemers");
            //Console.ReadLine();
            //break;
            //}


        }
    }
}

