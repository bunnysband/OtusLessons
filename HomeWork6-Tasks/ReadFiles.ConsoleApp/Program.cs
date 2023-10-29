using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadFiles.ConsoleApp;
using ReadFiles.ConsoleApp.Impl;
using System.Diagnostics;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<ISpaceCounter, RegexpSpaceCounter>();
builder.Services.AddTransient<IDirectoryWorker, ParallelFilesReadWorker>();

using IHost host = builder.Build();

var directoryToWork = args.Any() ? args[0] : Directory.GetCurrentDirectory();
var directoryWorker = host.Services.GetRequiredService<IDirectoryWorker>();

Stopwatch stopwatch = Stopwatch.StartNew();
directoryWorker.Work(directoryToWork);
stopwatch.Stop();
Console.WriteLine($"Working time: {stopwatch.ElapsedMilliseconds}");

await host.RunAsync();
