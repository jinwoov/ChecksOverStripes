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
using API.Models.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryManager _inventoryManager;

        public InventoryController(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetInventory() => await _inventoryManager.GetAllTheShoes();

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDTO>> GetInventory(int id)
        {
            var inventory = await _inventoryManager.GetInventoryByID(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, InventoryDTO inventory)
        {
            if (id != inventory.ID)
            {
                return BadRequest();
            }

            try
            {
                await _inventoryManager.UpdateInventory(inventory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_inventoryManager.GetInventoryByID(id) == null)
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        // POST: api/Inventories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(InventoryDTO inventory)
        {
            var product = await _inventoryManager.CreateShoes(inventory);

            return CreatedAtAction("GetInventory", new { id = product.ID }, product);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryDTO>> DeleteInventory(int id)
        {
            var inventory = await _inventoryManager.GetInventoryByID(id);
            if (inventory == null)
            {
                return NotFound();
            }

            await _inventoryManager.DeleteInventory(id);

            return inventory;
        }

    }
}
