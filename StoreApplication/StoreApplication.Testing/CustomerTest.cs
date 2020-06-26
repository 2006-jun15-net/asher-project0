using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Testing
{
    public class CustomerTest
    {
        readonly StoreCustomer customer = new StoreCustomer();

        [Fact]
        public void FirstName_EmptyValue_ThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.firstName = string.Empty);
        }

        [Fact]
        public void FirstName_NullValue_ThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.firstName = null);
        }
    }
}
