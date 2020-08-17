using System;
using WebClock.Models.EfRepository;

namespace WebClock.Models.MemoryRepository
{
    public class ClockInOutMemory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public ClockType Type { get; set; }
    }
}