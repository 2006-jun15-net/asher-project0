using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
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
        public List<Order> OrderHistory { get; set; } = new List<Order>();
    }
}
