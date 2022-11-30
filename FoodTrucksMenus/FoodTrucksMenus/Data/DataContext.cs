using FoodTrucksMenus.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.NameCat).IsUnique();
            modelBuilder.Entity<Platform>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
