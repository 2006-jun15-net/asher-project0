using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    interface ILocationRepository
    {
        Location GetByID(object id);
        IEnumerable<Location> GetAll();
    }
}
