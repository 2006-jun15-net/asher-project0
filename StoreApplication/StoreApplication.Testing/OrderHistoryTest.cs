using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Testing
{
    public class OrderHistoryTest
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        [Theory]
        [InlineData(1, 4)]
        [InlineData(1, 3)]
        public void Get_Correct_Customer(int customerID, int orderHistoryID)
        {
            OrderHistoryRepository orderHistoryRepo = new OrderHistoryRepository(context);
            OrderHistory orderHistory = orderHistoryRepo.GetById(orderHistoryID);

            OrderHistory orderHistory1 = orderHistoryRepo.getCustomerRef(orderHistory);
            Customer customer = orderHistory1.Customer;

            Assert.True(customer.CustomerId == customerID);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 3)]
        public void Get_Correct_Location(int locationID, int orderHistoryID)
        {
            OrderHistoryRepository orderHistoryRepo = new OrderHistoryRepository(context);
            OrderHistory orderHistory = orderHistoryRepo.GetById(orderHistoryID);

            OrderHistory orderHistory1 = orderHistoryRepo.getLocationRef(orderHistory);
            Location location = orderHistory1.Location;

            Assert.True(location.LocationId == locationID);
        }
    }
}
