using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using WebClock.Models.EfRepository;

namespace WebClock.Models.MemoryRepository
{
    public partial class MemoryRepository : IRepository
    {
        public List<ClockInOutMemory> ClocksInOut { get; set; }
        private int _autoid = 0;
        public int AutoId

        {
            get => _autoid;
            private set { _autoid++; }
        }
        public void Write(ClockInOut clockInOut)
        {
            throw new NotImplementedException();
        }

        public MemoryRepository()
        {
            int x = 7;

            ClocksInOut.Add(new ClockInOutMemory { Id = AutoId, UserId = 3, Date = DateTime.UtcNow, Type = ClockType.In });
            ClocksInOut.Add(new ClockInOutMemory { Id = AutoId, UserId = 3, Date = DateTime.UtcNow.AddHours(1), Type = ClockType.Out });
            ClocksInOut.Add(new ClockInOutMemory { Id = AutoId, UserId = 3, Date = DateTime.UtcNow.AddHours(2), Type = ClockType.In });
            ClocksInOut.Add(new ClockInOutMemory { Id = AutoId, UserId = 3, Date = DateTime.UtcNow.AddHours(3), Type = ClockType.Out });
        }


    }
}