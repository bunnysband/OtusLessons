using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface ICustomerRepository
    {  
        public Task<Customer> GetCustomerAsync(long customerId);
        public Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
