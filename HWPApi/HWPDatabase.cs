using HWPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HWPApi
{
    public class HWPDatabase : DbContext
    {
        public HWPDatabase(DbContextOptions<HWPDatabase> options) : base(options) { }

        public DbSet<WorkoutPlan> WorkoutPlan { get; set; }
        public DbSet<WorkoutTask> WorkoutTask { get; set; }

    }
}
