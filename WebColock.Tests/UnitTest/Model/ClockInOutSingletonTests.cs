using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WebClock.Models;
using Xunit;

namespace WebColock.Tests.Model
{
    public class ClockInOutSingletonTests
    {
      //  private readonly ClockController _controller;

        public ClockInOutSingletonTests()
        {
            
        }

        [Fact]
        public void ChangeClockStatus_WhenCalled_ChangeIsClockedInProperty()
        {
            var lista = ClockInOutSingleton.Instance.GetClockInOutAllUsers();
        }

    }
}
