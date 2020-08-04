using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController : Controller
    {
        [HttpGet]
        public JsonResult GetCurrentDate()
        {
            return Json(new {Hour = DateTime.Now.Hour, Minute = DateTime.Now.Minute, Second = DateTime.Now.Second });
        }
    }
}