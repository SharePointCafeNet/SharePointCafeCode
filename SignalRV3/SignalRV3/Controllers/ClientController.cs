using Microsoft.AspNetCore.Mvc;

namespace SignalRV3.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
