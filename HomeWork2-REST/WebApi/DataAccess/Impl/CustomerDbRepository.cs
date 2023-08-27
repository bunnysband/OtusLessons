using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess.Impl
{
    public class CustomerDbRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;
        public CustomerDbRepository(CustomerDbContext customerDbContext) 
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var newCustomer = await _customerDbContext.Customers.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
            return newCustomer.Entity;
        }

        public async Task<Customer> GetCustomerAsync(long customerId)
            => await _customerDbContext.Customers.FindAsync(customerId);
    }
}
