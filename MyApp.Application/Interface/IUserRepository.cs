using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface
{
    public interface IUserRepository 
    {
        Task<bool> IsUsernameExists(string username);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task SaveChanges();
        Task<bool> IsRoleExists(int roleId);
        Task<List<User>> GetAllUsersAsync();
    }
}
