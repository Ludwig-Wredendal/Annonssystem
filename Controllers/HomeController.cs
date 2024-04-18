using Annonssystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web;

namespace Annonssystem.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:7234/api");
        private readonly HttpClient _client;

        private readonly ILogger<HomeController> _logger; // nåt skräp för debugging.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }

        public IActionResult Index()
        {
            List<PrenumerantDetalj> prenumerantLista = new List<PrenumerantDetalj>();
            HttpResponseMessage response =  _client.GetAsync(_client.BaseAddress + "/Prenumerant/getPrenumeranter").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                prenumerantLista = JsonConvert.DeserializeObject<List<PrenumerantDetalj>>(data);
            }
            return View(prenumerantLista);
        }

        // Hämtar en prenumerant via prenumerationsnummer.
        public IActionResult GetPrenumerant(int prenumerationsnummer)
        {
            PrenumerantDetalj prenumerant = null;
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/Prenumerant/GetPrenumerantByPn?prenumerationsnummer={prenumerationsnummer}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                prenumerant = JsonConvert.DeserializeObject<PrenumerantDetalj>(data);
            }
            return View(prenumerant);
        }


        public IActionResult Privacy()
        {
            return View();
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // Per video lösning:
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