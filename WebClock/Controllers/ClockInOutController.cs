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
    public static class Extensions
    {
        public static Models.ClockInOut ToDb(this ClockInOutController.ClockInOut clockInOut)
        {
            return new Models.ClockInOut { UserId = clockInOut.UserId, Date = clockInOut.Date, Type = clockInOut.Type };
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ClockInOutController : ControllerBase
    {
        private Repository _repository;

        public ClockInOutController(ClockInOutContext context)
        {
            _repository = new Repository(context);
        }

        // POST: api/ClockInOut/ClockIn/5
        [HttpPost]
        [Route("ClockIn/{id}")]
        public void ClockIn(int id)
        {
            var clockInOut = CreateClockInForId(id);

            _repository.Write(clockInOut);
        }
        private static ClockInOutController.ClockInOut CreateClockInForId(int id)
        {
            return new ClockInOutController.ClockInOut
            {
                UserId = id,
                Type = ClockInOutController.ClockType.In,
                Date = DateTime.UtcNow
            };
        }

        public class Repository
        {
            private readonly ClockInOutContext _context;

            public Repository(ClockInOutContext context)
            {
                _context = context;
            }

            public void Write(ClockInOut clockInOut)
            {
                var clockInOutDb = clockInOut.ToDb();
                _context.ClockInOut.Add(clockInOutDb);
                _context.SaveChanges();
            }
        }

        public enum ClockType
        {
            Out = 0,
            In = 1
        };

        public class ClockInOut
        {
            public int UserId { get; set; }
            public ClockType Type { get; set; }
            public DateTime Date { get; set; }
        }
    }
}