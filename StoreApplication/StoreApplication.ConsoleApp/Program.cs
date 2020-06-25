using Newtonsoft.Json;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializeData();
            loadData();
        }

        private static void loadData()
        {
            //string filePath = "../../../Product-data.json";
            string filePath = "../../../Location-data.json";
            //List<Product> data;
            List<Location> data;
            string initialJson = File.ReadAllText(filePath);
            //data = JsonConvert.DeserializeObject<List<Product>>(initialJson);
            data = JsonConvert.DeserializeObject<List<Location>>(initialJson);

            //Console.WriteLine(data[0].name + ", " + data[0].price + ", " + data[0].maxPerOrder);
            Console.WriteLine(data[0].address + ", " + data[0].city + ", " + data[0].state);
        }
        private static void initializeData()
        {
            List<Location> locationData = new List<Location>
            {
                new Location
                {
                    address = "624 Central Dr.",
                    city = "Austin",
                    state = "TX"
                },
                new Location
                {
                    address = "835 Oakwood Blvd.",
                    city = "Chicago",
                    state = "IL"
                },
                new Location
                {
                    address = "294 Harwood Dr.",
                    city = "New York City",
                    state = "NY"
                },
                new Location
                {
                    address = "7147 Grand Avenue",
                    city = "Los Angelas",
                    state = "CA"
                },
                new Location
                {
                    address = "7291 Primrose Road",
                    city = "New Orleans",
                    state = "LA"
                }
            };


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
        }
    }
}
