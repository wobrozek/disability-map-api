using disability_map.Models;
using Microsoft.EntityFrameworkCore;

namespace disability_map.Data
{
    public class DbMainContext:DbContext
    {
        public DbMainContext(DbContextOptions<DbContext> options):base(options)
        {

        }

        public DbSet<Place> Place { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<User> User { get; set; }
    }
}
