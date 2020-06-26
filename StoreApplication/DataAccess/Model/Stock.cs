using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Stock
    {
        public int? InventoryId { get; set; }
        public string ProductName { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Product ProductNameNavigation { get; set; }
    }
}
