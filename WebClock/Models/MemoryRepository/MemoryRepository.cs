using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebClock.Models.MemoryRepository
{
    public class MemoryRepository : IRepository
    {
        public List<ClockInOutMemory> ClocksInOut { get; set; } = new List<ClockInOutMemory>();

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

        public List<ClockInOut> Read(int id)
        {
            var result = ClocksInOut.Where(x => x.UserId == id).ToList();
            var clockInOut = new List<ClockInOut>();
            clockInOut.AddRange(result
                .Select(t => new ClockInOut {UserId = t.UserId, Date = t.Date, Type = t.Type}));
            return clockInOut;
        }
        public ClockInOut ReadLast(int id)
        {
            //var result = ClocksInOut.Where(x => x.UserId == id).OrderByDescending(x=>x.Date).FirstOrDefault();
            //var clockInOut = new ClockInOut { UserId = result.UserId, Date = result.Date, Type = result.Type };
            //return clockInOut;
            var clocksInOut = ClocksInOut.Where(x => x.UserId == id).OrderByDescending(x => x.Date).ToList();
            if (clocksInOut.Count == 0)
            {
                return null;
            }
            var lastRecord = clocksInOut.First();
            return new ClockInOut { UserId = lastRecord.UserId, Date = lastRecord.Date, Type = lastRecord.Type };
        }
    }
}