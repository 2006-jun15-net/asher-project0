using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.Library
{
    public class Store
    {
        //public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            //.UseSqlServer(SecretConfiguration.ConnectionString)
            //.Options;
        //public static Project0StoreContext context = new Project0StoreContext(Options);

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

        public static void LoadFromDatabase(Project0StoreContext context)
        {
            _productData = context.Product.ToList();
            _locationData = context.Location.ToList();
            _customerData = context.Customer.ToList();
        }
    }
}
