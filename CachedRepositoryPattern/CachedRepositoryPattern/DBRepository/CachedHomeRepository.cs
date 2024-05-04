using Microsoft.Extensions.Caching.Memory;
using CachedRepositoryPattern.Models;

namespace CachedRepositoryPattern.DBRepository;

public class CachedHomeRepository : IHomeRepository
{
    private readonly HomeRepository _homeRepository;
    private readonly IMemoryCache _memoryCache;
    private MemoryCacheEntryOptions cacheOptions;

    public CachedHomeRepository(HomeRepository homeRepository, IMemoryCache memoryCache)
    {
        _homeRepository = homeRepository;
        _memoryCache = memoryCache;
        cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(20));
    }

    public Task<List<Content>> GetGoodStuff()
    {
        string cacheKey = "goodstuff1";
        return _memoryCache.GetOrCreateAsync(
            cacheKey,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _homeRepository.GetGoodStuff();
            });

    }

    public Task<List<Content>> GetHomePageContent()
    {
        string cacheKey = "homepage";
        return _memoryCache.GetOrCreateAsync(
            cacheKey,
            entry =>
            {
                entry.SetOptions(cacheOptions);
                return _homeRepository.GetHomePageContent();
            });
    }
}
