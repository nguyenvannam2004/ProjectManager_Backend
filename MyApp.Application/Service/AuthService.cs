using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.Interface;
using MyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace MyApp.Application.Service
{
    public class AuthService 
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task Register(string username, string password)
        {
            if (await _repo.IsUsernameExists(username))
                throw new Exception("Username already exists");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                RoleId = 3 // default STAFF
            };

            await _repo.AddUser(user);
            await _repo.SaveChanges();
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _repo.GetUserByUsername(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new Exception("Invalid username or password");

            var roleName = user.Role?.Name;
            return GenerateJwtToken(user.Username, roleName);
        }

        private string GenerateJwtToken(string username, string roleName)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, roleName.ToUpper())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task UpdateRole(int userId, int roleId)
        {
            var user = await _repo.GetUserById(userId);
            if (user == null) throw new Exception("User not found");
            if (!await _repo.IsRoleExists(roleId)) throw new Exception("Invalid role");

            user.RoleId = roleId;
            await _repo.SaveChanges();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _repo.GetAllUsersAsync();
            return users.Select(u => new UserModel
            {
                Id = u.Id,
                Username = u.Username,
                RoleName = u.Role?.Name ?? "STAFF",
            }).ToList();
        }
    }
}
