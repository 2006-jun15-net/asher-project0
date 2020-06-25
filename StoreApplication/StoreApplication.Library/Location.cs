using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Location
    {
        private static int idSeed = 1;

        private string _address;
        private List<Order> _orderHistory = new List<Order>();
        private Dictionary<Product, int> _inventory = new Dictionary<Product, int>();
        private int _locationID;

        public string address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();

        public Location(string address)
        {
            this._locationID = idSeed;
            idSeed++;

            this._address = address;
        }
    }
}
