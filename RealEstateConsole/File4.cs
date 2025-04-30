using System;
using System.IO;
using System.Reflection;

namespace ReflectionExample
{
    class File4
    {
        public static void Run()
        {
            // Load the assembly (current executing assembly in this case)
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Inspect the assembly
            Console.WriteLine("Inspecting Assembly:");
            Console.WriteLine($"Assembly Name: {assembly.FullName}");
            Console.WriteLine($"Location: {assembly.Location}");
            Console.WriteLine();

            // Get all types in the assembly
            Type[] types = assembly.GetTypes();
            Console.WriteLine("Types in the Assembly:");
            foreach (Type type in types)
            {
                Console.WriteLine($"Type: {type.Name}");

                // Inspect properties of the type
                Console.WriteLine("  Properties:");
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine($"    Property: {property.Name}, Type: {property.PropertyType.Name}");
                }

                // Inspect methods of the type
                Console.WriteLine("  Methods:");
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"    Method: {method.Name}, Return Type: {method.ReturnType.Name}");
                }

                // Inspect attributes of the type
                Console.WriteLine("  Attributes:");
                object[] attributes = type.GetCustomAttributes(true);
                foreach (object attribute in attributes)
                {
                    Console.WriteLine($"    Attribute: {attribute.GetType().Name}");
                }

                Console.WriteLine();
            }

            // Test custom exception and logging
            try
            {
                Property property = new Property { Price = -100 }; // This will throw InvalidPropertyException
            }
            catch (InvalidPropertyException ex)
            {
                Logger.Log(ex); // Log the exception
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
        }
    }

    // Custom Exception: InvalidPropertyException
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException(string message) : base(message) { }
    }

    // Example class to demonstrate custom exception
    public class Property
    {
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidPropertyException("Price must be greater than 0.");
                }
                _price = value;
            }
        }
    }

    // Basic File Logger
    public static class Logger
    {
        private static readonly string LogFilePath = "log.txt";

        public static void Log(Exception ex)
        {
            string logMessage = $"[{DateTime.Now}] Exception: {ex.Message}\nStack Trace: {ex.StackTrace}\n\n";

            // Append the log message to the log file
            File.AppendAllText(LogFilePath, logMessage);
        }
    }

    // Example class with properties, methods, and attributes
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }

    // Another example class
    public class Employee : Person
    {
        public string Department { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working in the {Department} department.");
        }
    }
}