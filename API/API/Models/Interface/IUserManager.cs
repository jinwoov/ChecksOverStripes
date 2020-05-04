using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Interface
{
    public interface IUserManager
    {
        Task CreateUser(string email);
        Task<User> GetUser(string email);
        Task DeleteUser(int id);
        Task<List<CartItems>> GetCartItems(string email);
    }
}
