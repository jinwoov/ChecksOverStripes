using API.Data;
using API.Models.DTOs;
using API.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Services
{
    public class InventoryService : InventoryManager
    {
        private readonly StoreDbContext _context;

        public InventoryService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateShoes(InventoryDTO inventory)
        {
            Inventory invent = new Inventory()
            {
                Brand = Enum.Parse<Brand>(inventory.Brand),
                Name = inventory.Name,
                Description = inventory.Description,
                Size = inventory.Size
            };

            _context.Inventory.Add(invent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventory(int ID)
        {
            var product = await _context.Inventory.FindAsync(ID);
            _context.Inventory.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InventoryDTO>> GetAllTheShoes()
        {
            var productList = await _context.Inventory.ToListAsync();
            List<InventoryDTO> ListIDTO = new List<InventoryDTO>();
            foreach (var product in productList)
            {
                var iDTO = ConvertToDTO(product);
                ListIDTO.Add(iDTO);
            }
            return ListIDTO;
        }

        public async Task<InventoryDTO> GetInventoryByID(int ID)
        {
            var product = await _context.Inventory.FindAsync(ID);
            var pDTO = ConvertToDTO(product);

            return pDTO;
        }

        public Task UpdateInventory(InventoryDTO inventory)
        {
            throw new NotImplementedException();
        }

        private InventoryDTO ConvertToDTO(Inventory inventory)
        {
            InventoryDTO iDTO = new InventoryDTO()
            {
                ID = inventory.ID,
                Name = inventory.Name,
                Brand = inventory.Brand.ToString(),
                Description = inventory.Description,
                Size = inventory.Size
            };
            return iDTO;
        }
    }
}
