using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebClock.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ClockController : ControllerBase
    {
        [HttpGet]
        public string GetCurrentDate()
        {

            var CurrentTiem = DateTime.Now;
            Clock clock = new Clock()
            {
                Hour = DateTime.Now.Hour,
                Minute = DateTime.Now.Minute,
                Second = DateTime.Now.Second
            };


            string json = JsonConvert.SerializeObject(clock);
            return json;

        }
    }
}