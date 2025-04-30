using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your name?");
        string? name = Console.ReadLine();

        Console.WriteLine("What is your age?");
        string age = Console.ReadLine();;
        // if (!int.TryParse(Console.ReadLine(), out age))
        // {
        //     age = 22; // Default age if invalid input
        // }
        int a = Convert.ToInt32(age);

        Console.WriteLine($"Hello, {name ?? "Guest"}! Your age is {a}.");
    }
}
