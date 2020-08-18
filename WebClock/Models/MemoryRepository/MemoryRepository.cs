using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using WebClock.Models.EfRepository;

namespace WebClock.Models.MemoryRepository
{
    public class MemoryRepository : IRepository
    {
        public List<ClockInOutMemory> ClocksInOut { get; set; }

        private int _lastId = 0;
        private int GenerateId()
        {
            return Interlocked.Increment(ref _lastId);
        }

        public void Write(ClockInOut clockInOut)
        {
            ClocksInOut.Add(
                new ClockInOutMemory
                {
                    Id = GenerateId(),
                    UserId = clockInOut.UserId,
                    Date = clockInOut.Date,
                    Type = clockInOut.Type
                });
        }

        public MemoryRepository()
        {
            ClocksInOut = new List<ClockInOutMemory>
            {
                new ClockInOutMemory { Id = GenerateId(), UserId = 1, Date = DateTime.UtcNow, Type = ClockType.In  },
                new ClockInOutMemory { Id = GenerateId(), UserId = 1, Date = DateTime.UtcNow, Type = ClockType.Out  },
                new ClockInOutMemory { Id = GenerateId(), UserId = 2, Date = DateTime.UtcNow, Type = ClockType.In  }
            };
        }


    }
}