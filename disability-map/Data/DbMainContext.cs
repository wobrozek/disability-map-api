using disability_map.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace disability_map.Data
{
    public class DbMainContext:DbContext
    {
        public DbMainContext(DbContextOptions<DbMainContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // place - score

            modelBuilder
               .Entity<Score>()
               .HasMany(sc => sc.DisLikes)
               .WithMany(p => p.DisLikes);

            modelBuilder.Entity<Score>()
               .HasMany(sc => sc.Likes)
               .WithMany(p => p.Likes);


            modelBuilder
                .Entity<User>()
                .HasMany(e => e.DisLikes)
                .WithMany(e => e.DisLikes);

            modelBuilder
                .Entity<User>()
                .HasMany(e => e.Likes)
                .WithMany(e => e.Likes);

            // cords - place

            modelBuilder
                .Entity<Place>()
                .HasOne(e=> e.Cords)
                .WithOne(e => e.Place)
                .HasForeignKey<Cords>(e => e.PlaceId)
                .IsRequired();

        }

        public DbSet<Place> Place { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Cords> Cords { get; set; }
    }
}
