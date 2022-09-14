﻿using System;
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
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _context;

        public VehicleController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
          if (_context.Vehicles == null)
          {
              return NotFound();
          }
            return await _context.Vehicles.ToListAsync();
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
          if (_context.Vehicles == null)
          {
              return NotFound();
          }
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleDto request)
        {
            var oldVehicle = await _context.Vehicles.FindAsync(id);
            if (oldVehicle == null) return BadRequest();
            var updatedDriver = await _context.Users.FindAsync(request.DriverId);
            if (updatedDriver == null) return BadRequest();

            oldVehicle.RegNumbers = request.RegNumbers;
            oldVehicle.Brand = request.Brand;
            oldVehicle.Model = request.Model;
            oldVehicle.MaxPayload = request.MaxPayload;
            oldVehicle.Driver = updatedDriver;
            oldVehicle.DriverId = updatedDriver.Id;

            await _context.SaveChangesAsync();

            return Ok(oldVehicle);
        }

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDto request)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'DataContext.Vehicles'  is null.");
            }
            Vehicle newVehicle = new()
            {
                RegNumbers = request.RegNumbers,
                Brand = request.Brand,
                Model = request.Model,
                MaxPayload = request.MaxPayload
            };
            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = newVehicle.Id }, newVehicle);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}