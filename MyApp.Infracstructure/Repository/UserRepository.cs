using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interface;
using MyApp.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infracstructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task<bool> IsUsernameExists(string username) =>
            await _db.Users.AnyAsync(u => u.Username == username);

        public async Task<User> GetUserByUsername(string username) =>
            await _db.Users.Include(u => u.Role)
                           .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User> GetUserById(int id) =>
            await _db.Users.FindAsync(id);

        public async Task AddUser(User user) => await _db.Users.AddAsync(user);

        public async Task SaveChanges() => await _db.SaveChangesAsync();

        public async Task<bool> IsRoleExists(int roleId) =>
            await _db.Roles.AnyAsync(r => r.Id == roleId);

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
