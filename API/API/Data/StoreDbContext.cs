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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(

                new Inventory
                {
                    ID = 1,
                    Name = "Shawn Weatherspoon",
                    Description = "Why so expensive? Who knows..",
                    Size = 11,
                    Brand = Brand.Nike 
                },

                new Inventory
                {
                    ID = 2,
                    Name = "Jordan 1",
                    Description = "My name is Jordan and deez my numbah 1 shoe",
                    Size = 12,
                    Brand = Brand.Jordan
                },

                new Inventory
                {
                    ID = 3,
                    Name = "Jordan 2",
                    Description = "Deez shoe is mah numbah 2, and I ain't no foo",
                    Size = 10,
                    Brand = Brand.Jordan
                }
                );

            modelBuilder.Entity<User>().HasData(

                new User
                {
                    ID = 1,
                    Email = "areyes986@gmail.com"
                },

                new User
                {
                    ID = 2,
                    Email = "jinwoov@gmail.com"
                }
                );

            modelBuilder.Entity<CartItems>().HasData(

                new CartItems
                {
                    ID = 1,
                    UserID = 1,
                    InventoryID = 3,
                    Qty = 2
                },

                new CartItems
                {
                    ID = 2,
                    UserID = 2,
                    InventoryID = 2,
                    Qty = 5
                }

                );

    }

        public DbSet<User> Users { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


    }
}
