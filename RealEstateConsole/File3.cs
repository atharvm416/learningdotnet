using System;

namespace VehicleApp
{
    // Abstract class as a blueprint for vehicles
    abstract class Vehicle
    {
        public int NumberOfPassengers { get; set; }
        public string EngineType { get; set; } = string.Empty; // Default to empty string

        // Abstract method (must be implemented by derived classes)
        public abstract int GetNumberOfTyres();

        // Instance method to display details
        public void DisplayDetails()
        {
            Console.WriteLine($"Passengers: {NumberOfPassengers}, Engine: {EngineType}, Tyres: {GetNumberOfTyres()}");
        }
    }

    // Derived class: Bike
    class Bike : Vehicle
    {
        public Bike(int numberOfPassengers, string engineType)
        {
            this.NumberOfPassengers = numberOfPassengers;
            this.EngineType = engineType;
        }

        public override int GetNumberOfTyres() => 2; // Specific to Bike
    }

    // Derived class: Car
    class Car : Vehicle
    {
        public Car(int numberOfPassengers, string engineType)
        {
            this.NumberOfPassengers = numberOfPassengers;
            this.EngineType = engineType;
        }

        public override int GetNumberOfTyres() => 4; // Specific to Car
    }

    // Static Utility Class for Tax Calculation
    static class Utility
    {
        public static void CalculateTax(ref decimal price, out decimal taxAmount)
        {
            taxAmount = price * 0.1m; // 10% tax
            price += taxAmount;       // Adjust original price with tax
        }
    }

    // DisplayManager to demonstrate static methods
    static class DisplayManager
    {
        // Static method to display vehicle info
        public static void ShowVehicleInfo(Vehicle vehicle)
        {
            Console.WriteLine("---- Vehicle Info ----");
            vehicle.DisplayDetails();
        }

        // Static method to demonstrate tax calculation
        public static void ShowPriceWithTax(decimal price)
        {
            decimal taxAmount;
            Utility.CalculateTax(ref price, out taxAmount);

            Console.WriteLine($"Final Price (with tax): {price:C} | Tax Amount: {taxAmount:C}");
        }
    }

    // Main Program
    class File3
    {
        public static void Run()
        {
            // Creating Vehicle objects
            Vehicle bike = new Bike(2, "Petrol");
            Vehicle car = new Car(5, "Diesel");

            // Displaying vehicle information
            DisplayManager.ShowVehicleInfo(bike);
            DisplayManager.ShowVehicleInfo(car);

            // Demonstrating `ref` and `out` for price calculation
            Console.WriteLine("\n-- Price Calculation --");
            decimal bikePrice = 50000m;
            decimal carPrice = 100000m;

            DisplayManager.ShowPriceWithTax(bikePrice);
            DisplayManager.ShowPriceWithTax(carPrice);
        }
    }
}
