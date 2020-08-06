using System;
using Newtonsoft.Json;
using WebClock;
using Xunit;

namespace WebColock.Tests.IntegrationTest
{
    public class IntegrationClockTest
    {
        [Fact]
        public async void GetCurrentTime_WhenCalled_ReturnCorrectSecond()
        {
            var server = new ServerSut();
            var result = await server.DoGet<Clock>("/clock");

        }
    }
}