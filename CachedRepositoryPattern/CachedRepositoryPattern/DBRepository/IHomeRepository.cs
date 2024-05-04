using CachedRepositoryPattern.Models;

namespace CachedRepositoryPattern.DBRepository;

public interface IHomeRepository
{
    public Task<List<Content>> GetHomePageContent();
    public Task<List<Content>> GetGoodStuff();
}
