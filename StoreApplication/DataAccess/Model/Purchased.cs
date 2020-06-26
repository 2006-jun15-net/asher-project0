using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Purchased
    {
        public DateTime TimeOrdered { get; set; }
        public string CustomerUsername { get; set; }
        public string ProductName { get; set; }

        public virtual PlacedOrders PlacedOrders { get; set; }
        public virtual Product ProductNameNavigation { get; set; }
    }
}
