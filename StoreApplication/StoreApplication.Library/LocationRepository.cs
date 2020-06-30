using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class LocationRepository : ILocationRepository
    {
        private Project0StoreContext context = null;
        private DbSet<Location> table = null;

        public LocationRepository()
        {
            context = new Project0StoreContext();
            table = context.Set<Location>();
        }
        public LocationRepository(Project0StoreContext context)
        {
            this.context = context;
            table = this.context.Set<Location>();
        }

        public IEnumerable<Location> GetAll()
        {
            return table.ToList();
        }

        public Location GetByID(object id)
        {
            return table.Find(id);
        }
    }
}
