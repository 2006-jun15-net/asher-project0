using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Testing
{
    public class CustomerTest
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        readonly CustomerRepository repository = new CustomerRepository(context);

        [Theory]
        [InlineData("Asher", "Williams", "Trasher571", 1)]
        [InlineData("Christian", "Roberts", "EpicConsole123", 3)]
        [InlineData("Luke", "Skywalker", "R3b3lJedi420", 5)]
        public void Finds_Correct_Customer_By_Name(string FirstName, string LastName, string UserName, int ID)
        {
            var customer = repository.findCustomer(FirstName, LastName, UserName);
            Assert.Equal(ID.ToString(), customer.CustomerId.ToString());
        }
    }
}
