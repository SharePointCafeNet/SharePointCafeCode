using Microsoft.AspNetCore.Mvc;
using CachedRepositoryPattern.Models;
using CachedRepositoryPattern.ServiceLayer;
using System.Diagnostics;

namespace CachedRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var goodstuff = new List<Content>();
            var homepageContent = new List<Content>();
            goodstuff =   await _homeService.GetGoodStuff();
            homepageContent = await _homeService.GetHomePageContent();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
