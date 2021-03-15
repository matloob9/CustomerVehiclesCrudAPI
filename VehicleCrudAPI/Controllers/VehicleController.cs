using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCrudAPI.Models;
using VehicleCrudAPI.dContext;

namespace VehicleCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _context;

        public VehicleController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle

        /// <summary>
        /// List all Vehicles by passing Optional Data ( Status & Customer ID )  
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles(bool? status, int? CustomerID)
        {
            var vehicleList = _context.Vehicles.AsQueryable();

            if (status == null && CustomerID == null)
                return await _context.Vehicles.ToListAsync();
            else if (status != null && CustomerID == null)
            {
                vehicleList = _context.Vehicles.Where(v => v.IsConnected == status);
                return await vehicleList.ToListAsync();
            }
            else if (status == null && CustomerID != null)
            {
                vehicleList = _context.Vehicles.Where(v => v.CustomerFk == CustomerID);
                return await vehicleList.ToListAsync();
            }
            else
            {
                vehicleList = _context.Vehicles.Where(v => v.IsConnected == status & v.CustomerFk == CustomerID);
                return await vehicleList.ToListAsync();

            }
        }


        // GET: api/Vehicle/5
        /// <summary>
        /// Get Vehicle by passing Vehicle ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update Vehicle by passing Vehicle ID and Vehicle Data
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add New Vehicle by passing Vehicle Data
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicle/5
        /// <summary>
        /// Delete Vehicle by passing Vehicle ID 
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
