using System;
using System.Collections.Generic;

namespace WebClock.Models
{
    public class ClockInOutSingleton
    {
        private static ClockInOutSingleton _instance = new ClockInOutSingleton();

        private ClockInOutSingleton()
        {
            ClockInOutList = new List<ClockInOut> {
                new ClockInOut { UserId = 1, ClockoutTime = DateTime.UtcNow, ClockoutStatus = "in" },
                new ClockInOut { UserId = 2, ClockoutTime = DateTime.UtcNow.AddHours(2), ClockoutStatus = "out" },
                new ClockInOut { UserId = 3, ClockoutTime = DateTime.UtcNow.AddHours(4), ClockoutStatus = "in" }
            };
        }

        public static List<ClockInOut> ClockInOutList;

        public static ClockInOutSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClockInOutSingleton();
                }
                return _instance;
            }
        }

        public List<ClockInOut> GetClockInOutSingleton()
        {
            return ClockInOutList;
        }
        
        public List<ClockInOut> ChangeClockStatus(int id)
        {
            //todo
            return ClockInOutList;
        }
    }
}