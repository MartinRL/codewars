using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MaximumSubarraySumSolution
    {
        public static int MaxSequence(int[] arr)
        {
            throw new NotImplementedException();
        }
    }

    public class MaximumSubarraySumTests
    {
        [Theory]
        [InlineData(new int[0], 0)]
        [InlineData(new int[]{-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6)]
        public void VerifyMaxSequenceWith(int[] arr, int expected)
        {
            MaximumSubarraySumSolution.MaxSequence(arr).Should().Be(expected);
        }
    }
}
