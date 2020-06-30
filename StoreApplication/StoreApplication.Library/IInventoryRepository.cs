using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    interface IInventoryRepository
    {
        void Update(Inventory obj);
        Inventory FindLocationInventory(Location location, Product product);
    }
}
