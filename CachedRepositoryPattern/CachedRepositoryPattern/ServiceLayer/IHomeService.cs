using CachedRepositoryPattern.Models;

namespace CachedRepositoryPattern.ServiceLayer;

public interface IHomeService
{
    public Task<List<Content>> GetHomePageContent();
    public Task<List<Content>> GetGoodStuff();
}
