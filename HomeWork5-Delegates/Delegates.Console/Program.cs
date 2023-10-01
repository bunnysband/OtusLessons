using Delegates.Console;
using Delegates.Console.FileFinder;
using Delegates.Console.FileFinder.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IFileFinder, DirectoryFilesFinder>();
builder.Services.AddTransient<IWorker, FileWorker>();
builder.Services.AddSingleton<MaxEntryDelegateWorking>();
builder.Services.AddSingleton<FilesFoundEventWorking>();

using IHost host = builder.Build();


host.Services.GetRequiredService<MaxEntryDelegateWorking>().Show();
host.Services.GetRequiredService<FilesFoundEventWorking>().Show();


await host.RunAsync();