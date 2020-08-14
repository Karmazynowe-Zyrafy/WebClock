using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebClock.Controllers;

namespace WebClock.Models
{
    public class ClockInOutDatabase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ClockInOutController.ClockType Type { get; set; }
        
    }
}
