using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController : Controller
    {
        [HttpGet]
        public JsonResult GetActualDate()
        {
            return Json(new { CurrentDate = DateTime.Now });
        }
    }
}