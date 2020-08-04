using System;
using System.Collections.Generic;
using System.Text;
using WebClock.Controllers;
using Xunit;

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
    }
}
