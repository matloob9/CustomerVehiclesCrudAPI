using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CustomerVehicles.Helper
{
    public class CustomerAPI
    {
        public HttpClient Intial()
        {
            string CustomerAPIcn = "https://localhost:6838";
            var client = new HttpClient();
            
            client.BaseAddress = new Uri(CustomerAPIcn);
            return client;
        }
    }

    public class VehicleAPI
    {
        public HttpClient Intial()
        {
            string VehicleAPIcn = "https://localhost:55838";
            var client = new HttpClient();
            
            client.BaseAddress = new Uri(VehicleAPIcn);
            return client;
        }
    }
}
