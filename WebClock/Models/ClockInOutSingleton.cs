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
                new ClockInOut { UserId = 1, ClockoutTime = DateTime.UtcNow, IsClockedIn = true },
                new ClockInOut { UserId = 2, ClockoutTime = DateTime.UtcNow.AddHours(2), IsClockedIn = false },
                new ClockInOut { UserId = 3, ClockoutTime = DateTime.UtcNow.AddHours(4), IsClockedIn = true }
            };
        }

        private static List<ClockInOut> ClockInOutList { get; set; }

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

        public List<ClockInOut> GetClockInOutAllUsers()
        {
            return ClockInOutList;
        }

        public void ChangeClockStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}