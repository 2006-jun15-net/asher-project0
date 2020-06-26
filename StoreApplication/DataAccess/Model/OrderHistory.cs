using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            Orders = new HashSet<Orders>();
        }

        public int OrderHistoryId { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }
        public DateTime TimeOrdered { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
