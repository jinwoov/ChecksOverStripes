using API.Data;
using API.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Services
{
    public class UserService : IUserManager
    {
        private readonly StoreDbContext _context;

        public UserService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItems>> GetCartItems(string email)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            var cartList = await _context.CartItems.Where(x => x.UserID == user.ID)
                                                   .Include(x => x.Inventory)
                                                   .ToListAsync();
            return cartList;
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
