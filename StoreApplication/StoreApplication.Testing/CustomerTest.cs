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

        [Theory]
        [InlineData("Asher", "Williams", "Trasher571", 1)]
        [InlineData("Christian", "Roberts", "EpicConsole123", 3)]
        [InlineData("Luke", "Skywalker", "R3b3lJedi420", 5)]
        public void Finds_Correct_Customer_By_Name(string FirstName, string LastName, string UserName, int ID)
        {
            CustomerRepository repository = new CustomerRepository(context);
            var customer = repository.findCustomer(FirstName, LastName, UserName);

            Assert.Equal(ID.ToString(), customer.CustomerId.ToString());
        }

        [Theory]
        [InlineData("Asher", "Williams", "Traser571")]
        [InlineData("Mellie", "Roberts", "EpicConsole123")]
        [InlineData("Robert", "Skye", "R3b3lJedi420")]
        public void Returns_Null_If_No_Customer_Found(string FirstName, string LastName, string UserName)
        {
            CustomerRepository repository = new CustomerRepository(context);
            var customer = repository.findCustomer(FirstName, LastName, UserName);

            Assert.Null(customer);
        }

        [Fact]
        public void Finds_Matching_Username()
        {
            Customer customer = new Customer();
            CustomerRepository customerRepository = new CustomerRepository();
            customer.UserName = "Trasher571";

            Assert.True(customerRepository.DoesUsernameExist(customer));
        }

        [Fact]
        public void Doesnt_Find_Customer()
        {
            Customer customer = new Customer();
            CustomerRepository customerRepository = new CustomerRepository();
            customer.UserName = "BillyBat123";

            Assert.False(customerRepository.DoesUsernameExist(customer));
        }
    }
}
