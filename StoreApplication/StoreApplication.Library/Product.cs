using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Product
    {
        private static int idSeed = 1;

        private string _name;
        private double _price;
        private int _maxPurchaseAmount;
        private int _productID;

        public string name
        {
            get => _name;

            set
            {

            }
        }
        public double price
        {
            get => _price;

            set
            {

            }
        }
        public int maxPurchaseAmount
        {
            get => _maxPurchaseAmount;
        }

        public Product(string name, double price, int maxPurchaseAmount)
        {
            this._productID = idSeed;
            idSeed++;

            this._name = name;
            this._price = price;
            this._maxPurchaseAmount = maxPurchaseAmount;
        }
    }
}
