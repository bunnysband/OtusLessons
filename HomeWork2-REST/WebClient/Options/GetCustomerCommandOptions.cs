using CommandLine;

namespace WebClient.Options
{
    [Verb("get-customer", HelpText = "Get customer by Id")]
    internal class GetCustomerCommandOptions
    {
        [Option('i', "id", Required = true, HelpText = "Customer Id")]
        public string Id { get; set; }
    }
}
