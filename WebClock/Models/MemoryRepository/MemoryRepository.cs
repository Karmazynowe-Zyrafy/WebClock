using System;
using System.Collections.Generic;
using WebClock.Models.EfRepository;

namespace WebClock.Models.MemoryRepository
{
    public class MemoryRepository : IRepository
    {
        public void Write(ClockInOut clockInOut)
        {
            throw new NotImplementedException();
        }

        // List<ClockInOut> _clockInOut = new List<ClockInOut>
        // {
        //     new ClockInO
        // }
    }
}