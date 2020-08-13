using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClock.Models
{
    public class ClockInOutDatabase
    {
        [Key]
        public int Clockinout_Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime ClockoutTime { get; set; }
        public bool IsClockedIn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
