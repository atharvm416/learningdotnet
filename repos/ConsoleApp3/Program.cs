using Applicationcreation.Models;
using Applicationcreation.Services;
using ConsolerefDI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        var Entensionfile = new Extensionfile();

        var configuration = Entensionfile.GetMainBaseConfig();

        var services = new ServiceCollection()
            .AddSingleton(configuration)
            .AddTransient<TokenService>()
            .BuildServiceProvider();

        var tokenService = services.GetRequiredService<TokenService>();
        var user = new User
        {
            Id = 6,
            Email = "test@gmail.com",
            Role = new Role { Name = "User" }
        };

        var token = tokenService.GenerateJwtToken(user);

        Console.WriteLine("Generated Token:");
        Console.WriteLine(token);



        //// Load configuration
        //var config = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        //var user = new User
        //{
        //    Id = 1,
        //    Email = "test@example.com",
        //    Role = new Role { Name = "Admin" }
        //};

        ////Initialize and use TokenService
        //var tokenService = new TokenService(config);
        //var token = tokenService.GenerateJwtToken(user);
    }
}