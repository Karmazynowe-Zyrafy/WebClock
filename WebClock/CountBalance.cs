using System;
using System.Collections.Generic;
using WebClock.Controllers.Dtos;
using WebClock.Models;

namespace WebClock
{
    public static class CountBalance
    {
        public static BalanceDto CountWorkTime(List<ClockInOut> dataIn, List<ClockInOut> dataOut)
        {
            var totalWorkTime = new TimeSpan();
            TimeSpan hoursToWorkInMonth = new TimeSpan(0, 160, 0, 0);

            for (int i = 0; i < dataIn.Count; i++)
            {
                totalWorkTime += dataOut[i].Date.TimeOfDay - dataIn[i].Date.TimeOfDay;
            }

            var totalLeftTime = hoursToWorkInMonth - totalWorkTime;

            var balanceDto = new BalanceDto
            {
                HoursWorked = (int) totalWorkTime.TotalHours,
                MinutesWorked = totalWorkTime.Minutes,
                HoursLeft = (int) totalLeftTime.TotalHours,
                MinutesLeft = totalLeftTime.Minutes
            };
            return balanceDto;
        }
    }
}