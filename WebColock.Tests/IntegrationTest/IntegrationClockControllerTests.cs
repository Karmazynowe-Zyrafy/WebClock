using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebClock.Models;
using Xunit;

namespace WebColock.Tests.IntegrationTest
{
    public class IntegrationClockControllerTests
    {
        [Fact]
        public async void TestPostRegistration()
        {
            var server = new ServerSut();

            var result = await server.DoPost("/clock", new { UserId = 1 });

            result.Should().BeOfType(typeof(string));
        }

        [Fact]
        public async void TestCheckingRegistration()
        {
            var server = new ServerSut();

            var result = await server.DoGet<ClockInOut>("/check/1");

            result.Should().BeOfType(typeof(ClockInOut));
        }
    }
}