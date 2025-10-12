using RepositoryPatternWebApi.Models;

namespace RepositoryPatternWebApi.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Country>> GetCountriesAsync();
        Task AddCountry(Country country);
        Task UpdateCountry(Country updatedCountry);

        Task<List<State>> GetStatesAsync(int countryId);

        Task<List<City>> GetCitiesAsync(int stateId);
    }
}