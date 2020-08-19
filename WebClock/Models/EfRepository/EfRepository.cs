using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
        
    }

    public static class Extensions
    {
        public static ClockInOutDb MapToDb(this ClockInOut clockInOut)
        {
            return new ClockInOutDb { UserId = clockInOut.UserId, Date = clockInOut.Date, Type = clockInOut.Type };
        }
        public static ClockInOut MapFromDb(this ClockInOutDb clockInOutDb)
        {
            return new ClockInOut { UserId = clockInOutDb.UserId, Date = clockInOutDb.Date, Type = clockInOutDb.Type };
        }
    }
}