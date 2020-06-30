using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class InventoryRepository : IInventoryRepository
    {
        private Project0StoreContext context = null;
        private DbSet<Inventory> table = null;

        public InventoryRepository()
        {
            context = new Project0StoreContext();
            table = context.Set<Inventory>();
        }
        public InventoryRepository(Project0StoreContext context)
        {
            this.context = context;
            table = this.context.Set<Inventory>();
        }

        public Inventory FindLocationInventory(Location location, Product product)
        {
            return context.Inventory.Where(i => (i.Location == location) && (i.Product == product)).FirstOrDefault();
        }

        public void Update(Inventory obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
