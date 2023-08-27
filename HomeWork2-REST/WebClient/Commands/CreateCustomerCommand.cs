using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient.Commands
{
    internal class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public CreateCustomerCommand(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateCustomerAsync()
        {
            var client = _httpClientFactory.CreateClient();
            string customersUrl = _configuration.GetSection("Urls")["Customers"];

            var result = await client.PostAsync(customersUrl, JsonContent.Create(CreateRandomCustomerRequest()));

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var customer = result.Content.ReadFromJsonAsync<Customer>().Result;
                Console.WriteLine($"Got customer: id = {customer.Id}, full name = {customer.Firstname} {customer.Lastname}");
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        private static CustomerCreateRequest CreateRandomCustomerRequest()
        {
            var random = new Random();
            string randomFirstName = $"FirstName{random.Next()}";
            string randomLastName = $"LastName{random.Next()}";
            return new CustomerCreateRequest(randomFirstName, randomLastName);
        }
    }
}
