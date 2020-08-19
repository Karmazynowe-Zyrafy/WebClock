using System.Collections.Generic;
using WebClock.Models.EfRepository;

namespace WebClock.Models
{
    public interface IRepository
    {
        void Write(ClockInOut clockInOut);
        List<ClockInOut> Read(int id);
    }
}