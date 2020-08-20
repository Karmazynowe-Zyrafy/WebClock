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
        public async void Balance_WhenCalled_ReturnBalanceDtoObject()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{_userId}", new object());

            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{_userId}");

            result.HoursWorked.Should().NotBe(null).And.Should().NotBe(0);
            result.MinutesWorked.Should().NotBe(null).And.Should().NotBe(0);
            result.HoursLeft.Should().NotBe(null).And.Should().NotBe(0);
            result.MinutesLeft.Should().NotBe(null).And.Should().NotBe(0);
        }
    }
}