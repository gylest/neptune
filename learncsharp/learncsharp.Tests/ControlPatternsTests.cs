namespace learncsharp.Tests;

public class ControlPatternsTests
{
    [Theory]
    [InlineData(50, 'S', "Low")]
    [InlineData(100, 'S', "Standard")]   // boundary: exactly 100
    [InlineData(500, 'G', "Standard")]
    [InlineData(1000, 'G', "Standard")]  // boundary: exactly 1000
    [InlineData(1500, 'P', "High")]
    [InlineData(999.99, 'X', "Standard")] // non standard tier; logic uses only Total
    [InlineData(0, 'P', "Low")]
    public void ComputeDiscountLevel_ReturnsExpectedResult(decimal total, char tier, string expected)
    {
        var order = new Order { Total = total, CustomerTier = tier };
        string result = ControlPatterns.ComputeDiscountLevel(order);
        Assert.Equal(expected, result);
    }
}

