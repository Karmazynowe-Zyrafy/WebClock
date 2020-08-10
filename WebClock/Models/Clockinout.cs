using System;
using System.Collections.Generic;

namespace WebClock.Models
{
    public class ClockInOut
    {
        public int UserId { get; set; }
        public DateTime ClockoutTime { get; set; }
        public string ClockoutStatus { get; set; }
    }

    public class ClockInOutSingleton
    {
        private static ClockInOutSingleton instance = new ClockInOutSingleton();
        private ClockInOutSingleton() { }
        public static ClockInOutSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClockInOutSingleton();
                }
                return instance;
            }
        }
        public List<ClockInOut> GetClockInOutSingleton()
        {
            var clockInOutList = new List<ClockInOut> {
            new ClockInOut { UserId = 1, ClockoutTime = DateTime.UtcNow, ClockoutStatus = "in" },
            new ClockInOut { UserId = 1, ClockoutTime = DateTime.UtcNow.AddHours(2), ClockoutStatus = "out" },
            new ClockInOut { UserId = 1, ClockoutTime = DateTime.UtcNow.AddHours(4), ClockoutStatus = "in" }
            };
            return clockInOutList;
        }
    }
}