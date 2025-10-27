using Microsoft.EntityFrameworkCore;
using URLShortenerAPI.Model;

namespace URLShortenerAPI.Data
{
    public class URLShortenerDbContext : DbContext
    {
        public URLShortenerDbContext(DbContextOptions<URLShortenerDbContext> options)
            : base(options)
        {
        }

        public DbSet<URL_Item> URL_Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed URLs
            modelBuilder.Entity<URL_Item>().HasData(
               new URL_Item
               {
                   Id = 1,
                   OriginalURL = "https://www.halalpay.com/create?id=1234568910&name=SUAEB",
                   ShortURLCode = "A1XS23",
                   CreatedAt = new DateTime(2024, 1, 1),
                   ClickCount = 10
               });
        }
    }
}