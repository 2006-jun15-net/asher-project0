using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.Library
{
    public class CustomerRepository : ICustomerRepository
    {
        private Project0StoreContext context;

        public CustomerRepository(Project0StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable GetCustomers()
        {
            return context.Customer.ToList();
        }

        public Customer findCustomerByName(string FirstName, string LastName)
        {
            Customer customer = null;
            try
            {
                customer = context.Customer.Single(c => (c.FirstName == FirstName) && (c.LastName == LastName));
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("There are multiple entries in the database with those values");
            }
            return customer;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
