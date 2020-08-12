using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClock.Models
{
    public class ClockinoutContext : DbContext
    {
        public ClockinoutContext(DbContextOptions<ClockinoutContext>options):base(options)
        {

        }
        public DbSet<ClockInOutDatabase> clockInOut { get; set; }
    }
}
