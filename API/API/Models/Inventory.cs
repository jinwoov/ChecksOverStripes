using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public Brand Brand { get; set; }


        public List<CartItems> CartItems = new List<CartItems>();
    }
    
    public enum Brand
    {
        Nike = 0,
        Jordan = 1,
    }
}
