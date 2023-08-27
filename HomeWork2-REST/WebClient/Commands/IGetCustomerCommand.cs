using System.Threading.Tasks;

namespace WebClient.Commands
{
    internal interface IGetCustomerCommand
    {
        Task GetCustomerAsync(string customerId);
    }
}
