using System;
using VehicleApp;
using ReflectionExample;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter 1 to run File1, Enter 2 to run File2, Enter 3 to run File3, Enter 4 to run File4, Enter 5 to run File5, Enter 6 to run File6:");
        string input = Console.ReadLine();

        if (input == "1")
        {
            File1.Run(); // Day 3 SOLID Principle
        }
        else if (input == "2")
        {
            File2.Run(); // Demonstrating Delegates and Extension Methods
        }
        else if (input == "3")
        {
            File3.Run(); // Day 2 Abstract class code
        }
        else if (input == "4")
        {
            File4.Run(); // Day 4 Reflection, Exception handling, and Logging
        }
        else if (input == "5")
        {
            await File5.Run(); //Day 5 Running an async method
        }
        else if (input == "6")
        {
            File6.Run(); // Day 6 and 7 Architecture & Testability
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
