using System;

namespace WebClock.Models
{
    public class ClockInOut
    {
        public int UserId { get; set; }
        public ClockType Type { get; set; }
        public DateTime Date { get; set; }
    }
}