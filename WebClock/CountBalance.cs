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
    }
}