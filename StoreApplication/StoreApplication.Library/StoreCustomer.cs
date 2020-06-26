using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class StoreCustomer
    {
        private string _firstName;
        private string _lastName;
        private List<Order> _orderHistory = new List<Order>();

        public string firstName
        {
            get => _firstName;
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("First name cannot be null");
                }
                else if (value.Length == 0)
                {
                    throw new ArgumentException("First name cannot be empty.", nameof(value));
                }
                else
                {
                    _firstName = value;
                }
            }
        }
        public string lastName 
        {
            get => _lastName; 
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name cannot be null");
                }
                else if (value.Length == 0)
                {
                    throw new ArgumentException("First name cannot be empty.", nameof(value));
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
    }
}
