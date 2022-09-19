using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saitynai_Delivery_System1.Data;
using System.Security.Cryptography;

namespace Saitynai_Delivery_System1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }
        /*
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hma
            }
        }*/
    }
}
