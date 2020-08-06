using System;
using WebClock.Controllers;
using Xunit;
using Newtonsoft.Json;
using WebClock;
using FluentAssertions;

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


            currentDate.Hour.Should().BeGreaterThan(0).And.BeLessThan(23);
            currentDate.Minute.Should().BeGreaterThan(0).And.BeLessThan(59);
            currentDate.Second.Should().BeGreaterThan(0).And.BeLessThan(59);
        }
    }
}
