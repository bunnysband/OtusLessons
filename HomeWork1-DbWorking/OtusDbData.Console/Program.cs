using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OtusDbData.Data;
using OtusDbData.Data.Impl;
using OtusDbData.Service;
using OtusDbData.Service.DTO;
using OtusDbData.Service.Exceptions;
using OtusDbData.Service.Impl;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IOtusDataProvider, OtusDbDataProvider>();
builder.Services.AddScoped<IDataRepository, OtusDataDbRepository>();
builder.Services.AddSingleton<DbContext, OtusDataDbContext>();
builder.Services.AddAutoMapper(typeof(OtusDbDataProfile));
var connectionString = builder.Configuration.GetConnectionString("PostgresOtusDb");
builder.Services.AddDbContext<OtusDataDbContext>(options =>
{
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("OtusDbData.Console"));
});

using IHost host = builder.Build();

if (args.Length == 0)
{
    GetAllLessons();
    GetAllCourses();
    GetAllUsers();
}
else
{
    var command = args[0];

    switch (command)
    {
        case "add-user":
            AddUser(args[1], args[2], args[3]);
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}

await host.RunAsync();

void AddUser(string email, string firstName, string lastName)
{
    var user = new UserDto { FirstName = firstName, LastName = lastName, Email = email };
    var dataService = host.Services.GetService<IOtusDataProvider>()!;
    try
    {
        dataService.AddUser(user);
        var createdUser = dataService.GetAllUsers().Single(u => u.Email == email);
        Console.WriteLine($"Created new user: Id - {user.Id}, user name - {user.FirstName} {user.LastName}, nick - {user.NickName}");
    }
    catch (AddUserException e)
    {
        Console.WriteLine(e.Message);
    }
}

void GetAllLessons()
{
    var lessons = host.Services.GetService<IOtusDataProvider>()?.GetAllLessons();
    Console.WriteLine("Lessons:");
    foreach (var lesson in lessons)
    {
        Console.WriteLine($"Id - {lesson.Id}, lesson name - {lesson.Name}, course - {lesson.Course.Name}");
    }
}

void GetAllCourses()
{
    var courses = host.Services.GetService<IOtusDataProvider>()?.GetAllCourses();
    Console.WriteLine("Courses:");
    foreach (var course in courses)
    {
        Console.WriteLine($"Id - {course.Id}, course name - {course.Name}, level - {course.Level}, created by - {course.CreatedBy.FirstName} {course.CreatedBy.LastName}");
    }
}

void GetAllUsers()
{
    var users = host.Services.GetService<IOtusDataProvider>()?.GetAllUsers();
    Console.WriteLine("Users:");
    foreach (var user in users)
    {
        Console.WriteLine($"Id - {user.Id}, user name - {user.FirstName} {user.LastName}, nick - {user.NickName}");
    }
}