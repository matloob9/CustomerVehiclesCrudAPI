using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VehicleCrudAPI.Models;
using Xunit;
using VehicleCrudAPI;

namespace VehicleCrudAPITest
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
            DateTime CDate = DateTime.Now;

            var request = new
            {
                Url = "/api/Vehicle",
                Body = new
                {
                  vin= "Testqwq13124",
                  regNumber= "TestReg123",
                  customerFk= 2,
                  isConnected= true,
                  LastUpdatedDate= CDate,
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
            DateTime CDate = DateTime.Now;

            var request = new
            {
                Url = "/api/Vehicle/1002",

                Body = new
                {
                    Id = 1002,
                    vin = "Tessst1232124",
                    regNumber = "TestReg123",
                    customerFk = 2,
                    isConnected = false,
                    LastUpdatedDate= CDate
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

       
    }
}