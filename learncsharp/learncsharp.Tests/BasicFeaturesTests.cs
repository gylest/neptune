namespace learncsharp.Tests;

public class BasicFeaturesTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 15)]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { -1, -2, -3, 4, 5 }, 3)]
    [InlineData(new int[] { int.MaxValue, 1 }, int.MinValue)] // overflow wraps in unchecked context
    public void AddArray_ComputesExpectedSum(int[] numbers, int expected)
    {
        var sut = new BasicFeatures();
        int result = sut.AddArray(numbers);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FizzBuzz_Writes100Lines()
    {
        var sut = new BasicFeatures();

        using var sw = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        try
        {
            sut.FizzBuzz();
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        var output = sw.ToString().Trim().Split(Environment.NewLine);
        Assert.Equal(100, output.Length);
        Assert.Equal("1", output[0]);
        Assert.Equal("FizzBuzz", output[14]); // 15th line
        Assert.Equal("Buzz", output[4]);     // 5th line
        Assert.Equal("Fizz", output[2]);     // 3rd line
    }
}
