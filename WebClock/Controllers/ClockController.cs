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
            string json = JsonConvert.SerializeObject(new
            {
                CurrentDate = new  {Hour = DateTime.Now.Hour, Minute = DateTime.Now.Minute, Second = DateTime.Now.Second }
            });
            return json;

        }
    }
}