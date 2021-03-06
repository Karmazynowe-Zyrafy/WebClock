﻿using System;
using System.Collections.Generic;
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
        public ActionResult ClockIn(int id)
        {
            var lastRecord = _repository.ReadLast(id);
            if ((lastRecord is null) || lastRecord.Type != ClockType.In)
            {
                var clockInOut = CreateClockInForId(id);
                _repository.Write(clockInOut);
                return Ok(clockInOut.Date);
            }

            return Conflict();
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
        public ActionResult ClockOut(int id)
        {
            var lastRecord = _repository.ReadLast(id);
            if (!(lastRecord is null) && lastRecord.Type != ClockType.Out)
            {
                var clockInOut = CreateClockOutForId(id);
                _repository.Write(clockInOut);
                return Ok(clockInOut.Date);
            }

            return Conflict();
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
            var clockInOutRepository = new ClockInOutRepository(_repository);
            var datesIn = clockInOutRepository.GetClockInsForThisMonth(id).ToList();
            var datesOut = clockInOutRepository.GetClockOutsForThisMonth(id).ToList();


            var lastRecord = _repository.ReadLast(id);
            if (lastRecord?.Type == ClockType.In)
            {
                datesIn.RemoveAt(datesIn.Count - 1);
            }


            return CountBalance.CountWorkTime(datesIn, datesOut);
        }

        [HttpGet]
        [Route("BalanceToThisDay/{id}")]
        public BalanceDto BalanceToThisDay(int id)
        {
            var clockInOutRepository = new ClockInOutRepository(_repository);
            var datesIn = clockInOutRepository.GetClockInsForThisMonth(id).ToList();
            var datesOut = clockInOutRepository.GetClockOutsForThisMonth(id).ToList();
            if(datesIn.Count>datesOut.Count)
            {
                datesIn.RemoveAt(datesIn.Count-1);
            }

            return CountBalance.CountWorkTimeCurrent(datesIn, datesOut);
        }

        [HttpGet]
        [Route("History/{id}")]
        public IEnumerable<ClockInOut> ReadHistoryById(int id)
        {
            var clockInOutRepository = new ClockInOutRepository(_repository);
            var clockInOutHistory = clockInOutRepository.GetClockOutsForAllTimeById(id);
            return clockInOutHistory;
        }

        // GET: api/ClockInOut/LastClockInTime/5
        [HttpGet]
        [Route("LastClockInTime/{id}")]
        public ActionResult LastClockInTime(int id)
        {
            var lastRecord = _repository.ReadLast(id);
            if (lastRecord?.Type == ClockType.In)
            {
                return Ok(lastRecord.Date);
            }
            else
            {
                return Ok();
            }
        }
        // GET: api/ClockInOut/WorkStatus/5
        [HttpGet]
        [Route("WorkStatus/{id}")]
        public ActionResult WorkStatus(int id)
        {
            var lastRecord = _repository.ReadLast(id);
            return Ok(lastRecord.Type);
        }
    }
}