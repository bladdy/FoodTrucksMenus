using FoodTrucksMenus.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<MenuProducts> MenuProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().HasIndex("NameBranch", "TruckId").IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.NameCat).IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Menu>().HasIndex("Name","BranchId", "CategoryId" ).IsUnique();
            modelBuilder.Entity<Platform>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Truck>().HasIndex(p => p.Nametruck).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<MenuProducts>().HasIndex("MenuId", "ProductId").IsUnique();
        }
    }
}
