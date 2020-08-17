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
    }
}
