using CustomerVehicles.Helper;
using CustomerVehicles.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerVehicles.Controllers
{
    public class CustomerController : Controller
    {
        CustomerAPI _CustomerAPI = new CustomerAPI();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Customers()
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
    }
}
