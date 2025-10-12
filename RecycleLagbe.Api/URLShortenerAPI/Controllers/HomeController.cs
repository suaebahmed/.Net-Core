using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using URLShortenerAPI.Data;
using URLShortenerAPI.DTOs;
using URLShortenerAPI.Model;
using URLShortenerAPI.Service.Counter;

namespace URLShortenerAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private string GenerateShortCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            long count = _counterService.GetNextCount();
            string hash = "";
            while (count > 0)
            {
                int length = chars.Length;
                hash += chars[(int)(count % length)];
                count /= 62;
            }
            return hash;
        }
        private CounterService _counterService;
        private URLShortenerDbContext _context;

        public HomeController(CounterService counterService, URLShortenerDbContext context)
        {
            _counterService = counterService;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] InputDTO input)
        {
            if (string.IsNullOrWhiteSpace(input?.Url))
                return BadRequest("Url is required.");

            var URLMapping = new URL_Item
            {
                OriginalURL = input.Url,
                ShortenedURL = "https://www.tinyurl.com/" + GenerateShortCode(),
                ClickCount = 0
            };

            await _context.URL_Items.AddAsync(URLMapping);
            await _context.SaveChangesAsync();

            return Ok(URLMapping);
        }

        [HttpGet("{shortURLCode}")]
        public async Task<IActionResult> GetAsync(string shortURLCode)
        {
            var obj = await _context.URL_Items
                .Where(u => u.ShortenedURL.EndsWith("/" + shortURLCode))
                .AsNoTracking()
                .ToListAsync();

            if (obj.IsNullOrEmpty()) return NotFound();

            return Ok(obj);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _context.URL_Items
                .AsNoTracking()
                .ToListAsync();

            return Ok(all);
        }
    }
}
