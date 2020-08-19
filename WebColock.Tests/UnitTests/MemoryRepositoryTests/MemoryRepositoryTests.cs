using System;
using FluentAssertions;
using WebClock.Models;
using WebClock.Models.MemoryRepository;
using Xunit;

namespace WebColock.Tests.UnitTests.MemoryRepositoryTests
{
    public class MemoryRepositoryTests
    {
        [Fact]
        public void Write_WhenCalled_AddClockInOutObject()
        {
            var memoryRepository = new MemoryRepository();
            var clockInOut = new ClockInOut
            {
                UserId = 1,
                Date = DateTime.Now,
                Type = ClockType.In
            };

            memoryRepository.Write(clockInOut);
            
            memoryRepository.ClocksInOut.Should().HaveCount(1);
        }
    }
}
