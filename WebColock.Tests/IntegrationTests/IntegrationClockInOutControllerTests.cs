using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebClock.Controllers.Dtos;
using WebClock.Models;
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
            var post = await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());
            post.Should().BeOfType(typeof(DateTime));
        }

        [Fact]
        public async void ClockOut_Test()
        {
            var server = new ServerSut();
            var userId = 1;
            var post1 = await server
                .DoPost<object>($"api/ClockInOut/ClockIn/{userId}", new object());

            var post2 = await server
                .DoPost<object>($"api/ClockInOut/ClockOut/{userId}", new object());
            post1.Should().BeOfType(typeof(DateTime));
            post2.Should().BeOfType(typeof(DateTime));
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

        [Fact]
        public async void Balance_IfLastIsClockIn_ReturnWithoutLastClockInElement()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());

            var result = await _server
                .DoGet<BalanceDto>($"api/ClockInOut/Balance/{_userId}");

            result.HoursWorked.Should().NotBe(null);
            result.MinutesWorked.Should().NotBe(null);
            result.HoursLeft.Should().NotBe(null);
            result.MinutesLeft.Should().NotBe(null);
        }

        [Fact]
        public async void History_WhenCalled_ReturnListClockInOut()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{_userId}", new object());
            var result = await _server.DoGet<List<ClockInOut>>($"api/ClockInOut/History/{_userId}");
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].UserId.Should().Be(_userId);
            result[1].UserId.Should().Be(_userId);
            result[0].Type.Should().Be(1);
            result[1].Type.Should().Be(0);
        }

        [Fact]
        public async void Status_WhenCalled_ReturnWorkStatus()
        {
            await _server
                .DoPost<object>($"api/ClockInOut/ClockIn/{_userId}", new object());

            await _server
                .DoPost<object>($"api/ClockInOut/ClockOut/{_userId}", new object());
            var status= await _server.DoGet<string>($"api/ClockInOut/WorkStatus/{_userId}");
            status.Should().NotBeNull();

        }
    }
}