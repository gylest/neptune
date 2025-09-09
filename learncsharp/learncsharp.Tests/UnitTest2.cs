using Xunit;
using learncsharp;

namespace learncsharp.Tests
{
    public class ControlPatternsTests
    {
        [Theory]
        [InlineData(50, 'S', "Low")]
        [InlineData(500, 'G', "Standard")]
        [InlineData(1500, 'P', "High")]
        public void ComputeDiscountLevel_ReturnsExpectedResult(decimal total, char tier, string expected)
        {
            var order = new Order { Total = total, CustomerTier = tier };
            string result = ControlPatterns.ComputeDiscountLevel(order);
            Assert.Equal(expected, result);
        }
    }
}
