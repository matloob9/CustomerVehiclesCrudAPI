using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CustomerVehiclesCrudAPI.Models;
using Xunit;
using CustomerVehiclesCrudAPI;

namespace CustomerVehiclesCrudAPITest
{
    public class VehicleTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public VehicleTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetVehicleItemsAsync()
        {
            // Arrange
            var request = "/api/Vehicle";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetVehicleItemAsync()
        {
            // Arrange
            var request = "/api/Vehicle/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostVehicleItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Vehicle",
                Body = new
                {
                  vin= "Test13124",
                  regNumber= "TestReg123",
                  customerFk= 2,
                  isConnected= true,
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutVehicleItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Vehicle/8",
                Body = new
                {
                    Id = 8,
                    vin = "Test1232124",
                    regNumber = "TestReg123",
                    customerFk = 2,
                    isConnected = false,

                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

       
    }
}