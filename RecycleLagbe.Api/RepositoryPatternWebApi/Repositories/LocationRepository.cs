using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RepositoryPatternWebApi.Data;
using RepositoryPatternWebApi.Models;

namespace RepositoryPatternWebApi.Repositories;

public class LocationRepository(ECommerceDbContext context, IMemoryCache cache) : ILocationRepository
{
    private readonly ECommerceDbContext _context = context;
    private readonly IMemoryCache _cache = cache;

    public async Task<List<Country>> GetCountriesAsync()
    {
        var cacheKey = "Countries";

        if (!_cache.TryGetValue(cacheKey, out List<Country>? countries))
        {
            countries = await _context.Countries.AsNoTracking().ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.High);

            _cache.Set(cacheKey, countries, cacheEntryOptions);
        }

        return countries ?? [];
    }

    public void RemoveCountriesFromCache()
    {
        var cacheKey = "Countries";
        _cache.Remove(cacheKey);
    }

    public async Task AddCountry(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        RemoveCountriesFromCache();
    }

    public async Task UpdateCountry(Country updatedCountry)
    {
        _context.Countries.Update(updatedCountry);
        await _context.SaveChangesAsync();
        RemoveCountriesFromCache();
    }

    public async Task<List<State>> GetStatesAsync(int countryId)
    {
        string cacheKey = $"States_{countryId}";

        if (!_cache.TryGetValue(cacheKey, out List<State>? states))
        {
            states = await _context.States
                                    .Where(s => s.CountryId == countryId)
                                    .AsNoTracking()
                                    .ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                .SetPriority(CacheItemPriority.Normal);

            _cache.Set(cacheKey, states, cacheEntryOptions);
        }

        return states ?? [];
    }

    public async Task<List<City>> GetCitiesAsync(int stateId)
    {
        string cacheKey = $"Cities_{stateId}";

        if (!_cache.TryGetValue(cacheKey, out List<City>? cities))
        {
            cities = await _context.Cities
                                    .Where(c => c.StateId == stateId)
                                    .AsNoTracking()
                                    .ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                .SetPriority(CacheItemPriority.Low);

            _cache.Set(cacheKey, cities, cacheEntryOptions);
        }

        return cities ?? [];
    }
}
