using FluentAssertions;
using WebClock.Controllers.Dtos;
using Xunit;
namespace WebColock.Tests.IntegrationTest
{
    public class IntegrationClockInOutControllerTests
    {
        private readonly ServerSut _server = new ServerSut();
        const int _userId = 1;

        [Fact]
        public async void ClockIn_Test()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());
            //todo usunąć <object>
        }

        [Fact]
        public async void ClockOut_Test()
        {
            var server = new ServerSut();
            var userId = 1;
            await server
                .DoPost<object>($"api/ClockInOut/ClockIn/{userId}", new object());

            await server
                .DoPost<object>($"api/ClockInOut/ClockOut/{userId}", new object());
        }

        [Fact]
        public async void Balance_WhenCalled_ReturnBalanceDtoObject()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{_userId}", new object());

            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{_userId}");

            result.HoursWorked.Should().NotBe(null);
            result.MinutesWorked.Should().NotBe(null);
            result.HoursLeft.Should().NotBe(null);
            result.MinutesLeft.Should().NotBe(null);
        }
    }
}