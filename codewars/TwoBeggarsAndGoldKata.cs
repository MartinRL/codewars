using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class TwoBeggarsAndGoldSolution
    {
        public static (int a, int b) DistributionOf(int[] golds)
        {
            throw new NotImplementedException();
        }
    }

    public class TwoBeggarsAndGoldTests
    {
        [Theory]
        [InlineData(new [] {4, 2, 9, 5, 2, 7}, 14, 15)]
        [InlineData(new [] {4, 7, 2, 9, 5, 2}, 11, 18)]
        [InlineData(new [] {10, 1000, 2, 1}, 12, 1001)]
        public void VerifyDistributionOfWith(int[] golds, int expectedA, int expectedB) => TwoBeggarsAndGoldSolution.DistributionOf(golds).Should().Be((expectedA, expectedB));
    }
}
