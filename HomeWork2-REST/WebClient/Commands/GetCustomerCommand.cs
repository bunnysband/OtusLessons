using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient.Commands
{
    internal class GetCustomerCommand : IGetCustomerCommand
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public GetCustomerCommand(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetCustomerAsync(string customerId)
        {
            var client = _httpClientFactory.CreateClient();
            string customersUrl = _configuration.GetSection("Urls")["Customers"];

            var result = await client.GetAsync($"{customersUrl}/{customerId}");

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
    }
}
