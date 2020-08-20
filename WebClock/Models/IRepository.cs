using System.Collections.Generic;

namespace WebClock.Models
{
    public interface IRepository
    {
        void Write(ClockInOut clockInOut);
        List<ClockInOut> Read(int id);
    }
}