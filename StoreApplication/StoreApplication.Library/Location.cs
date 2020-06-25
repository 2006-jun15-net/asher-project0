using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Location
    {
        private string _address;
        private string _city;
        private string _state;
        private List<Order> _orderHistory = new List<Order>();
        private Dictionary<Product, int> _inventory = new Dictionary<Product, int>();

        public string address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }
        public string city
        {
            get => _city;
            set
            {
                _city = value;
            }
        }
        public string state
        {
            get => _state;
            set
            {
                _state = value;
            }
        }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();
    }
}
