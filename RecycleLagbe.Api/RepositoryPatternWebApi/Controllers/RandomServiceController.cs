//using Microsoft.AspNetCore.Mvc;
//using RandomService.NumberService;

//namespace RepositoryPatternWebApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class RandomServiceController : ControllerBase
//    {
//        private readonly INumberService _numberService1;
//        private readonly INumberService _numberService2;
//        public RandomServiceController(INumberService numberService1, INumberService numberService2) 
//        { 
//            _numberService1 = numberService1;
//            _numberService2 = numberService2;
//        }

//        [HttpGet]
//        public IActionResult GetResult()
//        {
//            return Ok(new
//            {
//                NumberFromService1 = _numberService1.GetRandomNumber(),
//                NumberFromService2 = _numberService2.GetRandomNumber()
//            });
//        }
//    }
//}
