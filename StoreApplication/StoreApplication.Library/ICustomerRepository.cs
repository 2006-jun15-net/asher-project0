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
        Customer findCustomerByName(string FirstName, string LastName);
        void Save();
    }
}
