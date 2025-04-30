using System;

namespace VehicleApp
{
    public static class File2
    {
        public static void Run()
        {
            Console.WriteLine("Running File2: Demonstrating Delegates and Extension Methods");

            // Delegate Example
            Console.WriteLine("\n1. Delegate Example:");

            decimal saleAmount = 1000.00m;

            // Calculate normal commission
            CommissionDelegate normalCommission = CommissionCalculator.CalculateNormalCommission;
            CommissionCalculator.PrintCommission(saleAmount, normalCommission);

            // Calculate premium commission
            CommissionDelegate premiumCommission = CommissionCalculator.CalculatePremiumCommission;
            CommissionCalculator.PrintCommission(saleAmount, premiumCommission);

            // Extension Method Example
            Console.WriteLine("\n2. Extension Method Example:");

            string agencyName1 = "Sunshine Realty";
            string agencyName2 = "Best Homes";

            Console.WriteLine($"Is '{agencyName1}' a valid agency name? {agencyName1.IsValidAgencyName()}");
            Console.WriteLine($"Is '{agencyName2}' a valid agency name? {agencyName2.IsValidAgencyName()}");
        }
    }

    // Delegate Definition
    public delegate decimal CommissionDelegate(decimal saleAmount);

    // Commission Calculator Class
    public class CommissionCalculator
    {
        // Normal commission rate (5%)
        public static decimal CalculateNormalCommission(decimal saleAmount)
        {
            return saleAmount * 0.05m;
        }

        // Premium commission rate (10%)
        public static decimal CalculatePremiumCommission(decimal saleAmount)
        {
            return saleAmount * 0.10m;
        }

        // Method that accepts the delegate
        public static void PrintCommission(decimal saleAmount, CommissionDelegate commissionDelegate)
        {
            decimal commission = commissionDelegate(saleAmount);
            Console.WriteLine($"Commission for sale amount {saleAmount:C}: {commission:C}");
        }
    }

    // Extension Method Class
    public static class StringExtensions
    {
        public static bool IsValidAgencyName(this string agencyName)
        {
            return agencyName.Contains("Realty", StringComparison.OrdinalIgnoreCase);
        }
    }
}