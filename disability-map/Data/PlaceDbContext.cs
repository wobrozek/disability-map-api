using disability_map.Models;
using Microsoft.EntityFrameworkCore;

namespace disability_map.Data
{
    public class PlaceDbContext:DbContext
    {
        public PlaceDbContext(DbContextOptions<PlaceDbContext> options):base(options)
        {

        }

        public DbSet<Place> Place { get; set; }
        public DbSet<Score> Score { get; set; }
    }
}
