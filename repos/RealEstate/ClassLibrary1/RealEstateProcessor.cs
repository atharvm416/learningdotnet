namespace ClassLibrary1;

public class RealEstateProcessor : IRealEstateOperations
{
    public decimal CalculateCommission(decimal propertyPrice)
    {
        return propertyPrice * 0.03m;
    }

    public bool IsValidProperty(decimal price, string location)
    {
        return price > 0 && !string.IsNullOrWhiteSpace(location);
    }

    public List<int> SorttheList(List<int> unorderedList)
    {
        List<int> orderedList = new List<int>(unorderedList);
        orderedList.Sort(); // Sorts the list in ascending order
        return orderedList;
    }

    public int Average(List<int> unorderedList)
    {
        int orderedList = (int) unorderedList.Average();
        return orderedList;
    }


}