using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int InventoryID { get; set; }
        public int Qty { get; set; }

        public User User { get; set; }
        public Inventory Inventory { get; set; }
    }
}
