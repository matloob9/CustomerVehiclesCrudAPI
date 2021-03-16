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
        VehicleAPI _VehicleAPI = new VehicleAPI();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
            {
            List<Customer> Customers = new List<Customer>();
            List<Vehicle> Vehicles = new List<Vehicle>();

                HttpClient client = _CustomerAPI.Intial();
                HttpResponseMessage res = await client.GetAsync("api/Customer");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    Customers = JsonConvert.DeserializeObject<List<Customer>>(results);
                }


            HttpClient vclient = _VehicleAPI.Intial();
            HttpResponseMessage Vres = await vclient.GetAsync("api/Vehicle");
            if (Vres.IsSuccessStatusCode)
            {
                var results = Vres.Content.ReadAsStringAsync().Result;
                Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(results);
            }
            for (int i = 0; i < Vehicles.Count; i++)
            {
                Vehicle item = Vehicles[i];
                int CustomerID = item.CustomerFk;

                HttpClient Cclient = _CustomerAPI.Intial();
                HttpResponseMessage Cres = await Cclient.GetAsync("api/Customer/"+ CustomerID);
                if (Cres.IsSuccessStatusCode)
                {
                    var results = Cres.Content.ReadAsStringAsync().Result;
                    Customer CustomerValue = JsonConvert.DeserializeObject<Customer>(results);
                    Vehicles[i].CustomerName = CustomerValue.CustomerName;
                }

            }

            return View(Vehicles);
            }

        public async Task<IActionResult> Details(int Id)
        {
            List<Customer> Customers = new List<Customer>();
            Vehicle VehicleData = new Vehicle();

            HttpClient client = _CustomerAPI.Intial();
            HttpResponseMessage res = await client.GetAsync("api/Customer");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                Customers = JsonConvert.DeserializeObject<List<Customer>>(results);
            }


            HttpClient vclient = _VehicleAPI.Intial();
            HttpResponseMessage Vres = await vclient.GetAsync($"api/Vehicle/{Id}");
            if (Vres.IsSuccessStatusCode)
            {
                var results = Vres.Content.ReadAsStringAsync().Result;
                VehicleData = JsonConvert.DeserializeObject<Vehicle>(results);
            }
           
                int CustomerID = VehicleData.CustomerFk;

                HttpClient Cclient = _CustomerAPI.Intial();
                HttpResponseMessage Cres = await Cclient.GetAsync("api/Customer/" + CustomerID);
                if (Cres.IsSuccessStatusCode)
                {
                    var results = Cres.Content.ReadAsStringAsync().Result;
                    Customer CustomerValue = JsonConvert.DeserializeObject<Customer>(results);
                    VehicleData.CustomerName = CustomerValue.CustomerName;
                }

            

            return View(VehicleData);
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
