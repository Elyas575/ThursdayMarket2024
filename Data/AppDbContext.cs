using Microsoft.EntityFrameworkCore;
using ThursdayMarket.Models;

namespace ThursdayMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Vegetables", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Fruits", DisplayOrder = 2 }
                );
        }
    }
}
