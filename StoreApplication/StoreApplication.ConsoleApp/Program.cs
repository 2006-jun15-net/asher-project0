using Newtonsoft.Json;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializeData();
            Store.LoadData();
            string input;
            while(true)
            {
                input = UI.IntroMenu();
                if(input == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Signing In");
                    break;
                }
                else if(input == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That's not a valid choice. Please try again.");
                    Console.WriteLine();
                }
            }
            
            //Console.WriteLine($"Location Count: {Store.LocationData.Count}");
            //Console.WriteLine($"Product Count: {Store.ProductData.Count}");
        }
        
        private static void initializeData()
        {
            /*
            string filePath = "../../../Location-data.json";

            string json = JsonConvert.SerializeObject(locationData, Formatting.Indented);
            File.WriteAllText(filePath, json);
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, locationData);
            }
            Console.WriteLine("Success");

            //FileStream fileStream = null;
            //using (var fileStream = new FileStream(filePath, FileMode.Create)) {}
            */
        }
    }
}
