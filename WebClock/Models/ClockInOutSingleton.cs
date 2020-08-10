﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebClock.Models
{
    public class ClockInOutSingleton
    {
        private static ClockInOutSingleton _instance = new ClockInOutSingleton();

        private ClockInOutSingleton()
        {
            ClockInOutList = new List<ClockInOut> {
                new ClockInOut { UserId = 1, ClockInTimes =new List<DateTime>(){DateTime.UtcNow.AddHours(-2)},ClockOutTimes = new List<DateTime>(),IsClockedIn = true },
                new ClockInOut { UserId = 2, ClockInTimes = new List<DateTime>(), IsClockedIn = false },
                new ClockInOut { UserId = 3, ClockInTimes =new List<DateTime>(){DateTime.UtcNow.AddHours(-4)}, IsClockedIn = true }
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
            try
            {
                ClockInOutList.First(x => x.UserId == id).IsClockedIn
                    = !ClockInOutList.First(x => x.UserId == id).IsClockedIn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //todo rejestrowanie czasu
        }
    }
}