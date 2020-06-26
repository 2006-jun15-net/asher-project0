using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        private StoreCustomer _customer;
        private DateTime _timeOrdered;
        private StoreLocation _location;
        private double _TotalAmount;

        public StoreCustomer customer
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
        public StoreLocation location
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
