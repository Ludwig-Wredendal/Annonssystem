using Microsoft.AspNetCore.Mvc;

namespace Annonssystem.Controllers
{
    public class AnnonsController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:7234/api");
        private readonly HttpClient _client;

        public AnnonsController()
        {
            _client = new  HttpClient();
            _client.BaseAddress = baseAdress;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
