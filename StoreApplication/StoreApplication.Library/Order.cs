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

            }
        }
        public DateTime timeOrdered
        {
            get => _timeOrdered;

            set
            {

            }
        }
        public Location location
        {
            get => _location;

            set
            {

            }
        }
        public double totalAmount
        {
            get => _TotalAmount;

            set
            {

            }
        }
    }
}
