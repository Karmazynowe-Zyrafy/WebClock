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
        private readonly ClockInOutRepository _clockInOutRepository;

        public ClockInOutController(IRepository repository)
        {
            _repository = repository;
            _clockInOutRepository = new ClockInOutRepository(_repository);
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

        // POST: api/ClockInOut/ClockOut/5
        [HttpPost]
        [Route("ClockOut/{id}")]
        public void ClockOut(int id)
        {
            var clockInOut = CreateClockOutForId(id);

            _repository.Write(clockInOut);
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

        [HttpGet]
        [Route("Balance/{id}")]
        public BalanceDto Balance(int id)
        {
            var datesIn = _clockInOutRepository.GetClockInsForThisMonth(id).ToList();
            var datesOut = _clockInOutRepository.GetClockOutsForThisMonth(id).ToList();

            return CountBalance.CountWorkTime(datesIn, datesOut);
        }
        [HttpGet]
        [Route("BalanceToThisDay/{id}")]
        public BalanceDto BalanceToThisDay(int id)
        {
            var datesIn = _clockInOutRepository.GetClockInsForThisMonth(id).ToList();
            var datesOut = _clockInOutRepository.GetClockOutsForThisMonth(id).ToList();

            return CountBalance.CountWorkTimeCurrent(datesIn, datesOut);
        }
    }
}