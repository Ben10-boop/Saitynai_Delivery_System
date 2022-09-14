using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetPackages()
        {
          if (_context.Packages == null)
          {
              return NotFound();
          }
            return await _context.Packages.ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
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

            return package;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, PackageDto request)
        {
            var oldPackage = await _context.Packages.FindAsync(id);
            if (oldPackage == null) return BadRequest();
            var updatedDeliveryVehicle = await _context.Vehicles.FindAsync(request.DeliveryVehicleId);
            if (updatedDeliveryVehicle == null) return BadRequest();

            if (_context.Packages == null)
            {
                return Problem("Entity set 'DataContext.Packages'  is null.");
            }

            oldPackage.Size = request.Size;
            oldPackage.Weight = request.Weight;
            oldPackage.Address = request.Address;
            oldPackage.DeliveryVehicle = updatedDeliveryVehicle;
            oldPackage.DeliveryVehicleId = updatedDeliveryVehicle.Id;
            oldPackage.State = request.State;
            await _context.SaveChangesAsync();

            return Ok(oldPackage);
        }

        // POST: api/Package
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
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
                Size = request.Size,
                Weight = request.Weight,
                Address = request.Address,
                Recipient = recipient,
                RecipientId = request.RecipientId,
                State = request.State

            };
            _context.Packages.Add(newPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = newPackage.Id }, newPackage);
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
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
