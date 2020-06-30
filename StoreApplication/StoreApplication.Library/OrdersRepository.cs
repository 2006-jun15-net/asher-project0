using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class OrdersRepository : IOrdersRepository
    {
        private Project0StoreContext context = null;
        private DbSet<Orders> table = null;

        public OrdersRepository()
        {
            context = new Project0StoreContext();
            table = context.Set<Orders>();
        }
        public OrdersRepository(Project0StoreContext context)
        {
            this.context = context;
            table = this.context.Set<Orders>();
        }

        public double CalculateTotal(Product product, Orders orders)
        {
            double sum = (double)(product.Price * orders.AmountOrdered);
            return sum;
        }

        public IEnumerable<Orders> GetAllOrdersInHistory()
        {
            return context.Orders.Include(oh => oh.OrderHistory);
        }
    }
}
