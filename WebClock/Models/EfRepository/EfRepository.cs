using System.Collections.Generic;
using System.Linq;

namespace WebClock.Models.EfRepository
{
    public class EfRepository : IRepository
    {
        private readonly ClockInOutContext _context;

        public EfRepository(ClockInOutContext context)
        {
            _context = context;
        }

        public void Write(ClockInOut clockInOut)
        {
            var clockInOutDb = clockInOut.MapToDb();
            _context.ClocksInOut.Add(clockInOutDb);
            _context.SaveChanges();
        }

        public List<ClockInOut> Read(int id)
        {
            var clockInOutDb = _context.ClocksInOut.Where(x => x.UserId == id);
            return clockInOutDb.Select(item => item.MapFromDb()).ToList();
        }
        public ClockInOut ReadLast(int id)
        {
            var clocksInOut= _context.ClocksInOut.Where(x => x.UserId == id).OrderByDescending(x => x.Date).ToList();
            if(clocksInOut.Count==0)
            {
                return null;
            }
            return clocksInOut.First().MapFromDb();
        }
    }


    public static class Extensions
    {
        public static ClockInOutDb MapToDb(this ClockInOut clockInOut)
        {
            return new ClockInOutDb {UserId = clockInOut.UserId, Date = clockInOut.Date, Type = clockInOut.Type};
        }

        public static ClockInOut MapFromDb(this ClockInOutDb clockInOutDb)
        {
            return new ClockInOut {UserId = clockInOutDb.UserId, Date = clockInOutDb.Date, Type = clockInOutDb.Type};
        }
    }
}