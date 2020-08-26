using System;
using System.Collections.Generic;
using WebClock.Controllers.Dtos;
using WebClock.Models;

namespace WebClock
{
    public static class CountBalance
    {
        public static BalanceDto CountWorkTime(List<ClockInOut> datesIn, List<ClockInOut> datesOut)
        {
            var totalWorkTime = new TimeSpan();
            var hoursToWorkInMonth = new TimeSpan(0, 160, 0, 0);

            for (var i = 0; i < datesIn.Count; i++)
            {
                totalWorkTime += datesOut[i].Date.TimeOfDay - datesIn[i].Date.TimeOfDay;
            }

            var totalLeftTime = hoursToWorkInMonth - totalWorkTime;

            return new BalanceDto
            {
                HoursWorked = (int)totalWorkTime.TotalHours,
                MinutesWorked = totalWorkTime.Minutes,
                HoursLeft = (int)totalLeftTime.TotalHours,
                MinutesLeft = totalLeftTime.Minutes
            };
        }
        public static BalanceDto CountWorkTimeCurrent(List<ClockInOut> datesIn, List<ClockInOut> datesOut)
        {
            var totalWorkTime = new TimeSpan();
            var hoursToWorkInMonthToThisDay = new TimeSpan(0, Convert.ToInt32(GetBusinessDaysInThisMonth() * 8), 0, 0);
            if (datesIn.Count > datesOut.Count)
            {
                datesOut.Add(new ClockInOut { UserId = 1, Date = DateTime.UtcNow, Type = ClockType.Out });
            }
            for (int i = 0; i < datesIn.Count; i++)
            {
                totalWorkTime += datesOut[i].Date.TimeOfDay - datesIn[i].Date.TimeOfDay;
            }

            var totalLeftTime = hoursToWorkInMonthToThisDay - totalWorkTime;

            return new BalanceDto
            {
                HoursWorked = (int)totalWorkTime.TotalHours,
                MinutesWorked = totalWorkTime.Minutes,
                HoursLeft = (int)totalLeftTime.TotalHours,
                MinutesLeft = totalLeftTime.Minutes
            };

        }
        public static double GetBusinessDaysInThisMonth()
        {
            DateTime startD = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0);
            DateTime endD = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0); ;
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }
    }
}