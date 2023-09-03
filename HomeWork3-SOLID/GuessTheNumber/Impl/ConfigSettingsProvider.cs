using Microsoft.Extensions.Configuration;

namespace GuessTheNumber.Impl;

internal class ConfigSettingsProvider : ISettingsProvider
{
    private readonly IConfiguration _configuration;
    public ConfigSettingsProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Settings GetSettings()
    {
        return new Settings(
            _configuration.GetSection("NumberLimits").GetValue<int>("Min"),
            _configuration.GetSection("NumberLimits").GetValue<int>("Max"),
            _configuration.GetValue<int>("TryCount"));
    }
}
