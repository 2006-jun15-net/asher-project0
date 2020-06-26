using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class StoreProduct
    {
        private string _name;
        private double _price;
        private int _maxPerOrder;

        public string name
        {
            get => _name;

            set
            {
                _name = value;
            }
        }
        public double price
        {
            get => _price;

            set
            {
                _price = value;
            }
        }
        // remember to delete set function once serialization works
        public int maxPerOrder
        {
            get => _maxPerOrder;

            set
            {
                _maxPerOrder = value;
            }
        }
    }
}
