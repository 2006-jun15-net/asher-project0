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
            string filePath = "../../../Product-data.json";
            List<Product> data;
            string initialJson = File.ReadAllText(filePath);
            data = JsonConvert.DeserializeObject<List<Product>>(initialJson);

            Console.WriteLine(data[0].name + " " + data[0].price + " " + data[0].maxPerOrder);
        }
        private static void initializeData()
        {
            List<Product> productData = new List<Product>
            {
                new Product
                {
                    name = "Xbox One Console",
                    price = 500.00,
                    maxPerOrder = 2
                },
                new Product
                {
                    name = "Playstation 4",
                    price = 550.00,
                    maxPerOrder = 2
                },
                new Product
                {
                    name = "Nintendo Switch",
                    price = 500.00,
                    maxPerOrder = 2
                },
                new Product
                {
                    name = "Halo 5",
                    price = 60.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "Dead Space",
                    price = 20.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "Spider-Man the Game",
                    price = 60.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "Fire Emblem: Three Houses",
                    price = 60.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "The Witcher 3: Wild Hunt",
                    price = 35.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "Call of Duty: Modern Warfare",
                    price = 60.00,
                    maxPerOrder = 3
                },
                new Product
                {
                    name = "Mass Effect Trilogy Collection",
                    price = 30.00,
                    maxPerOrder = 3
                }
            };

            string filePath = "../../../Product-data.json";

            string json = JsonConvert.SerializeObject(productData, Formatting.Indented);
            File.WriteAllText(filePath, json);
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, productData);
            }
            Console.WriteLine("Success");

            //FileStream fileStream = null;
            //using (var fileStream = new FileStream(filePath, FileMode.Create)) {}
        }
    }
}
