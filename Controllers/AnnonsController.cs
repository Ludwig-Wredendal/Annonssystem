using Microsoft.AspNetCore.Mvc;

namespace Annonssystem.Controllers
{
    public class AnnonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
