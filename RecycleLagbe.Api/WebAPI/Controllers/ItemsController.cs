using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.DTO;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsDbContext _context;
        public ItemsController(ItemsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
        {
            // Fetch all items and project directly to DTO to avoid tracking overhead
            var items = await _context.Items
                .AsNoTracking()
                .Select(item => new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Price = item.Price
                })
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound("No record found against this id");
            }
            var itemDTO = new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Price = item.Price
            };
            return Ok(itemDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody] AddItemRequestDTo AddItemRequestDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDomainModel = new Item
            {
                Name = AddItemRequestDTo.Name,
                Category = AddItemRequestDTo.Category,
                Price = AddItemRequestDTo.Price
            };

            _context.Items.Add(itemDomainModel);
            await _context.SaveChangesAsync();

            var itemDto = new ItemDto
            {
                Id = itemDomainModel.Id,
                Name = itemDomainModel.Name,
                Category = itemDomainModel.Category,
                Price = itemDomainModel.Price
            };
            return CreatedAtAction(nameof(GetById), new { id = itemDto.Id }, itemDto);
        }
    }
}
