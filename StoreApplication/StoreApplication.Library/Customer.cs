using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class Customer
    {
        private static int idSeed = 1;
        private string _firstName;
        private string _lastName;
        private int _customerID;
        private List<Order> _orderHistory = new List<Order>();

        public string firstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
            }
        }
        public string lastName 
        {
            get => _lastName; 
            set
            {
                _lastName = value;
            }
        }
        public int customerID 
        {
            get => _customerID;
        }
        public List<Order> OrderHistory { get; set; } = new List<Order>();

        public Customer(string firstName, string lastName)
        {
            this._customerID = idSeed;
            idSeed++;

            this._firstName = firstName;
            this._lastName = lastName;
        }
    }
}
