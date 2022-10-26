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
    public class DeliveryController : ControllerBase
    {
        private readonly DataContext _context;

        public DeliveryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Delivery
        [HttpGet, Authorize(Roles = "Administrator, Courier")]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDelivery()
        {
          if (_context.Deliveries == null)
          {
              return NotFound();
          }
            return await _context.Deliveries.ToListAsync();
        }

        // GET: api/Delivery/5
        [HttpGet("{id}"), Authorize(Roles = "Administrator, Courier")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
          if (_context.Deliveries == null)
          {
              return NotFound();
          }
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // PUT: api/Delivery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Administrator, Courier")]
        public async Task<IActionResult> PutDelivery(int id, DeliveryDto request)
        {
            var oldDelivery = await _context.Deliveries.FindAsync(id);
            if (oldDelivery == null) return BadRequest("Can't find the Delivery with given ID");

            int userID = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if (User.FindFirstValue(ClaimTypes.Role) == "Courier" && userID != oldDelivery.DeliveryCourierId)
            {
                return BadRequest("You can only edit your own deliveries");
            }

            var updatedDeliveryVehicle = await _context.Vehicles.FindAsync(request.DeliveryVehicleId);
            if (updatedDeliveryVehicle != null) 
            {
                oldDelivery.DeliveryVehicle = updatedDeliveryVehicle;
                oldDelivery.DeliveryVehicleId = updatedDeliveryVehicle.Id;
            }

            var updatedCourier = await _context.Users.FindAsync(request.DeliveryCourierId);
            if (updatedCourier != null && updatedCourier.Role == "Courier")
            {
                oldDelivery.DeliveryCourier = updatedCourier;
                oldDelivery.DeliveryCourierId = updatedCourier.Id;
            }

            if (request.Route != String.Empty) oldDelivery.Route = request.Route;
            if (request.DeliveryDate != null) oldDelivery.DeliveryDate = (DateTime)request.DeliveryDate;
            await _context.SaveChangesAsync();

            return Ok(oldDelivery);
        }

        // POST: api/Delivery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Administrator, Courier")]
        public async Task<ActionResult<Delivery>> PostDelivery(DeliveryDto request)
        {
            if (_context.Deliveries == null)
            {
              return Problem("Entity set 'DataContext.Delivery'  is null.");
            }

            var selectedDeliveryVehicle = await _context.Vehicles.FindAsync(request.DeliveryVehicleId);
            if (selectedDeliveryVehicle == null) return BadRequest("Can't find the Vehicle with given ID");

            var selectedCourier = await _context.Users.FindAsync(request.DeliveryCourierId);
            if (selectedCourier == null || selectedCourier.Role != "Courier") return BadRequest("Can't find the Courier with given ID");

            DateTime newDate = DateTime.Now;
            if (request.DeliveryDate != null)
                newDate = (DateTime)request.DeliveryDate;

            Delivery newDelivery = new()
            {
                Route = request.Route,
                DeliveryDate = newDate,
                DeliveryVehicle = selectedDeliveryVehicle,
                DeliveryVehicleId = request.DeliveryVehicleId,
                DeliveryCourier = selectedCourier,
                DeliveryCourierId = request.DeliveryCourierId
            };
            _context.Deliveries.Add(newDelivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDelivery", new { id = newDelivery.Id }, newDelivery);
        }

        // DELETE: api/Delivery/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            if (_context.Deliveries == null)
            {
                return NotFound();
            }
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            foreach(Package pkg in _context.Packages)
            {
                if (pkg.AssignedToDeliveryId == delivery.Id)
                    return BadRequest("Can't delete this delivery because there are packages assigned to it");
            }

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
