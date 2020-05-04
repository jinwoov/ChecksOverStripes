using API.Data;
using API.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Services
{
    public class CartItemService : ICartItemsManager
    {
        private readonly StoreDbContext _context;

        public CartItemService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<CartItems> CreateCartItem(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();
            return cartItems;
        }

        public async Task DeleteCartItem(int ID)
        {
            var cart = await _context.CartItems.FindAsync(ID);
            _context.CartItems.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItems>> GetAllTheCart() => await _context.CartItems.ToListAsync();

        public async Task<CartItems> GetCartItemsByID(int ID) => await _context.CartItems.FindAsync(ID);

        public async Task UpdateCartItem(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}
