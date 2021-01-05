using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using System.Security.Cryptography;


namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password) 
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }
        
    }
}