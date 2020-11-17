using api.calendar.Info.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.calendar.Info.SqlDbContext
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options) { }

        public DbSet<Scheduling> Scheduling { get; set; }
    }
}
