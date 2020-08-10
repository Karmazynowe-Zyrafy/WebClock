﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using WebClock.Models;
using Xunit;

namespace WebColock.Tests.Model
{
    public class ClockInOutSingletonTests
    {
        [Fact]
        public void ChangeClockStatus_WhenCalled_PropertyIsClockedIsOpposite()
        {
            int userId = 1;

            var isClockedInBeforeChange =
            ClockInOutSingleton.Instance.GetClockInOutAllUsers()
                .First(id => id.UserId == userId)
                .IsClockedIn;

            ClockInOutSingleton.Instance.ChangeClockStatus(userId);

            var isClockedInAfterChange
                = ClockInOutSingleton.Instance.GetClockInOutAllUsers()
                .First(id => id.UserId == userId)
                .IsClockedIn;

            isClockedInAfterChange.Should().Be(!isClockedInBeforeChange);
        }
    }
}