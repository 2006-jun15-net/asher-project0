using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class PlacedOrders
    {
        public int OrderId { get; set; }
        public string CustomerUsername { get; set; }
        public string LocationAddress { get; set; }
        public DateTime TimeOrdered { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Customer CustomerUsernameNavigation { get; set; }
        public virtual Location LocationAddressNavigation { get; set; }
    }
}
