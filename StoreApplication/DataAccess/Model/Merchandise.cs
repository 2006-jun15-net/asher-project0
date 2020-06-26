using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Merchandise
    {
        public string LocationAddress { get; set; }
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Location LocationAddressNavigation { get; set; }
    }
}
