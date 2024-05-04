using CachedRepositoryPattern.DBRepository;
using CachedRepositoryPattern.Models;

namespace CachedRepositoryPattern.ServiceLayer
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository) 
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<Content>> GetGoodStuff()
        {
            var data = new List<Content>();
            data = await _homeRepository.GetGoodStuff();
            return data;
        }

        public async Task<List<Content>> GetHomePageContent()
        {
            
            return await _homeRepository.GetHomePageContent();
        }

        
    }
}
