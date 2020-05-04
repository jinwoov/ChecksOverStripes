using API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Interface
{
    public interface InventoryManager
    {
        //C
        Task<InventoryDTO> CreateShoes(InventoryDTO inventory);

        //R
        Task<InventoryDTO> GetInventoryByID(int ID);

        //RA
        Task<List<InventoryDTO>> GetAllTheShoes();

        //U
        Task<InventoryDTO> UpdateInventory(InventoryDTO inventory);

        //U
        Task DeleteInventory(int ID);
    }
}
