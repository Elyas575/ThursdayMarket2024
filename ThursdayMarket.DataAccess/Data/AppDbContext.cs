using Microsoft.EntityFrameworkCore;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Vegetables", DisplayOrder = 1, IsDeleted = false },
                new Category { Id = 2, Name = "Fruits", DisplayOrder = 2, IsDeleted = false }
                ); ;

            modelBuilder.Entity<Product>().HasData(
                new Product { Id= 1, Name = "Bananas", CategoryId = 1, Price = 20, Description = "Fresh Bananas", DiscountPrice = 15, Quantity = 1, Weight = 1, Image = "https://plus.unsplash.com/premium_photo-1664527307725-362b589c406d?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                 new Product {Id=2, Name = "Apples", CategoryId = 2, Price = 15, Description = "Fresh Apples", DiscountPrice = 10, Quantity = 1, Weight = 1, Image = "https://plus.unsplash.com/premium_photo-1664527307725-362b589c406d?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }

                );
        }
    }
}
