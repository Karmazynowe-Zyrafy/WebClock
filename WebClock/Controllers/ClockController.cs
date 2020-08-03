using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController: ControllerBase
    {
        
        [HttpGet]
        public DateTime Get()
        {
            return DateTime.Now;
        }
        
        
    }
}