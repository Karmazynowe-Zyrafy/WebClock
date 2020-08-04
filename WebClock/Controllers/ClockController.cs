using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebClock.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ClockController : ControllerBase
    {
        //[Microsoft.AspNetCore.Mvc.Route("[controller]")]
        [HttpGet]
        
        public string GetActualDate()
        {
            string json = JsonConvert.SerializeObject(new
            {
                CurrentDate = new  {date = DateTime.Now.Date}
            });
            return json;

        }
    }
}