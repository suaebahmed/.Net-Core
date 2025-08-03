using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // https://localhost:7051/api/homeitems
    [Route("api/[controller]")]
    [ApiController]

    public class StaticDataItemsController : ControllerBase
    {
        // https://localhost:7051/api/homeitems/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = new List<Item>
            {
                new Item { Id = 1, Name = "Item 1", Category = "A", Price = 10 },
                new Item { Id = 2, Name = "Item 2", Category = "B", Price = 20 },
                new Item { Id = 3, Name = "Item 3", Category = "C", Price = 30 },
                new Item { Id = 4, Name = "Item 4", Category = "D", Price = 40 },
                new Item { Id = 5, Name = "Item 5", Category = "E", Price = 50 },
            };
            return Ok(items);
            
        }

    }
}

