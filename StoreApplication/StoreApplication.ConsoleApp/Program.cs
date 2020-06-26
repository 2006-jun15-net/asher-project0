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
            //Store.LoadData();
            //UI.IntroMenu();
            
            
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
