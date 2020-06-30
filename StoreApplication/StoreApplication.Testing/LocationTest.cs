using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Testing
{
    public class LocationTest
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Get_Correct_Location(int id)
        {
            LocationRepository locationRepo = new LocationRepository(context);

            Location location = locationRepo.GetByID(id);

            Assert.True(location.LocationId == id);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(9)]
        [InlineData(21)]
        public void Returns_Null_If_Location_Not_Found(int id)
        {
            LocationRepository locationRepo = new LocationRepository(context);

            Location location = locationRepo.GetByID(id);

            Assert.Null(location);
        }
    }
}
