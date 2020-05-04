using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Interface
{
    public interface IUserManager
    {
        Task<User> CreateUser(User email);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task<List<CartItems>> GetCartItems(string email);
    }
}
