﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ClockInOutDatabasesController : ControllerBase
    {
        private readonly ClockinoutContext _context;

        public ClockInOutDatabasesController(ClockinoutContext context)
        {
            _context = context;
        }

        // GET: api/ClockInOutDatabases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClockInOutDatabase>>> GetclockInOut()
        {
            return await _context.clockInOut.ToListAsync();
        }

        // GET: api/ClockInOutDatabases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClockInOutDatabase>>> GetClockInOutDatabase(int id)
        {
            var clockInOutDatabase = await _context.clockInOut.Where(x => x.UserId == id).ToListAsync();

            if (clockInOutDatabase == null)
            {
                return NotFound();
            }

            return clockInOutDatabase;
        }

        // PUT: api/ClockInOutDatabases/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClockInOutDatabase(int id, ClockInOutDatabase clockInOutDatabase)
        {
            if (id != clockInOutDatabase.Clockinout_Id)
            {
                return BadRequest();
            }

            _context.Entry(clockInOutDatabase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClockInOutDatabaseExists(id))
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

        // POST: api/ClockInOutDatabases/ClockIn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/ClockInOutDatabases/ClockIn/{id}")]
        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase_ClockIn(int id)
        {
            ClockInOutDatabase clockInOutDatabase = new ClockInOutDatabase { UserId = id,ClockoutTime=DateTime.UtcNow,IsClockedIn=true, IsDeleted = false };// database freaks out if you post with only one variable in it
            _context.clockInOut.Add(clockInOutDatabase);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClockInOutDatabase", new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        }
        // POST: api/ClockInOutDatabases/ClockOut/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/ClockInOutDatabases/ClockOut/{id}")]
        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase_ClockOut(int id)
        {
            ClockInOutDatabase clockInOutDatabase = new ClockInOutDatabase { UserId = id, ClockoutTime = DateTime.UtcNow, IsClockedIn = false, IsDeleted = false };// database freaks out if you post with only one variable in it
            _context.clockInOut.Add(clockInOutDatabase);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClockInOutDatabase", new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        }

        // POST: api/ClockInOutDatabases/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClockInOutDatabase>> PostClockInOutDatabase(ClockInOutDatabase clockInOutDatabase)
        {
            _context.clockInOut.Add(clockInOutDatabase);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClockInOutDatabase", new { id = clockInOutDatabase.Clockinout_Id }, clockInOutDatabase);
        }

        // DELETE: api/ClockInOutDatabases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClockInOutDatabase>> DeleteClockInOutDatabase(int id)
        {
            var clockInOutDatabase = await _context.clockInOut.FindAsync(id);
            if (clockInOutDatabase == null)
            {
                return NotFound();
            }
            clockInOutDatabase.IsDeleted = true;
            _context.Entry(clockInOutDatabase).State = EntityState.Modified;

            //_context.clockInOut.Remove(clockInOutDatabase);
            await _context.SaveChangesAsync();

            return clockInOutDatabase;
        }

        private bool ClockInOutDatabaseExists(int id)
        {
            return _context.clockInOut.Any(e => e.Clockinout_Id == id);
        }
    }
}
