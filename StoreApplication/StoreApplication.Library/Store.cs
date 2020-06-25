using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Store
    {
        private List<Product> _productData;
        private List<Location> _locationData;
        private List<Customer> _customerData;

        public List<Product> ProductData
        {
            get => _productData;
        }
        public List<Location> LocationData
        {
            get => _locationData;
        }
        public List<Customer> CustomerData
        {
            get => _customerData;
        }

        public Store()
        {

        }
    }
}
