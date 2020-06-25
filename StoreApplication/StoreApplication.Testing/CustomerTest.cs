using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Testing
{
    public class CustomerTest
    {
        readonly Customer customer = new Customer();
        [Fact]
        public void FirstName_EmptyValue_ThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.firstName = string.Empty);
        }
    }
}
