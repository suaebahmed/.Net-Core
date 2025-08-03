
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options): base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; } = null!;
    }
}
