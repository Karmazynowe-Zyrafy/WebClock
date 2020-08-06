using System;
using WebClock.Controllers;
using Xunit;
using Newtonsoft.Json;
using WebClock;
using FluentAssertions;
using FluentAssertions.Extensions;

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
            result.Should().BeOfType<string>();
            result.Should().StartWith("{\"Hour\":").And.EndWith("}");
        }

        [Fact]
        public void GetCurrentTime_WhenCalled_ReturnCorrectSecond()
        {
            var result = _controller.GetCurrentTime();
            var currentDate = JsonConvert.DeserializeObject<Clock>(result);

            var timeSpanNow = DateTime.Now.TimeOfDay;

            timeSpanNow.Should().BeCloseTo(
                new TimeSpan(currentDate.Hour, currentDate.Minute, currentDate.Second), 15.Seconds());

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
