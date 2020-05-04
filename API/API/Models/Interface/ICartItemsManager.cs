using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Interface
{
    public interface ICartItemsManager
    {
        //C
        Task CreateCartItem(CartItems cartItems);

        //R
        Task<CartItems> GetCartItemsByID(int ID);

        //RA
        Task<List<CartItems>> GetAllTheCart();

        //U
        Task UpdateCartItem(CartItems cartItems);

        //U
        Task DeleteCartItem(int ID);
    }

}
