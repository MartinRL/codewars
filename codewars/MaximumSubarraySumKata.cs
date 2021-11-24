namespace codewars;

using System;
using FluentAssertions;
using Xunit;

public class MaximumSubarraySumSolution
{
    public static int MaxSequence(int[] arr)
    {
        var max = 0;

        for (var i = 0; i < arr.Length; i++)
        {
            var sum = 0;

            for (var j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                max = Math.Max(max, sum);
            }
        }

        return max;
    }
}

public class MaximumSubarraySumTests
{
    [Theory]
    [InlineData(new int[0], 0)]
    [InlineData(new[] {1, 2, 3}, 6)]
    [InlineData(new[] {-1, -2, -3}, 0)]
    [InlineData(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6)]
    public void VerifyMaxSequenceWith(int[] arr, int expected) => MaximumSubarraySumSolution.MaxSequence(arr).Should().Be(expected);
}