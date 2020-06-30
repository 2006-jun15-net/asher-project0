using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.Library
{
    public class CustomerRepository : ICustomerRepository
    {
        private Project0StoreContext context;
        private DbSet<Customer> table = null;

        public CustomerRepository()
        {
            context = new Project0StoreContext();
            table = context.Set<Customer>();
        }
        public CustomerRepository(Project0StoreContext context)
        {
            this.context = context;
            table = context.Set<Customer>();
        }
        public IEnumerable GetCustomers()
        {
            return context.Customer.ToList();
        }

        public Customer GetById(object id)
        {
            return table.Find(id);
        }

        /// <summary>
        /// Looks in the DB for any customer with the given first and last names
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        private List<Customer> findCustomerByName(string FirstName, string LastName)
        {

            List<Customer> customer = context.Customer.Where(c => (c.FirstName == FirstName) && (c.LastName == LastName)).ToList();
            return customer;
        }

        // Looks in the DB for any customer with the given first,last, and username
        public Customer findCustomer(string FirstName, string LastName, string UserName)
        {
            List<Customer> customers = findCustomerByName(FirstName, LastName);
            if(customers.Count > 1)
            {
                return customers.Find(c => c.UserName == UserName);
            }
            else if (customers.Count == 1)
            {
                if(customers.Find(c => c.UserName == UserName) == null)
                {
                    return null;
                }

                return customers[0];
            }
            else
            {
                return null;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            context.Customer.Add(customer);
        }

        public bool DoesUsernameExist(Customer customer)
        {
            bool result = (context.Customer.FirstOrDefault(c => c.UserName == customer.UserName) != null);
            return result;
        }
    }
}
