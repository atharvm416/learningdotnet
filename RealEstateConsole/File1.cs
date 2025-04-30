using System;

namespace VehicleApp
{
    public static class File1
    {
        public static void Run()
        {
            Console.WriteLine("Running File1: Demonstrating SOLID Principles");

            // Single Responsibility Principle (SRP)
            Console.WriteLine("\n1. Single Responsibility Principle (SRP):");
            Report report = new Report();
            report.GenerateReport();

            ReportSaver reportSaver = new ReportSaver();
            reportSaver.SaveToFile("report.txt");

            // Open/Closed Principle (OCP)
            Console.WriteLine("\n2. Open/Closed Principle (OCP):");
            Shape rectangle = new Rectangle { Width = 10, Height = 5 };
            Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea()}");

            Shape circle = new Circle { Radius = 7 };
            Console.WriteLine($"Area of Circle: {circle.CalculateArea()}");

            // Liskov Substitution Principle (LSP)
            Console.WriteLine("\n3. Liskov Substitution Principle (LSP):");
            Bird sparrow = new Sparrow();
            sparrow.Move();

            Bird ostrich = new Ostrich();
            ostrich.Move();

            // Interface Segregation Principle (ISP)
            Console.WriteLine("\n4. Interface Segregation Principle (ISP):");
            HumanWorker humanWorker = new HumanWorker();
            humanWorker.Work();
            humanWorker.Eat();

            RobotWorker robotWorker = new RobotWorker();
            robotWorker.Work();

            // Dependency Inversion Principle (DIP)
            Console.WriteLine("\n5. Dependency Inversion Principle (DIP):");
            IMessageService emailService = new EmailService();
            Notification notification = new Notification(emailService);
            notification.Notify("Hello, this is a notification!");
        }

        // Single Responsibility Principle (SRP)
        public class Report
        {
            public void GenerateReport()
            {
                Console.WriteLine("Generating report...");
            }
        }

        public class ReportSaver
        {
            public void SaveToFile(string filePath)
            {
                Console.WriteLine($"Saving report to {filePath}...");
            }
        }

        // Open/Closed Principle (OCP)
        public abstract class Shape
        {
            public abstract double CalculateArea();
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public override double CalculateArea()
            {
                return Width * Height;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public override double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        // Liskov Substitution Principle (LSP)
        public abstract class Bird
        {
            public abstract void Move();
        }

        public class Sparrow : Bird
        {
            public override void Move()
            {
                Console.WriteLine("Sparrow is flying...");
            }
        }

        public class Ostrich : Bird
        {
            public override void Move()
            {
                Console.WriteLine("Ostrich is running...");
            }
        }

        // Interface Segregation Principle (ISP)
        public interface IWorkable
        {
            void Work();
        }

        public interface IEatable
        {
            void Eat();
        }

        public class HumanWorker : IWorkable, IEatable
        {
            public void Work()
            {
                Console.WriteLine("Human is working...");
            }

            public void Eat()
            {
                Console.WriteLine("Human is eating...");
            }
        }

        public class RobotWorker : IWorkable
        {
            public void Work()
            {
                Console.WriteLine("Robot is working...");
            }
        }

        // Dependency Inversion Principle (DIP)
        public interface IMessageService
        {
            void SendMessage(string message);
        }

        public class EmailService : IMessageService
        {
            public void SendMessage(string message)
            {
                Console.WriteLine($"Sending email: {message}");
            }
        }

        public class Notification
        {
            private readonly IMessageService _messageService;

            public Notification(IMessageService messageService)
            {
                _messageService = messageService;
            }

            public void Notify(string message)
            {
                _messageService.SendMessage(message);
            }
        }
    }
}
// Summary of SOLID Principles:
//
// 1. Single Responsibility Principle (SRP):
//    - Key Idea: A class should have only one reason to change.
//    - Benefit: Easier to understand, test, and maintain.
//    - Example: A `Report` class should only generate reports, and a `ReportSaver` class should handle saving reports.
//    - Pitfall: A class that handles both report generation and saving violates SRP.
//    - Best Practice: Break down large classes into smaller, focused classes.
//
// 2. Open/Closed Principle (OCP):
//    - Key Idea: Classes should be open for extension but closed for modification.
//    - Benefit: Reduces risk of introducing bugs in existing code.
//    - Example: Use abstract classes or interfaces to allow new shapes (e.g., `Circle`, `Rectangle`) without modifying existing code.
//    - Pitfall: Adding new functionality by modifying existing classes can introduce bugs.
//    - Best Practice: Use inheritance, polymorphism, and interfaces to extend behavior.
//
// 3. Liskov Substitution Principle (LSP):
//    - Key Idea: Subclasses should be substitutable for their base classes.
//    - Benefit: Promotes polymorphism and code reusability.
//    - Example: A `Sparrow` and `Ostrich` should both be able to replace a `Bird` without breaking the program.
//    - Pitfall: Overriding methods in a subclass to throw exceptions or change behavior violates LSP.
//    - Best Practice: Ensure derived classes adhere to the contract defined by the base class.
//
// 4. Interface Segregation Principle (ISP):
//    - Key Idea: Clients should not be forced to depend on interfaces they don’t use.
//    - Benefit: Reduces complexity and prevents unnecessary method implementations.
//    - Example: Split a large `IWorker` interface into `IWorkable` and `IEatable` so `RobotWorker` doesn’t need to implement `Eat`.
//    - Pitfall: Large interfaces force classes to implement methods they don’t need.
//    - Best Practice: Create small, specific interfaces tailored to client needs.
//
// 5. Dependency Inversion Principle (DIP):
//    - Key Idea: Depend on abstractions, not concrete implementations.
//    - Benefit: Promotes loose coupling and makes the system more flexible and testable.
//    - Example: A `Notification` class should depend on an `IMessageService` interface, not a concrete `EmailService`.
//    - Pitfall: Tightly coupling high-level modules to low-level modules makes the system rigid.
//    - Best Practice: Use dependency injection to pass abstractions (e.g., interfaces) to classes.
//
// By following these principles, you can build modular, scalable, and maintainable software.