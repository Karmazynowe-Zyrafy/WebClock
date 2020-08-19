using System;
using System.Linq;
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

        [Fact]
        public void Read_WhenCalled_ReturnClockInOutObject()
        {
            var memoryRepository = new MemoryRepository();
            var date = DateTime.Now;
            var clockInOut = new ClockInOut
            {
                UserId = 1,
                Date = date,
                Type = ClockType.In
            };
            memoryRepository.Write(clockInOut);

            var result = memoryRepository.Read(1);
            result.Select(x => x.UserId).FirstOrDefault().Should().Be(1);
            result.Select(x => x.Type).FirstOrDefault().Should().Be(ClockType.In);
            result.Select(x => x.Date).FirstOrDefault().Should().Be(date);
        }
    }
}