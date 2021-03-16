using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerVehicles.Models;
using System.Net.Http;
using Newtonsoft.Json;
using CustomerVehicles.Helper;

namespace CustomerVehicles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CustomerAPI _CustomerAPI = new CustomerAPI();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
            {
                List<Customer> Customers = new List<Customer>();
                HttpClient client = _CustomerAPI.Intial();
                HttpResponseMessage res = await client.GetAsync("api/Customer");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    Customers = JsonConvert.DeserializeObject<List<Customer>>(results);
                }
                return View(Customers);
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
    }
}
