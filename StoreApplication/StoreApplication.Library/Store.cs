using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace StoreApplication.Library
{
    public static class Store
    {
        private static List<Product> _productData;
        private static List<Location> _locationData;
        private static List<Customer> _customerData = new List<Customer>();

        public static List<Product> ProductData
        {
            get => _productData;
        }
        public static List<Location> LocationData
        {
            get => _locationData;
        }
        public static List<Customer> CustomerData
        {
            get => _customerData;
        }

        public static void LoadData()
        {
            try
            {
                string Json = File.ReadAllText("../../../Location-data.json");
                _locationData = JsonConvert.DeserializeObject<List<Location>>(Json);
                //Console.WriteLine("Location Success");

                Json = File.ReadAllText("../../../Product-data.json");
                _productData = JsonConvert.DeserializeObject<List<Product>>(Json);
                //Console.WriteLine("Product Success");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"No saved data found: {e.Message}");
            }
            catch (SecurityException e)
            {
                Console.WriteLine($"Error while loading: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error while loading: {e.Message}");
            }
        }
    }
}
