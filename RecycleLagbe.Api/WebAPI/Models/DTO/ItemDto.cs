namespace WebAPI.Models.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
