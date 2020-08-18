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

        // POST: api/ClockInOut/ClockOut/5
        [HttpPost]
        [Route("ClockOut/{id}")]
        public void ClockOut(int id)
        {
            var clockInOut = CreateClockOutForId(id);

            _repository.Write(clockInOut);
        }
        //public ListOfClocksDto GetListOfClocks()
        //{
        //    return new ListOfClocksDto();
        //}

        //public class ListOfClocksDto
        //{
        //    public int Number { get; set; }
        //}

        private static ClockInOut CreateClockInForId(int id)
        {
            return new ClockInOut
            {
                UserId = id,
                Type = ClockType.In,
                Date = DateTime.UtcNow
            };
        }

        private static ClockInOut CreateClockOutForId(int id)
        {
            return new ClockInOut
            {
                UserId = id,
                Type = ClockType.Out,
                Date = DateTime.UtcNow
            };
        }
    }
}