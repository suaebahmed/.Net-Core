namespace URLShortenerAPI.Model
{
    public class URL_Item
    {
        public int Id { get; set; }
        public string OriginalURL { get; set; } = string.Empty;
        public string ShortURLCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public int ClickCount { get; set; } = 0;
    }
}
