using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        private Customer _customer;
        private DateTime _timeOrdered;
        private Location _location;
        private double _TotalAmount;

        public Customer customer
        {
            get => _customer;

            set
            {
                _customer = value;
            }
        }
        public DateTime timeOrdered
        {
            get => _timeOrdered;

            set
            {
                _timeOrdered = value;
            }
        }
        public Location location
        {
            get => _location;

            set
            {
                _location = value;
            }
        }
        public double totalAmount
        {
            get => _TotalAmount;

            set
            {
                _TotalAmount = value;
            }
        }
    }
}
