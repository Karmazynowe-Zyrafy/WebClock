using System;
using System.Collections.Generic;
using WebClock.Models.EfRepository;

namespace WebClock.Models.MemoryRepository
{
    public class MemoryRepository : IRepository
    {
        public List<ClockInOutMemory> ClocksInOut { get; set; }

        private int _autoId = 0;
        public int AutoId

        {
            get => ++_autoId;
            set { }
        }

        public void Write(ClockInOut clockInOut)
        {
            ClocksInOut.Add(
                new ClockInOutMemory
                {
                    Id = AutoId,
                    UserId = clockInOut.UserId,
                    Date = clockInOut.Date,
                    Type = clockInOut.Type
                });
        }

        public MemoryRepository()
        {
            ClocksInOut = new List<ClockInOutMemory>
            {
                new ClockInOutMemory { Id = AutoId, UserId = 1, Date = DateTime.UtcNow, Type = ClockType.In  },
                new ClockInOutMemory { Id = AutoId, UserId = 1, Date = DateTime.UtcNow, Type = ClockType.Out  },
                new ClockInOutMemory { Id = AutoId, UserId = 2, Date = DateTime.UtcNow, Type = ClockType.In  }
            };
        }


    }
}