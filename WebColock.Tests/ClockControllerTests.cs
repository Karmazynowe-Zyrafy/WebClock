using System;
using System.Collections.Generic;
using System.Text;
using WebClock.Controllers;
using Xunit;
using Newtonsoft.Json;
using WebClock;

namespace WebColock.Tests
{
    public class ClockControllerTests
    {
        [Fact]
        public void GetCurrentDate_WhenCalled_ReturnString()
        {
            var clockController = new ClockController();
            var result = clockController.GetCurrentDate();

            Assert.IsType<string>(result);
            
        }
        [Fact]
        public void GetCurrentDate_WhenCalled_ReturnCorrectTime()
        {
            var clockController = new ClockController();
            var result = clockController.GetCurrentDate();

            var currentDate= JsonConvert.DeserializeObject<Clock>(result);
          // c.Hour=
            //Assert.InRange(DateTime.Parse(json),DateTime.Now-TimeSpan.FromSeconds(5),DateTime.Now-TimeSpan.FromSeconds(-5) );
        }
    }
}
