using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        private readonly string _path = $"C:\\Users\\Adam__w4s0tew\\OneDrive\\Bureaublad\\ConsoleAppJson2\\ConsoleApp2\\Dagen.json";

        public static TimeSpan roomDuration = TimeSpan.Parse("1:00");
        public static string[] tijden = new string[3] { "09:15", "12:15", "14:45" };
        public static string[] opties = new string[3] { "1", "2", "3" };

        static void Main()
        {

            TimeSpan endTime = roomDuration + TimeSpan.Parse(tijden[2]);
            string formattedEndTime = endTime.ToString("hh\\:mm");

            string json = File.ReadAllText("C:\\Users\\Adam__w4s0tew\\OneDrive\\Bureaublad\\ConsoleAppJson2\\ConsoleApp2\\Dagen.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            Console.WriteLine("");
            Console.WriteLine("-- Availability Escape Rooms --");



            {

                Console.WriteLine("----------------------Monday----------------------");
                Console.WriteLine(jsonObj["Monday"][0]["Availability1"]);
                Console.WriteLine(jsonObj["Monday"][1]["Availability2"]);
                Console.WriteLine(jsonObj["Monday"][2]["Availability3"]);

                Console.WriteLine("----------------------Tuesday----------------------");
                Console.WriteLine(jsonObj["Tuesday"][0]["Availability1"]);
                Console.WriteLine(jsonObj["Tuesday"][1]["Availability2"]);
                Console.WriteLine(jsonObj["Tuesday"][2]["Availability3"]);

                Console.WriteLine("----------------------Wednesday----------------------");
                Console.WriteLine(jsonObj["Wednesday"][0]["Availability1"]);
                Console.WriteLine(jsonObj["Wednesday"][1]["Availability2"]);
                Console.WriteLine(jsonObj["Wednesday"][2]["Availability3"]);

                Console.WriteLine("----------------------Thursday----------------------");
                Console.WriteLine(jsonObj["Thursday"][0]["Availability1"]);
                Console.WriteLine(jsonObj["Thursday"][1]["Availability2"]);
                Console.WriteLine(jsonObj["Thursday"][2]["Availability3"]);

                Console.WriteLine("----------------------Friday----------------------");
                Console.WriteLine(jsonObj["Friday"][0]["Availability1"]);
                Console.WriteLine(jsonObj["Friday"][1]["Availability2"]);
                Console.WriteLine(jsonObj["Friday"][2]["Availability3"]);



            }
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("C:\\Users\\Adam__w4s0tew\\OneDrive\\Bureaublad\\ConsoleAppJson\\ConsoleApp2\\Dagen.json", output);
            {
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("Wil je alle tijden weer beschikbaar stellen?\n");

                switch (Console.ReadLine())
                {
                    
                    case "Ja":
                        jsonObj["Monday"][0]["Availability1"] = "Available";
                        jsonObj["Monday"][1]["Availability2"] = "Available";
                        jsonObj["Monday"][2]["Availability3"] = "Available";
                        jsonObj["Tuesday"][0]["Availability1"] = "Available";
                        jsonObj["Tuesday"][1]["Availability2"] = "Available";
                        jsonObj["Tuesday"][2]["Availability3"] = "Available";
                        jsonObj["Wednesday"][0]["Availability1"] = "Available";
                        jsonObj["Wednesday"][1]["Availability2"] = "Available";
                        jsonObj["Wednesday"][2]["Availability3"] = "Available";
                        jsonObj["Thursday"][0]["Availability1"] = "Available";
                        jsonObj["Thursday"][1]["Availability2"] = "Available";
                        jsonObj["Thursday"][2]["Availability3"] = "Available";
                        jsonObj["Friday"][0]["Availability1"] = "Available";
                        jsonObj["Friday"][1]["Availability2"] = "Available";
                        jsonObj["Friday"][2]["Availability3"] = "Available";

                        output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText("C:\\Users\\Adam__w4s0tew\\OneDrive\\Bureaublad\\ConsoleAppJson2\\ConsoleApp2\\Dagen.json", output);
                        break;
                    case "ja":
                        // 
                        break;
                    case "Nee":
                        break;
                    case "nee":
                        break;
                        
                }

                Console.WriteLine("Terug naar het hoofdmenu?: (Ja of Nee)\n");

                switch (Console.ReadLine())
                {
                    case "Ja":
                        Main();
                        break;
                    case "ja":
                        Main();
                        break;
                    case "Nee":
                        break;
                    case "nee":
                        break;
                }
            }
        }
    }
}
