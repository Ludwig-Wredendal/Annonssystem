using Annonssystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Annonssystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        /* Skapa annonser */
        public IActionResult Annons()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> testaGet()
        {
            List<PrenumerantDetalj> prenumerantlista = new List<PrenumerantDetalj>();
            HttpClient client = new();
            client.BaseAddress = new Uri("https://localhost:7234");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Prenumerant/getPrenumeranter");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                prenumerantlista = JsonConvert.DeserializeObject<List<PrenumerantDetalj>>(apiResponse);
                return View(prenumerantlista);
            }
            return RedirectToAction("Index");
        }
    }
}