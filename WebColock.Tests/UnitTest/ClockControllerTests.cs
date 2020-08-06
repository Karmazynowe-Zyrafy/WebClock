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
            var currentDate = JsonConvert.DeserializeObject<Clock>(result);

            DateTime dt = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                currentDate.Hour,
                currentDate.Minute,
                currentDate.Second);

            Assert.InRange(DateTime.Now, dt.AddSeconds(-15), dt.AddSeconds(15));

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
