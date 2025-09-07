using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        public string? Category { get; set; }

        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
    }
}