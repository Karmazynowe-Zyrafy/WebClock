using System.Collections.Generic;
using FluentAssertions;
using WebClock.Controllers.Dtos;
using WebClock.Models;
using Xunit;

namespace WebColock.Tests.IntegrationTests
{
    public class IntegrationClockInOutControllerTests
    {
        private readonly ServerSut _server = new ServerSut();
        private const int UserId = 1;

        [Fact]
        public async void ClockIn_Test()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{UserId}", new object());
            //todo usunąć <object>
        }

        [Fact]
        public async void ClockOut_Test()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{UserId}", new object());
        }

        [Fact]
        public async void Balance_WhenCalled_ReturnBalanceDtoObject()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{UserId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{UserId}", new object());

            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{UserId}");

            result.HoursWorked.Should().NotBe(null);
            result.MinutesWorked.Should().NotBe(null);
            result.HoursLeft.Should().NotBe(null);
            result.MinutesLeft.Should().NotBe(null);
        }

        [Fact]
        public async void History_WhenCalled_ReturnListClockInOut()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{UserId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{UserId}", new object());
            var result = await _server.DoGet<List<ClockInOut>>($"api/ClockInOut/History/{UserId}");
            result.Should().NotBeNull();
        }
    }
}