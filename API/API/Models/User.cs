using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }

        List<CartItems> cartItems = new List<CartItems>();
    }
}
