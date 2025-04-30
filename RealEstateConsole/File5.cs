using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
class File5
{
    public static async Task Run()
    {
        // Creating a list of integers
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Adding items
        numbers.Add(6);
        numbers.AddRange(new[] { 7, 8, 9 });

        // Accessing items
        int first = numbers[0]; // Index starts at 0
        Console.WriteLine("First element: " + first); 

        // Removing items
        numbers.Remove(3); // Removes the number 3 (if found)
        numbers.RemoveAt(0); // Removes first item (1)

        // Iterating through the list
        Console.WriteLine("Updated List:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        //check code foe string
        List<string> stringsname = new List<string> {"a", "b", "C"};
        Console.WriteLine("String Names: " + string.Join(", ", stringsname));
        foreach(string a in stringsname){
            Console.Write("Seperate :" +a);
        }

        // Creating a dictionary of string keys and int values
        Dictionary<string, int> ages = new Dictionary<string, int>
        {
            ["Alice"] = 25,
            ["Bob"] = 30
        };

        // Adding items
        ages["Charlie"] = 28;
        ages.Add("David", 35);

        // Accessing items
        int aliceAge = ages["Alice"];

        // Checking if key exists
        if (ages.ContainsKey("Eve"))
        {
            Console.WriteLine("Eve's age: " + ages["Eve"]);
        }

        if (ages.ContainsValue(35)){
            Console.WriteLine("Value 35 found");
        }

        // Iterating
        foreach (KeyValuePair<string, int> entry in ages)
        {
            Console.WriteLine($"{entry.Key} is {entry.Value} years old");
        }


        //LINQ
        // LINQ provides methods to query collections in a SQL-like manner.

        // IEnumerable<T> is an interface that represents a sequence of elements that can be iterated over.
        // It supports lazy evaluation, meaning elements are retrieved only when needed.
        // Commonly returned by LINQ methods like .Where(), .Select(), and .GroupBy().
        // It does not support indexing (e.g., numbers[0] is not possible).
        // It is read-only, so you cannot modify elements directly.
        // Useful for working with large datasets efficiently without loading everything into memory.

        List<int> numberslinq = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Filtering with Where
        var evenNumberslinq = numberslinq.Where(n => n % 2 == 0);
        Console.WriteLine("Filtering with Where: " + string.Join(", ", evenNumberslinq));

        // Selecting with Select
        var squares = numberslinq.Select(n => n * n);
        Console.WriteLine("Selecting with Select: " + string.Join(", ", squares));

        // Grouping with GroupBy
        var numberGroups = numberslinq.GroupBy(n => n % 3);
        Console.WriteLine("Grouping with GroupBy:");
        foreach (var group in numberGroups)
        {
            Console.WriteLine($"  Remainder {group.Key}: {string.Join(", ", group)}");
        }

        // Ordering
        var orderedNumberslinq = numberslinq.OrderBy(n => n);
        var descendingNumberslinq = numberslinq.OrderByDescending(n => n);
        Console.WriteLine("Ascending: " + string.Join(", ", orderedNumberslinq));
        Console.WriteLine("Descending: " + string.Join(", ", descendingNumberslinq));

        // Aggregation
        int sum = numberslinq.Sum();
        int max = numberslinq.Max();
        double average = numberslinq.Average();

        Console.WriteLine($"Sum: {sum}, Max: {max}, Average: {average}");



        //Async / Await

        // Fetch properties asynchronously
        var properties = await FetchPropertiesAsync();

        Console.WriteLine("Properties retrieved:");
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.Address} - ${property.Price}");
        }
    }

public static async Task<List<Property>> FetchPropertiesAsync()
    {
        Console.WriteLine("Simulating database/network delay...");
        await Task.Delay(2000); // Simulates a delay of 2 seconds

        // Return a list of properties after delay
        return new List<Property>
        {
            new Property { Address = "123 Main St", Price = 250000 },
            new Property { Address = "456 Oak St", Price = 180000 },
            new Property { Address = "789 Pine St", Price = 320000 }
        };
    }

}

class Property
{
    public string Address { get; set; }
    public decimal Price { get; set; }
}