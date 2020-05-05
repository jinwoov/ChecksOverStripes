using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Interface
{
    public interface InventoryManager
    {
        Task<Inventory> GetInventories();
    }
}
