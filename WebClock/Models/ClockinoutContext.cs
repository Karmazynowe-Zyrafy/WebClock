using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClock.Models
{
    public class ClockInOutContext : DbContext
    {
        public ClockInOutContext(DbContextOptions<ClockInOutContext> options) : base(options)
        {

        }
        public DbSet<ClockInOutDb> ClocksInOut { get; set; }
    }
}
