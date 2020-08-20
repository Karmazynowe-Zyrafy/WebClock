using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebClock.Controllers.Dtos;
using WebClock.Models;

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

        [HttpGet]
        [Route("Balance/{id}")]
        public BalanceDto Balance(int id)
        {
            var data = _repository.Read(id);
            var dataIn = data.Where(x => x.Type == ClockType.In).ToList();
            var dataOut = data.Where(x => x.Type == ClockType.Out).ToList();

            var totalTime = new TimeSpan();

            foreach (var inItem in dataIn)
            {
                foreach (var outItem in dataOut)
                {
                    totalTime = outItem.Date.TimeOfDay - inItem.Date.TimeOfDay;
                }
            }

            var balanceDto = new BalanceDto
            {
                HoursWorked = Convert.ToInt32(totalTime.TotalHours),
                MinutesWorked = totalTime.Minutes
            };

            return balanceDto;
        }
    }
}