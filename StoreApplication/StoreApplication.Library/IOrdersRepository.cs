using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    interface IOrdersRepository
    {
        IEnumerable<Orders> GetAllOrdersInHistory();
        double CalculateTotal(Product product, Orders orders);
    }
}
