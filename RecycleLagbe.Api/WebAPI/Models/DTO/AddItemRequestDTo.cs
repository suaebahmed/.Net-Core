namespace WebAPI.Models.DTO
{
    public class AddItemRequestDTo
    {
        public string Name { get; set; } = null!;
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
