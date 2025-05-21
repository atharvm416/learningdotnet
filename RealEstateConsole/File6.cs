using System;
using RealEstateService;

public static class File6
{
    public static void Run()
    {
        Console.WriteLine("Running File6 - Combined Test");

        var calculator = new StandardCommissionCalculator(0.05m);
        var validator = new SimplePropertyValidator();

        var property = new RealEstateAsset(calculator, validator)
        {
            SalePrice = 300000m,
            AgencyName = "Skyline Realty"
        };

        Console.WriteLine($"Agency: {property.AgencyName}");
        Console.WriteLine($"Valid? {property.IsAgencyValid()}");
        Console.WriteLine($"Commission: {property.GetCommission()}");
        Console.WriteLine($"Tax: {property.CalculateTax()}");

        Console.WriteLine("\n--- Tests ---");
        Console.WriteLine(property.CalculateTax() == 30000m ? "PASS: Tax" : "FAIL: Tax");
        Console.WriteLine(property.IsAgencyValid() ? "PASS: Validator" : "FAIL: Validator");
    }
}
