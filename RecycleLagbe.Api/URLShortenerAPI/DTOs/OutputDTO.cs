namespace URLShortenerAPI.DTOs
{
    public class OutputDTO
    {
        public int Id { get; set; }
        public string ShortenedURL { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ClickCount { get; set; } = 0;
    }
}