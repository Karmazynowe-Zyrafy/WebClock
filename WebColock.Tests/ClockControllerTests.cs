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
            var timeFromController = JsonConvert.DeserializeObject<Clock>(result);

            var currentDateTime = DateTime.Now;
            var dt = new DateTime(
                currentDateTime.Year,
                currentDateTime.Month,
                currentDateTime.Day,
                timeFromController.Hour,
                timeFromController.Minute,
                timeFromController.Second);

            Assert.InRange(currentDateTime, dt.AddSeconds(-15), dt.AddSeconds(15));
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnCorrectTimeInterval()
        {
            var result = _controller.GetCurrentTime();

            var currentDate = JsonConvert.DeserializeObject<Clock>(result);

            Assert.InRange(currentDate.Hour, 0, 23);
            Assert.InRange(currentDate.Minute, 0, 59);
            Assert.InRange(currentDate.Second, 0, 59);
        }
    }
}
