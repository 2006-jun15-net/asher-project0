using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaxPerOrder { get; set; }
    }
}
