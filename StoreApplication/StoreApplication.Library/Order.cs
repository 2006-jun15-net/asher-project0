using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        private static int idSeed = 1;

        private Customer _customer;
        private DateTime _timeOrdered;
        private Location _location;
        private double _TotalAmount;
        private int _orderID;

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

        public Order(Customer customer, Location location, DateTime timeOrdered)
        {
            this._orderID = idSeed;
            idSeed++;

            this._customer = customer;
            this._location = location;
            this._timeOrdered = timeOrdered;
        }
    }
}
