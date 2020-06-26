using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ProductId { get; set; }
        public int InStock { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
