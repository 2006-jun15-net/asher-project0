using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Location
    {
        public Location()
        {
            PlacedOrders = new HashSet<PlacedOrders>();
        }

        public int LocationId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<PlacedOrders> PlacedOrders { get; set; }
    }
}
