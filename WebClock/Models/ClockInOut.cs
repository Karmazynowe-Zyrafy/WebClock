using System;

namespace WebClock.Models.EfRepository
{
    public class ClockInOut
    {
        public int UserId { get; set; }
        public ClockType Type { get; set; }
        public DateTime Date { get; set; }
    }
}