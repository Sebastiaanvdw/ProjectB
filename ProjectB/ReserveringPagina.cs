using System;

namespace Reservering_Pagina
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Vul al uw gegevens in:");
            Console.WriteLine("--------------------------------------------");


            Console.WriteLine("Naam:"); // Alleen Letters
            string userName = Console.ReadLine();

            Console.WriteLine("Achternaam:"); //Alleen Letters
            string userLastName = Console.ReadLine();

            Console.WriteLine("Postcode:"); //4 Cijfers & 2 Letters
            string userPostcode = Console.ReadLine();

            Console.WriteLine("Straatnaam:"); // Alleen Letters
            string userStreet = Console.ReadLine();

            Console.WriteLine("Woonplaats:"); // Alleen Letters
            string userWoonplaats = Console.ReadLine();

            Console.WriteLine("Huisnummer:"); // Alleen cijfers max. 19999
            string userHouseNumber= Console.ReadLine();

            Console.WriteLine("Email:"); // Moet een @ en . hebben
            string userEmail = Console.ReadLine();
            
            Console.WriteLine("Telefoonnummer:"); // Alleen cijfers max. 10 getallen
            string userPhoneNumber = Console.ReadLine();

            Console.WriteLine("Aantal Deelnemers:"); // Max. 5 deelnemers
            string userParticipants = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Check of al uw ingevulde gegevens correct zijn!");
            Console.WriteLine("--------------------------------------------");

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

            Console.WriteLine("");
            Console.WriteLine("Zijn al uw gegevens correct ingevuld?");
            string correctInfo = Console.ReadLine();






        }
    }
}
