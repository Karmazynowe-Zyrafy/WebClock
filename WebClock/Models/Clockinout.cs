using System;
using System.Collections.Generic;

namespace WebClock.Models
{
    public class ClockInOut
    {
        public int UserId { get; set; }
        public List<DateTime> ClockInTimes { get; set; }
        public List<DateTime> ClockOutTimes { get; set; }
        public bool IsClockedIn { get; set; }
    }
}