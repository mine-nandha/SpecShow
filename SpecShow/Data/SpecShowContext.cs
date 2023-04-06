using Microsoft.EntityFrameworkCore;
using SpecShow.Models;

namespace SpecShow.Data
{
    public class SpecShowContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(WebApplication.CreateBuilder().Configuration.GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Mobile>().ToTable("Mobile");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Favourite>().ToTable("Favourite");
        }
    }
}
