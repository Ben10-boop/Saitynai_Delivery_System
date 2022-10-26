using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
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
    public class PackageController : ControllerBase
    {
        private readonly DataContext _context;

        public PackageController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Package
        [HttpGet, Authorize(Roles = "Administrator, Courier")]
        public async Task<ActionResult<List<Package>>> GetPackages()
        {
          if (_context.Packages == null)
          {
              return NotFound();
          }
            return await _context.Packages.ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            if (_context.Packages == null)
            {
                return NotFound();
            }
            var package = await _context.Packages.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            int userID = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if(User.FindFirstValue(ClaimTypes.Role) == "Client" && userID != package.RecipientId)
            {
                return BadRequest("You can only view your own packages");
            }

            return package;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Administrator, Courier")]
        public async Task<IActionResult> PutPackage(int id, PackageDto request)
        {
            var oldPackage = await _context.Packages.FindAsync(id);
            if (oldPackage == null) return BadRequest("Couldn't find Package with given ID");

            int userID = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            var oldPackageDelivery = await _context.Deliveries.FindAsync(oldPackage.AssignedToDeliveryId);
            if (User.FindFirstValue(ClaimTypes.Role) == "Courier" &&
                oldPackageDelivery != null &&
                oldPackageDelivery.DeliveryCourierId != userID)
            {
                return BadRequest("This package has already been taken by another courier");
            }

            var updatedDelivery = await _context.Deliveries.FindAsync(request.AssignedToDeliveryId);
            if (updatedDelivery != null)
            {
                oldPackage.AssignedToDelivery = updatedDelivery;
                oldPackage.AssignedToDeliveryId = updatedDelivery.Id;
            }

            if (request.Size != String.Empty) oldPackage.Size = request.Size;
            if (request.Weight != 0) oldPackage.Weight = request.Weight;
            if (request.Address != String.Empty) oldPackage.Address = request.Address;
            if (request.State != String.Empty) oldPackage.State = request.State;
            await _context.SaveChangesAsync();

            return Ok(oldPackage);
        }

        // POST: api/Package
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Package>> PostPackage(PackageDto request)
        {
            var recipient = await _context.Users.FindAsync(request.RecipientId);
            if (recipient == null) return BadRequest();

            if (_context.Packages == null)
            {
                return Problem("Entity set 'DataContext.Packages'  is null.");
            }
            Package newPackage = new Package
            {
                Size = request.Size.ToLower(),
                Weight = request.Weight,
                Address = request.Address,
                Recipient = recipient,
                RecipientId = request.RecipientId,
                State = request.State.ToLower()

            };
            _context.Packages.Add(newPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = newPackage.Id }, newPackage);
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Packages == null)
            {
                return NotFound();
            }
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
