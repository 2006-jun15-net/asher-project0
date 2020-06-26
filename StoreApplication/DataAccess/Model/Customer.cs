using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
