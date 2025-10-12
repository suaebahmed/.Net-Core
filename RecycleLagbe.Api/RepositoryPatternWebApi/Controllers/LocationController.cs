using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWebApi.Repositories;

namespace RepositoryPatternWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationRepository repository) : ControllerBase
    {
        private readonly ILocationRepository _repository = repository;

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _repository.GetCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("states/{countryId}")]
        public async Task<IActionResult> GetStates(int countryId)
        {
            var states = await _repository.GetStatesAsync(countryId);
            return Ok(states);
        }

        [HttpGet("cities/{stateId}")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            var cities = await _repository.GetCitiesAsync(stateId);
            return Ok(cities);
        }
    }
}