﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using WebClock;
using WebClock.Controllers.Dtos;
using WebClock.Models;
using Xunit;

namespace WebColock.Tests.UnitTests
{
    public class CountBalanceTests
    {
        // A - Wchodzi/wychodzi dzisiaj
        // B - Wchodzi dzisiaj, wychodzi jutro
        // C - Wchodzi kilka razy dziennie
        // Inne scenariusze
        // D - Wchodzi kilka razy z rzędu
        // E - Wychodzi kilka razy z rzędu

        [Fact]
        public void CountWorkTime_UserWorks2HoursAnd10MinutesInTheSameDay_ReturnCorrectAmountOfHoursAndMinutes()
        {
            List<ClockInOut> dataIn = new List<ClockInOut>
            {
                new ClockInOut
                {
                    UserId = 1,
                    Date = new DateTime(2020, 08, 19, 9, 10, 0),
                    Type = ClockType.In
                },
            };
            List<ClockInOut> dataOut = new List<ClockInOut>
            {
                new ClockInOut
                {
                    UserId = 1,
                    Date = new DateTime(2020, 08, 19, 11, 20, 0),
                    Type = ClockType.Out
                }
            };

            BalanceDto result = CountBalance.CountWorkTime(dataIn, dataOut);

            result.HoursWorked.Should().Be(2);
            result.MinutesWorked.Should().Be(10);
            result.HoursLeft.Should().Be(157);
            result.MinutesLeft.Should().Be(50);
        }
        [Fact]
        public void CountWorkTimeThisMonth()
        {
            List<ClockInOut> dataIn = new List<ClockInOut>
            {
                new ClockInOut
                {
                    UserId = 1,
                    Date = new DateTime(2020, DateTime.UtcNow.Month, 19, 9, 10, 0),
                    Type = ClockType.In
                },
            };
            List<ClockInOut> dataOut = new List<ClockInOut>
            {
                new ClockInOut
                {
                    UserId = 1,
                    Date = new DateTime(2020, DateTime.UtcNow.Month, 19, 11, 20, 0),
                    Type = ClockType.Out
                }
            };

            BalanceDto result = CountBalance.CountWorkTimeCurrent(dataIn, dataOut);

            result.HoursWorked.Should().Be(2);
            result.MinutesWorked.Should().Be(10);

        }
        [Fact]
        public void CloseCurrentDayToCalculateBalance()
        {
            List<ClockInOut> dataIn = new List<ClockInOut>
            {
                new ClockInOut
                {
                    UserId = 1,
                    Date = new DateTime(2020, DateTime.UtcNow.Month, 19, 9, 10, 0),
                    Type = ClockType.In
                },
            };
            List<ClockInOut> dataOut = new List<ClockInOut>();


            BalanceDto result = CountBalance.CountWorkTimeCurrent(dataIn, dataOut);

            dataIn.Count.Should().Equals(dataOut.Count);

        }
    }
}