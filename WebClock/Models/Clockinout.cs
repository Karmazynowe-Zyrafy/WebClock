using System;

namespace WebClock.Models
{
    public class ClockInOut
    {
        public int UserId { get; set; }
        public DateTime ClockoutTime { get; set; }
        public string ClockoutStatus { get; set; }
    }
}