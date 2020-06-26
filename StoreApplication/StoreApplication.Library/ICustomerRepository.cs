using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public interface ICustomerRepository
    {
        IEnumerable GetCustomers();
        Customer findCustomer(string FirstName, string LastName, string UserName);
        void AddCustomer(Customer customer);
        void Save();
    }
}
