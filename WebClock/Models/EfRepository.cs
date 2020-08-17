using System;
using WebClock.Models;

namespace WebClock.Models
{
    public class EfRepository
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
}

public enum ClockType
{
    Out = 0,
    In = 1
};

public class ClockInOut
{
    public int UserId { get; set; }
    public ClockType Type { get; set; }
    public DateTime Date { get; set; }
}

public static class Extensions
{
    public static ClockInOutDb MapToDb(this ClockInOut clockInOut)
    {
        return new ClockInOutDb {UserId = clockInOut.UserId, Date = clockInOut.Date, Type = clockInOut.Type};
    }
}