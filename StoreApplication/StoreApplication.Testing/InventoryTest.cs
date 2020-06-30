using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using StoreApplication.Library;
using System.Text;
using Xunit;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace StoreApplication.Testing
{
    public class InventoryTest
    {
        public static readonly DbContextOptions<Project0StoreContext> Options = new DbContextOptionsBuilder<Project0StoreContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;
        public static Project0StoreContext context = new Project0StoreContext(Options);

        [Theory]
        [InlineData(1, 5)]
        [InlineData(1, 9)]
        [InlineData(3, 2)]
        [InlineData(2, 7)]
        public void Get_Correct_Inventory(int locationID, int productID)
        {
            GenericRepository<Location> locationRepo = new GenericRepository<Location>(context);
            GenericRepository<Product> productRepo = new GenericRepository<Product>();
            Location location = locationRepo.GetById(locationID);
            Product product = productRepo.GetById(productID);
            InventoryRepository inventoryRepo = new InventoryRepository(context);

            Inventory inventory = inventoryRepo.FindLocationInventory(location, product);

            Assert.True((inventory.LocationId == location.LocationId) && (inventory.ProductId == product.ProductId));
        }

        [Theory]
        [InlineData(1, 15)]
        [InlineData(5, 9)]
        [InlineData(6, 20)]
        public void Returns_Null_If_No_Inventory_Found(int locationID, int productID)
        {
            GenericRepository<Location> locationRepo = new GenericRepository<Location>(context);
            GenericRepository<Product> productRepo = new GenericRepository<Product>();
            Location location = locationRepo.GetById(locationID);
            Product product = productRepo.GetById(productID);
            InventoryRepository inventoryRepo = new InventoryRepository(context);

            Inventory inventory = inventoryRepo.FindLocationInventory(location, product);

            Assert.Null(inventory);
        }
    }
}
