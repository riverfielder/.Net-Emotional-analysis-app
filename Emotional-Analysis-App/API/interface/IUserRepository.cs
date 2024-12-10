using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(string username, string password, string repeatpassword);
        Task<User> LoginUserAsync(string username, string password);
        int GetUserIdByUsername(string username);
    }
}
