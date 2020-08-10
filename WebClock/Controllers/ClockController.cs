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
        private readonly ClockInOutSingleton _repo;
        public ClockController()
        {
            _repo = ClockInOutSingleton.Instance;
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
        [Route("/check/{id}")]
        public string CheckingRegistration(int id)
        {
            var usersFromRepo = _repo.GetClockInOutAllUsers();
            var data = usersFromRepo.Where(x => x.UserId == id);
            var temp = data.First();
            return JsonConvert.SerializeObject(temp);
        }

        [HttpPost]
        public ActionResult ClockInOutRegistration(Object userId)
        {
            try
            {
                if (userId == null)
                {
                    return BadRequest();
                }
                var currentUser = JsonConvert.DeserializeObject<ClockInOut>(userId.ToString());

                _repo.ChangeClockStatus(currentUser.UserId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return Ok();
        }
    }
}