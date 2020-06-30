using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private Project0StoreContext context;
        private DbSet<OrderHistory> table = null;

        public OrderHistoryRepository()
        {
            context = new Project0StoreContext();
            table = context.Set<OrderHistory>();
        }
        public OrderHistoryRepository(Project0StoreContext context)
        {
            this.context = context;
            table = context.Set<OrderHistory>();
        }

        public IEnumerable<OrderHistory> GetAllCustomerOrders(Customer customer)
        {
            return context.OrderHistory.Where(o => o.CustomerId == customer.CustomerId).ToList();
        }

        public IEnumerable<OrderHistory> GetAllLocationOrders(Location location)
        {
            return context.OrderHistory.Where(o => o.LocationId == location.LocationId).ToList();
        }

        public OrderHistory GetById(int id)
        {
            return table.Find(id);
        }

        public OrderHistory getCustomerRef(OrderHistory orderHistory)
        {
            return context.OrderHistory.Where(o => o.OrderHistoryId == orderHistory.OrderHistoryId).Include(c => c.Customer).FirstOrDefault();
        }

        public OrderHistory getLocationRef(OrderHistory orderHistory)
        {
            return context.OrderHistory.Where(o => o.OrderHistoryId == orderHistory.OrderHistoryId).Include(l => l.Location).FirstOrDefault();
        }
    }
}
