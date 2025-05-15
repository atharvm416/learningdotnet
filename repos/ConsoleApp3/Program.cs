using System;
using Microsoft.Extensions.Configuration;
using Applicationcreation.Services;
using Applicationcreation.Models;

class Program
{
    static void Main(string[] args)
    {
        // Load configuration
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var user = new User
        {
            Id = 6,
            Email = "test@gmail.com",
            Role = new Role { Name = "Admin" }
        };

        //Initialize and use TokenService
        var tokenService = new TokenService(config);
        var token = tokenService.GenerateJwtToken(user);

        Console.WriteLine("Generated Token:");
        Console.WriteLine(token);
    }
}