using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Models.Interface;

namespace API.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsManager _cartManager;

        public CartItemsController(ICartItemsManager cartManager)
        {
            _cartManager = cartManager;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItems>>> GetCartItems() => await _cartManager.GetAllTheCart();

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItems>> GetCartItems(int id)
        {
            var cartItems = await _cartManager.GetCartItemsByID(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            return cartItems;
        }

        // PUT: api/Cart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItems(int id, CartItems cartItems)
        {
            if (id != cartItems.ID)
            {
                return BadRequest();
            }

            try
            {
                await _cartManager.UpdateCartItem(cartItems);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _cartManager.GetCartItemsByID(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost, Route("{userID}/{inventoryID}/{quantity}")]
        public async Task<ActionResult<CartItems>> PostCartItems(int inventoryID, int userID, int quantity)
        {
            CartItems cart = new CartItems
            {
                InventoryID = inventoryID,
                UserID = userID,
                Qty = quantity
            };

            CartItems createCart = await _cartManager.CreateCartItem(cart);

            return CreatedAtAction("GetCartItems", new { id = createCart.ID }, createCart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task DeleteCartItems(int id) => await _cartManager.DeleteCartItem(id);

    }
}
