using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClock.Models;

namespace WebClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController : ControllerBase
    {
        private readonly List<ClockInOut> _repo;
        public ClockController()
        {
            _repo = ClockInOutSingleton.Instance.GetClockInOutSingleton();
        }

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

        [HttpGet]
        [Route("/check")]
        public string CheckingRegistration()
        {
           return "test";
        }
        
        [HttpPost]
        public async Task<ActionResult> ClockInOutRegistration(string UserId)
        {
            try
            {
                if (UserId == null)
                {
                    return BadRequest();
                }

                var currentUser = JsonConvert.DeserializeObject<ClockInOut>(UserId);
                var usersFromRepo = _repo.GetClockInOutSingleton();
                var user = usersFromRepo.First(id => id.UserId == currentUser.UserId);

                if (user.ClockoutStatus == "in")
                {
                    //zamień na out i przypisz datę
                }
                else
                {
                    //zamień na in i przypisz datę
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating data from the database");
            }
        }
    }
}