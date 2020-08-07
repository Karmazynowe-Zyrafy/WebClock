using System;
using System.Threading.Tasks;
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
                Hour = currentTime.Hour,
                Minute = currentTime.Minute,
                Second = currentTime.Second
            };
            string json = JsonConvert.SerializeObject(clock);
            return json;
        }

        [HttpPost]
        public async Task<ActionResult>  ClockInOutRegistration(Object id)
        {
           return Ok();
        }
    }
}