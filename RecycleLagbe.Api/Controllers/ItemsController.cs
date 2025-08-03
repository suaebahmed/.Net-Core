using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.DTO;
using WebAPI.Data;

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

        //Get all items
        //Get: https://localhost:7051/api/items
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Items.ToList();
            //Map Domain Models to DTOs
            var itemDto = new List<ItemDto>();
            foreach (var item in items)
            {
                itemDto.Add(new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Price = item.Price
                });
            }
            // return DTOs
            return Ok(itemDto);
            //return Ok(items);
        }
        //Get item by id
        //Get: https://localhost:7051/api/items/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound("No record found against this id");
            }
            //Map/convert Domain Model to DTO
            var itemDTO = new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Price = item.Price
            };
            return Ok(itemDTO);
        }
        //POST item
        //POST: https://localhost:7051/api/items
        [HttpPost]
        public IActionResult Post([FromBody] AddItemRequestDTo AddItemRequestDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Map/convert DTO to Domain Model
            Item itemDomainModel = new()
            {
                Name = AddItemRequestDTo.Name,
                Category = AddItemRequestDTo.Category,
                Price = AddItemRequestDTo.Price
            };
            _context.Items.Add(itemDomainModel);
            _context.SaveChanges();

            //Map/convert Domain Model to DTO
            ItemDto itemDto = new()
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
