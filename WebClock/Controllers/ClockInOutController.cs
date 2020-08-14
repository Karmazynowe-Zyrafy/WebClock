using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebClock.Models;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClockInOutController : ControllerBase
    {
        private readonly ClockinoutContext _context;

        public ClockInOutController(ClockinoutContext context)
        {
            _context = context;
        }

        // GET: api/ClocksInOut
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClockInOutDatabase>>> GetClocksInOut()
        {
            return await _context.ClockInOut.ToListAsync();
        }

        //        // GET: api/ClockInOut/5
        //        [HttpGet("{id}")]
        //  
        //        public async Task<ActionResult<IEnumerable<ClockInOutDatabase>>> GetClockInOutById(int id)
        //        {
        //            var clockInOutDatabase = await _context.clockInOut.Where(x => x.Clockinout_Id == id).ToListAsync();
        //
        //            if (!clockInOutDatabase.Any())
        //            {
        //                return NotFound();
        //            }
        //
        //            return clockInOutDatabase;
        //        }

        //        // PUT: api/ClockInOut/5
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> UpdateClockInOutById(int id, ClockInOutDatabase clockInOut)
        //        {
        //            if (id != clockInOut.Clockinout_Id)
        //            {
        //                return BadRequest();
        //            }
        //
        //            _context.Entry(clockInOut).State = EntityState.Modified;
        //
        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            { 
        //                return StatusCode(StatusCodes.Status500InternalServerError,
        //                    "Error updating data in the database");
        //
        //            }
        //        
        //            return Ok();
        //        }

        // POST: api/ClockInOut/ClockIn/5
        [HttpPost]
        [Route("ClockIn/{id}")]
        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase_ClockIn(int id)
        {


            ClockInOutDatabase clockInOutDatabase =
                new ClockInOutDatabase
                {
                    UserId = id,
                    ClockoutTime = DateTime.UtcNow,
                    IsClockedIn = true,
                    IsDeleted = false
                };
            // database freaks out if you post with only one variable in it

            _context.ClockInOut.Add(clockInOutDatabase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClocksInOut",
                new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        }

        enum ClockType { In, Out };

        class ClockInOut
        {
            public int UserId { get; set; }
            public ClockType Type { get; set; }
            public DateTime Date { get; set; }
        }

        // POST: api/ClockInOutDatabases/ClockOut/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/ClockInOutDatabases/ClockOut/{id}")]
        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase_ClockOut(int id)
        {
            ClockInOutDatabase clockInOutDatabase =
                new ClockInOutDatabase
                {
                    UserId = id,
                    ClockoutTime = DateTime.UtcNow,
                    IsClockedIn = false,
                    IsDeleted = false
                };// database freaks out if you post with only one variable in it
            _context.ClockInOut.Add(clockInOutDatabase);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClocksInOut", new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        }

        //        // POST: api/ClockInOutDatabases/
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //        [HttpPost]
        //        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase(ClockInOutDatabase clockInOutDatabase)
        //        {
        //            _context.clockInOut.Add(clockInOutDatabase);
        //            await _context.SaveChangesAsync();
        //            return CreatedAtAction("GetClocksInOut", new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        //        }

        // DELETE: api/ClockInOutDatabases/5
        //        [HttpDelete("{id}")]
        //        public async Task<ActionResult<ClockInOutDatabase>> DeleteClockInOutDatabase(int id)
        //        {
        //            var clockInOutDatabase = await _context.clockInOut.FindAsync(id);
        //            if (clockInOutDatabase == null)
        //            {
        //                return NotFound();
        //            }
        //            clockInOutDatabase.IsDeleted = true;
        //            _context.Entry(clockInOutDatabase).State = EntityState.Modified;
        //
        //            //_context.clockInOut.Remove(clockInOutDatabase);
        //            await _context.SaveChangesAsync();
        //
        //            return clockInOutDatabase;
        //        }
        //        private bool ClockInOutDatabaseExists(int id)
        //        {
        //            return _context.clockInOut.Any(e => e.Clockinout_Id == id);
        //        }
    }
}
