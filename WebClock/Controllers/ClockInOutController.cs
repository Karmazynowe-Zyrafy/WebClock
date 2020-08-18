using System;
using Microsoft.AspNetCore.Mvc;
using WebClock.Models;
using WebClock.Models.MemoryRepository;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClockInOutController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClockInOutController(IRepository repository)
        {
            _repository = repository;
        }

        // POST: api/ClockInOut/ClockIn/5
        [HttpPost]
        [Route("ClockIn/{id}")]
        public void ClockIn(int id)
        {
            var clockInOut = CreateClockInForId(id);

            _repository.Write(clockInOut);

        }
        private static ClockInOut CreateClockInForId(int id)
        {
            return new ClockInOut
            {
                UserId = id,
                Type = ClockType.In,
                Date = DateTime.UtcNow
            };
        }


       
    }
}