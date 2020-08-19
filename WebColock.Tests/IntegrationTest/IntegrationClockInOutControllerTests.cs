﻿using FluentAssertions;
using Xunit;

namespace WebColock.Tests.IntegrationTest
{
    public class IntegrationClockInOutControllerTests
    {
        [Fact]
        public async void ClockIn_Test()
        {
            var server = new ServerSut();
            var userId = 1;

            await server
                .DoPost<object>($"api/ClockInOut/ClockIn/{userId}", new object());
            //todo usunąć <object>
        }
        [Fact]
        public async void ClockOut_Test()
        {
            var server = new ServerSut();
            var userId = 1;

            await server
                .DoPost<object>($"api/ClockInOut/ClockOut/{userId}", new object());
        }
        [Fact]
        public async void ClockInOut_ReadTest()
        {


            var server = new ServerSut();
            var userId = 1;
            await server
               .DoPost<object>($"api/ClockInOut/ClockIn/{userId}", new object());
            await server
               .DoPost<object>($"api/ClockInOut/ClockOut/{userId}", new object());

            var result = await server
                .DoGet<object>($"api/ClockInOut/{userId}");

        }
    }
}
