using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRV3.Hubs;
using SignalRV3.Models;
using System.Threading.Tasks;

namespace SignalRV3.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public ServerController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChatMessage model)
        {
            await _chatHub.Clients.All.SendAsync("Message", model.Message); 
            return View();
        }
    }
}
