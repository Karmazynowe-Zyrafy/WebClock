using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClock.Models
{
    public class ClockInOutDatabase
    {
        public int UserId { get; set; }
        public DateTime ClockoutTime { get; set; }
        public bool IsClockedIn { get; set; }
    }
}
