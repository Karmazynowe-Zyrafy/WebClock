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
            var now = DateTime.Now;
            var json = JsonConvert.SerializeObject(new
            {
                CurrentDate = new Clock() {
                    Hour = now.Hour, 
                    Minute = now.Minute,
                    Second = now.Second 
                }
            });
            return json;

        }
    }
}