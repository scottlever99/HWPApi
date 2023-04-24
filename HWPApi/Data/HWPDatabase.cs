using HWPApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HWPApi.Data
{
    public class HWPDatabase : DbContext
    {
        public HWPDatabase(DbContextOptions<HWPDatabase> options) : base(options) { }

        public DbSet<Auth> Auth { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Template_Exercise> Template_Exercise { get; set; }
        public DbSet<Template_Exercise_Set> Template_Exercise_Set { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<History> History { get; set; }

    }
}
