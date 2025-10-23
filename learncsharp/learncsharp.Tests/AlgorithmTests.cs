namespace learncsharp.Tests;

public class AlgorithmTests
{
    private readonly Algorithm algo = new Algorithm();

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 7, 19, 53, 102, 219, 450 }, 272, new int[] { 2, 4 })]
    public void TwoSum_ComputesExpectedArray(int[] nums, int target, int[] expected)
    {
        int[] result = algo.TwoSum(nums, target);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("aabccdebf", 'd')]
    [InlineData("aabbcc", '\0')]
    [InlineData("xyzabcdexzplkjhgged", 'y')]
    public void FirstNonRepeatingChar_ComputesExpectedChar(string s, char expected)
    {
        char result = algo.FirstNonRepeatingChar(s);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("MMMXLV", 3045)]
    [InlineData("DXCI", 591)]
    public void RomanToInt_ComputesExpectedValue(string s, int expected)
    {
        int actual = algo.RomanToInt(s);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 2, 3 }, true)]
    [InlineData(new int[] { 6, 5, 4, 4 }, true)]
    [InlineData(new int[] { 1, 3, 2 }, false)]
    [InlineData(new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 1 }, false)]
    public void IsMonotonic_ReturnsExpectedResult(int[] nums, bool expected)
    {
        bool result = algo.IsMonotonic(nums);
        Assert.Equal(expected, result);
    }
}
