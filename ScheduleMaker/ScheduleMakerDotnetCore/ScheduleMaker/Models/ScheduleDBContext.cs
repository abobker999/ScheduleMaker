
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMaker.Models
{
    public class ScheduleDBContext :DbContext
    {
        public ScheduleDBContext(DbContextOptions<ScheduleDBContext> options):base(options)
        {

        }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Period> periods { get; set; }
        public DbSet<Doctor> doctors { get; set; }

    }
}
