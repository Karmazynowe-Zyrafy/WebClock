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
            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{_userId}");

            result.HoursWorked.Should().NotBe(null);
            result.MinutesWorked.Should().NotBe(null);
            result.HoursLeft.Should().NotBe(null);
            result.MinutesLeft.Should().NotBe(null);
        }

        // A - Wchodzi/wychodzi dzisiaj
        // B - Wchodzi dzisiaj, wychodzi jutro
        // C - Wchodzi kilka razy dziennie
        // Inne scenariusze
        // D - Wchodzi kilka razy z rzędu
        // E - Wychodzi kilka razy z rzędu
        [Fact]
        public async void Balance_UserWorks2HoursAnd10MinutesInTheSameDay_ReturnCorrectAmountOfHoursAndMinutes()
        {
            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{_userId}");

            result.HoursWorked.Should().Be(2);
            result.MinutesWorked.Should().Be(10);
        }
    }
}
