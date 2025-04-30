// IRealEstateOperations.cs
public interface IRealEstateOperations
{
    decimal CalculateCommission(decimal propertyPrice);
    bool IsValidProperty(decimal price, string location);
    List<int> SorttheList(List<int> unorderedList);
    int Average(List<int> unorderedList);
}