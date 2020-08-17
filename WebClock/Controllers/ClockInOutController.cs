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
   

    [ApiController]
    [Route("api/[controller]")]
    public partial class ClockInOutController : ControllerBase
    {
        private EfRepository _efRepository;

        public ClockInOutController(EfRepository efRepository)
        {
            _efRepository = efRepository;
        }

        // POST: api/ClockInOut/ClockIn/5
        [HttpPost]
        [Route("ClockIn/{id}")]
        public void ClockIn(int id)
        {
            var clockInOut = CreateClockInForId(id);

            _efRepository.Write(clockInOut);
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