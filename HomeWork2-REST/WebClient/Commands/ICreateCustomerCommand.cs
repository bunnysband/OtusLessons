using System.Threading.Tasks;

namespace WebClient.Commands
{
    internal interface ICreateCustomerCommand
    {
        Task CreateCustomerAsync();
    }
}
