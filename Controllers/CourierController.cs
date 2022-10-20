using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saitynai_Delivery_System1.Data;
using Saitynai_Delivery_System1.DTOs;
using Saitynai_Delivery_System1.Models;

namespace Saitynai_Delivery_System1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly DataContext _context;

        public CourierController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Courier
        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<User>>> GetCouriers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.Where(user => user.Role == "Courier").ToListAsync();
        }

        // GET: api/Courier/5
        [HttpGet("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<User>> GetCourier(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null || user.Role != "Courier")
            {
                return NotFound();
            }

            return user;
        }
        /*
        // PUT: api/Courier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourier(int id, CourierDto request)
        {
            var oldCourier = await _context.Users.FindAsync(id);
            if (oldCourier == null || oldCourier.Role != "Courier") return BadRequest();

            oldCourier.Email = request.Email;
            oldCourier.Phone = request.Phone;
            oldCourier.Wage = request.Wage;
            await _context.SaveChangesAsync();

            return Ok(oldCourier);
        }*/

        // POST: api/Courier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<User>> PostCourier(CourierDto request)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'DataContext.Users'  is null.");
          }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newCourier = new()
            {
                Email = request.Email,
                Role = "Courier",
                Status = "Active",
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Phone = request.Phone,
                Wage = request.Wage
            };
            _context.Users.Add(newCourier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourier", new { id = newCourier.Id }, newCourier);
        }

        // DELETE: api/Courier/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourier(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.Role != "Courier")
            {
                return NotFound();
            }

            user.Status = "Deleted";
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
