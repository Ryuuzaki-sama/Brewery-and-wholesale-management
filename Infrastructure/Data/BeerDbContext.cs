using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BeerDbContext : DbContext
    {
        public BeerDbContext(DbContextOptions<BeerDbContext> options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Beer>()
        //      .HasOne(b => b.Brewer)
        //    .WithMany(b => b.Beers)
        //  .HasForeignKey(b => b.BrewerId);
        //}

    }
}
