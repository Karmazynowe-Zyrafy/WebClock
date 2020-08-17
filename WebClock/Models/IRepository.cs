using WebClock.Models.EfRepository;

namespace WebClock.Models
{
    public interface IRepository
    {
        void Write(ClockInOut clockInOut);
    }
}