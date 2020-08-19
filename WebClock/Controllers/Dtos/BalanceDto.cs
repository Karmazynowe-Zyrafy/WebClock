using System;

namespace WebClock.Controllers.Dtos
{
    public class BalanceDto
    {
        public int HoursWorked  { get; set; }
        public int MinutesWorked  { get; set; }
        public int HoursLeft  { get; set; }
        public int MinutesLeft  { get; set; }
    }
}