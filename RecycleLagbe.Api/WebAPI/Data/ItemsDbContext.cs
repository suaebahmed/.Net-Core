using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for Price to avoid truncation warnings
            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Item 1",
                    Price = 15m,
                    Category = "Books"
                },
                new Item
                {
                    Id = 2,
                    Name = "Item 2",
                    Price = 110m,
                    Category = "Books"
                }
            );
        }
        public DbSet<Item> Items { get; set; } = null!;
    }
}
