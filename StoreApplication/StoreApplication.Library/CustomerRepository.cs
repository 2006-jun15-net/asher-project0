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

        private List<Customer> findCustomerByName(string FirstName, string LastName)
        {

            List<Customer> customer = context.Customer.Where(c => (c.FirstName == FirstName) && (c.LastName == LastName)).ToList();
            return customer;
        }

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
    }
}
