using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CustomerVehiclesCrudAPI.Models;
using Xunit;
using CustomerVehiclesCrudAPI;

namespace CustomerVehiclesCrudAPITest
{
    public class CustomerTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CustomerTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCustomertemsAsync()
        {
            // Arrange
            var request = "/api/Customer";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetCustomertemAsync()
        {
            // Arrange
            var request = "/api/Customer/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostCustomertemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Customer",
                Body = new
                {
                      customerName= "Ahmed Matloub",
                      address="Egypt Cairo",
                      
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutCustomertemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Customer/4",
                Body = new
                {
                    Id=4,
                    customerName = "Ahmed Mostafa Matloub",
                    address = "Egypt Cairo",


                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }


    }
}