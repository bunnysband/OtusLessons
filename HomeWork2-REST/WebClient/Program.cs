using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WebClient.Commands;
using WebClient.Options;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();
            builder.Services.AddScoped<IGetCustomerCommand, GetCustomerCommand>();
            builder.Services.AddHttpClient();
            IHost host = builder.Build();

            Parser.Default.ParseArguments<GetCustomerCommandOptions, CreateCustomerCommandOptions>(args)
                .WithParsed<GetCustomerCommandOptions>(
                async (options) =>  
            {
                await host.Services.GetService<IGetCustomerCommand>()!.GetCustomerAsync(options.Id);
            })
                .WithParsed<CreateCustomerCommandOptions>(
            async (options) =>
            {
                await host.Services.GetService<ICreateCustomerCommand>()!.CreateCustomerAsync();
            });

            await host.RunAsync();
        }
    }
}