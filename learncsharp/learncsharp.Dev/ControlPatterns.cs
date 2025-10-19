namespace learncsharp.Dev;

public record Order
{
    public decimal Total { get; set; }
    public char CustomerTier { get; set; } //S = Silver, G=Gold, P=Platinum
}

public class ControlPatterns
{
    // Return the discount level ('High', 'Low', 'Standard')
    // based on the order total; using property patterns.
    public static string ComputeDiscountLevel(Order customerOrder)
    {
        string result = customerOrder switch
        {
            { Total: < 100 } => "Low",
            { Total: > 1000 } => "High",
            _ => "Standard"
        };

        return result;
    }
}
