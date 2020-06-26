using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public Project0StoreContext context = new Project0StoreContext(Options);

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

    internal class SecretConfiguration
    {
        internal const string ConnectionString = "Server=tcp:williams1998.database.windows.net,1433;Initial Catalog=Project-0-Store;" +
            "Persist Security Info=False;User ID=asher;Password=Clarkezlayer571;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
