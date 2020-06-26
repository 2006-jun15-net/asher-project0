using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreApplication.ConsoleApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace StoreApplication.Library
{
    public class Store
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        private static List<Product> _productData;
        private static List<Location> _locationData;
        private static List<Customer> _customerData;

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

        public static void LoadFromDatabase()
        {
            _productData = context.Product.ToList();
            _locationData = context.Location.ToList();
            _customerData = context.Customer.ToList();
        }
        /*
        public static void DeserializeData()
        {
            try
            {
                string Json = File.ReadAllText("../../../Location-data.json");
                _locationData = JsonConvert.DeserializeObject<List<StoreLocation>>(Json);
                //Console.WriteLine("Location Success");

                Json = File.ReadAllText("../../../Product-data.json");
                _productData = JsonConvert.DeserializeObject<List<StoreProduct>>(Json);
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
        */
    }
}
