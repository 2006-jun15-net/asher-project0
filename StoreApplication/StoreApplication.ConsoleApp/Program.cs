using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.ConsoleApp
{
    class Program
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        static void Main(string[] args)
        {
            CustomerRepository repository = new CustomerRepository(context);
            GenericRepository<Product> genericRepository= new GenericRepository<Product>();
            GenericRepository<Location> genericRepository2 = new GenericRepository<Location>();
            GenericRepository<OrderHistory> generic = new GenericRepository<OrderHistory>();
            UI.IntroMenu();
            //UI.DisplayOrder(generic.GetById(3));
            //UI.DisplayCustomerOrderHistories(repository.GetById(1));
            //UI.DisplayLocationOrderHistories(genericRepository2.GetById(2));
        }
    }
}
