using Microsoft.EntityFrameworkCore;

namespace WebClock.Models.EfRepository
{
    public class ClockInOutContext : DbContext
    {
        public ClockInOutContext(DbContextOptions<ClockInOutContext> options) : base(options)
        {
        }
        public DbSet<ClockInOutDb> ClocksInOut { get; set; }
    }
}
