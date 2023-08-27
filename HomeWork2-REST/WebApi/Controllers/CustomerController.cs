using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id:long}")]   
        public async Task<ActionResult<Customer>> GetCustomerAsync([FromRoute] long id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            return customer is null ? NotFound() : Ok(customer);
        }

        [HttpPost("")]   
        public async Task<ActionResult<long>> CreateCustomerAsync([FromBody] Customer customer)
        {
            var existedCustomer = await _customerRepository.GetCustomerAsync(customer.Id);

            if (existedCustomer is not null)
            {
                return Conflict($"Customer with Id {customer.Id} already exist");
            }
            else
            {
                var createdCustomer = await _customerRepository.CreateCustomerAsync(customer);
                return Ok(createdCustomer);
            }
        }
    }
}