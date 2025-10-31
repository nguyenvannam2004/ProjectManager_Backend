//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using MyApp.Infracstructure.Data;
//using ProjectManager_Backend.Model;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace ProjectManager_Backend.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly AppDbContext _db;
//        private readonly IConfiguration _config;

//        public AuthController(AppDbContext db, IConfiguration config)
//        {
//            _db = db;
//            _config = config;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
//        {
//            if (await _db.Users.AnyAsync(u => u.Username == request.Username))
//                return BadRequest("Username already exists.");

//            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

//            var user = new User
//            {
//                Username = request.Username,
//                PasswordHash = hashedPassword,
//                RoleId = 3 
//            };

//            _db.Users.Add(user);
//            await _db.SaveChangesAsync();

//            return Ok(new { message = "User registered successfully" });
//        }

//        [HttpPut("update-role/{userId}")]
//        [Authorize(Roles = "ADMIN")]
//        public async Task<IActionResult> UpdateUserRole(int userId, [FromBody] UpdateRoleRequest request)
//        {
//            var user = await _db.Users.FindAsync(userId);
//            if (user == null)
//                return NotFound("User not found");

//            // Kiểm tra role hợp lệ
//            if (!await _db.Roles.AnyAsync(r => r.Id == request.RoleId))
//                return BadRequest("Invalid role ID");

//            user.RoleId = request.RoleId;
//            await _db.SaveChangesAsync();

//            return Ok(new { message = "User role updated successfully" });
//        }


//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginRequest request)
//        {
//            var user = _db.Users
//                .Include(u => u.Role)
//                .FirstOrDefault(u => u.Username == request.Username);
//            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//                return Unauthorized("Tên đăng nhập hoặc mật khẩu không đúng");

//            var roleName = user.Role?.Name ?? "EMPLOYEE";
//            var token = GenerateJwtToken(user.Username, roleName);
//            return Ok(new { token });
//        }

//        private string GenerateJwtToken(string username, string roleName)
//        {
//            var claims = new[]
//            {
//            new Claim(ClaimTypes.Name, username),
//            new Claim(ClaimTypes.Role, roleName.ToUpper())
//        };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                claims: claims,
//                expires: DateTime.Now.AddHours(5),
//                signingCredentials: creds);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }

//    public class LoginRequest
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }
//}





////  refactor lại theo kiến trúc clean architecture

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service;
using ProjectManager_Backend.Model;
using System.Threading.Tasks;

namespace ProjectManager_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _authService.Register(request.Username, request.Password);
                return Ok(new { message = "User registered successfully" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _authService.Login(request.Username, request.Password);
                return Ok(new { token });
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("users")]
        //[Authorize(Roles = "ADMIN")] // Chỉ admin mới xem danh sách user
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _authService.GetAllUsers();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update-role/{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateUserRole(int userId, [FromBody] UpdateRoleRequest request)
        {
            try
            {
                await _authService.UpdateRole(userId, request.RoleId);
                return Ok(new { message = "User role updated successfully" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
