using System;
using System.IO;
using Xunit;

namespace learncsharp.Tests;

public class AlgorithmTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 7, 19, 53, 102, 219, 450 }, 272, new int[] { 2, 4 })]
    public void TwoSum_ComputesExpectedArray(int[] nums, int target, int[] expected)
    {
        var algo = new Algorithm();
        int[] result = algo.TwoSum(nums, target);
        Assert.Equal(expected, result);
    }

}
