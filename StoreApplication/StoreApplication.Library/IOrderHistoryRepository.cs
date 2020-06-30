using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    interface IOrderHistoryRepository
    {
        OrderHistory getCustomerRef(OrderHistory orderHistory);
        OrderHistory getLocationRef(OrderHistory orderHistory);
        OrderHistory GetById(int id);
        IEnumerable<OrderHistory> GetAllCustomerOrders(Customer customer);
        IEnumerable<OrderHistory> GetAllLocationOrders(Location location);
    }
}
