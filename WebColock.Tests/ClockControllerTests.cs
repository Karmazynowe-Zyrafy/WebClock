﻿using System;
using WebClock.Controllers;
using Xunit;
using Newtonsoft.Json;
using WebClock;

namespace WebColock.Tests
{
    public class ClockControllerTests
    {
        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnString()
        {
            var clockController = new ClockController();
            var result = clockController.GetCurrentTime();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnCorrectSecond()
        {
            var clockController = new ClockController();
            var result = clockController.GetCurrentTime();

            var currentDate= JsonConvert.DeserializeObject<Clock>(result);
          
                Assert.InRange(DateTime.Now.Second,currentDate.Second-15,currentDate.Second+15);
            
        }
    }
}
