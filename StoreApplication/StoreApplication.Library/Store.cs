using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
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
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        private static List<StoreProduct> _productData;
        private static List<StoreLocation> _locationData;
        private static List<StoreCustomer> _customerData = new List<StoreCustomer>();

        public static List<StoreProduct> ProductData
        {
            get => _productData;
        }
        public static List<StoreLocation> LocationData
        {
            get => _locationData;
        }
        public static List<StoreCustomer> CustomerData
        {
            get => _customerData;
        }

        public static void LoadDatabase()
        {
            
        }
        public static void LoadData()
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

        internal class SecretConfiguration
        {
            internal const string ConnectionString = "Server=tcp:williams1998.database.windows.net,1433;Initial Catalog=Project-0-Store;" +
                "Persist Security Info=False;User ID=asher;Password=Clarkezlayer571;MultipleActiveResultSets=False;" +
                "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
