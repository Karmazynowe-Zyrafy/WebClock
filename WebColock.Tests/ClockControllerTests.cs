using System;
using WebClock.Controllers;
using Xunit;
using Newtonsoft.Json;
using WebClock;

namespace WebColock.Tests
{
    public class ClockControllerTests
    {

        private readonly ClockController _controller;

        public ClockControllerTests()
        {
            _controller = new ClockController();
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnString()
        {
            var result = _controller.GetCurrentTime();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnCorrectSecond()
        {
            var result = _controller.GetCurrentTime();

            var currentDate= JsonConvert.DeserializeObject<Clock>(result);
          
                Assert.InRange(DateTime.Now.Second,currentDate.Second-15,currentDate.Second+15);
            
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnCorrectTimeInterval()
        {
            var result = _controller.GetCurrentTime();

            var currentDate = JsonConvert.DeserializeObject<Clock>(result);

            Assert.InRange(DateTime.Now.Hour, 0,23);
            Assert.InRange(DateTime.Now.Minute, 0,59);
            Assert.InRange(DateTime.Now.Second, 0,59);
        }
    }
}
