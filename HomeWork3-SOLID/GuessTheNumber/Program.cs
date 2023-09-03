using GuessTheNumber;
using GuessTheNumber.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<INumberValidator, MoreLessNumberValidator>();
builder.Services.AddSingleton<INumberGenerator, RandomNumberGenerator>();
builder.Services.AddSingleton<ISettingsProvider, ConfigSettingsProvider>();

using IHost host = builder.Build();

var settings = host.Services.GetRequiredService<ISettingsProvider>().GetSettings();

INumberValidator numberValidator = host.Services.GetRequiredService<INumberValidator>();
Console.WriteLine($"Try to guess number from {settings.MinNumberLimit} to {settings.MaxNumberLimit} in {settings.AttemptsLimit} attempts:");
var currentTry = 1;

do
{
    Console.WriteLine($"Attempt {currentTry}:");
    if (int.TryParse(Console.ReadLine(), out int enteredNumber))
    {
        if (numberValidator.IsValid(enteredNumber, out string message))
        {
            Console.WriteLine($"{message}");
            Console.WriteLine($"Game over. You win");
            return;
        }
        Console.WriteLine($"{message}");
        currentTry++;
    }
    else
    {
        Console.WriteLine("Incorrect number");
        currentTry++;
    }
} while (currentTry <= settings.AttemptsLimit);

Console.WriteLine("Game over. You loose");

host.Run();