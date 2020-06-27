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
            //Store.LoadFromDatabase(context);

            CustomerRepository repository = new CustomerRepository(context);
            UI.IntroMenu();
            /*
            Console.Write("Enter a username: ");
            string user = Console.ReadLine();
            if(user.Length > 26)
            {
                Console.WriteLine("Username too long");
            }
            else
            {
                Customer result2 = context.Customer.FirstOrDefault(c => c.UserName == user);
                if (result2 == null)
                {
                    Console.WriteLine("not in DB");
                }
            }
            */
            
        }
    }
}
