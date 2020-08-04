using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController : ControllerBase
    {
        [HttpGet]
        public string GetCurrentTime()
        {
            var currentTime = DateTime.Now;
            var clock = new Clock
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