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

    public enum ClockType
    {
        Out = 0,
        In = 1
    };

    public static class Extensions
    {
        public static ClockInOutDb MapToDb(this ClockInOut clockInOut)
        {
            return new ClockInOutDb { UserId = clockInOut.UserId, Date = clockInOut.Date, Type = clockInOut.Type };
        }
    }
}