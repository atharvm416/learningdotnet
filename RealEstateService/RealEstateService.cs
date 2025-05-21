using System;

namespace RealEstateService
{
    public interface ICommissionCalculator
    {
        decimal CalculateCommission(decimal salePrice);
    }

    public interface IPropertyValidator
    {
        bool IsValidAgencyName(string agencyName);
    }

    public class StandardCommissionCalculator : ICommissionCalculator
    {
        private readonly decimal _rate;
        public StandardCommissionCalculator(decimal rate) => _rate = rate;

        public decimal CalculateCommission(decimal salePrice) => salePrice * _rate;
    }

    public class SimplePropertyValidator : IPropertyValidator
    {
        public bool IsValidAgencyName(string agencyName)
        {
            return !string.IsNullOrWhiteSpace(agencyName) && agencyName.Length >= 3;
        }
    }

    // Your old Property class (if you want to keep it)
    public class Property
    {
        public string AgencyName { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }

        private readonly ICommissionCalculator _calculator;
        private readonly IPropertyValidator _validator;

        public Property(ICommissionCalculator calculator, IPropertyValidator validator)
        {
            _calculator = calculator;
            _validator = validator;
        }

        public decimal CalculateTax() => SalePrice * 0.1m;
        public bool IsAgencyValid() => _validator.IsValidAgencyName(AgencyName);
        public decimal GetCommission() => _calculator.CalculateCommission(SalePrice);
    }

    // Now this is a **separate** class, not nested inside Property
    public class RealEstateAsset
    {
        public string AgencyName { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }

        private readonly ICommissionCalculator _calculator;
        private readonly IPropertyValidator _validator;

        public RealEstateAsset(ICommissionCalculator calculator, IPropertyValidator validator)
        {
            _calculator = calculator;
            _validator = validator;
        }

        public decimal CalculateTax() => SalePrice * 0.1m;
        public bool IsAgencyValid() => _validator.IsValidAgencyName(AgencyName);
        public decimal GetCommission() => _calculator.CalculateCommission(SalePrice);
    }
}
