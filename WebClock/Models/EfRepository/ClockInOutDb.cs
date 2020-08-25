using System;
using System.ComponentModel.DataAnnotations;

namespace WebClock.Models.EfRepository
{
    public class ClockInOutDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ClockType Type { get; set; }
    }
}
