using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


    }
}
