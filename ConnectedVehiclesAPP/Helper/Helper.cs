using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace ConnectedVehiclesAPP.Helper
{
    public class CustomerAPI
    {
        public HttpClient Intial()
        {
            string CustomerAPIcn = "https://localhost:6837/";
            var client = new HttpClient();
            
            client.BaseAddress = new Uri(CustomerAPIcn);
            return client;
        }
    }

    public class VehicleAPI
    {
        public HttpClient Intial()
        {
            string VehicleAPIcn = "https://localhost:55839/";
            var client = new HttpClient();
            
            client.BaseAddress = new Uri(VehicleAPIcn);
            return client;
        }
    }
}
