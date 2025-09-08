using Xunit;

namespace learncsharp.Tests;

public class UnitTest1
{
    [Fact]
    public void AddArray_ReturnsSumOfArray()
    {
        // Arrange
        var basicFeatures = new BasicFeatures();
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Act
        int result = basicFeatures.AddArray(numbers);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void AddArray_EmptyArray_ReturnsZero()
    {
        var basicFeatures = new BasicFeatures();
        int[] numbers = { };
        int result = basicFeatures.AddArray(numbers);
        Assert.Equal(0, result);
    }

    [Fact]
    public void AddArray_NegativeNumbers_ReturnsCorrectSum()
    {
        var basicFeatures = new BasicFeatures();
        int[] numbers = { -1, -2, -3, 4, 5 };
        int result = basicFeatures.AddArray(numbers);
        Assert.Equal(3, result);
    }
}
