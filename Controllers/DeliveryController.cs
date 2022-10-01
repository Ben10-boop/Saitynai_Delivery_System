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
    public class DeliveryController : ControllerBase
    {
        private readonly DataContext _context;

        public DeliveryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDelivery()
        {
          if (_context.Deliveries == null)
          {
              return NotFound();
          }
            return await _context.Deliveries.ToListAsync();
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, DeliveryDto request)
        {
            var oldDelivery = await _context.Deliveries.FindAsync(id);
            if (oldDelivery == null) return BadRequest("Can't find the Delivery with given ID");
            
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
        [HttpPost]
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
        [HttpDelete("{id}")]
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

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
