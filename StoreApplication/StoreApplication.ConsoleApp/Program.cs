﻿using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Library;
using System;

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
            var customer = repository.findCustomerByName("Christian", "Roberts");
            Console.WriteLine(customer.CustomerId);
        }
    }
}
