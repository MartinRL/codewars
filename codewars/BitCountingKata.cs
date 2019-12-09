namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class BitCountingSolution
    {
        public static int CountBits(int n) => Convert.ToString(n, 2).Count(_ => _ == '1');
    }

    public class BitCountingTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(4, 1)]
        [InlineData(7, 3)]
        [InlineData(9, 2)]
        [InlineData(10, 2)]
        public void VerifyCountBitsWith(int n, int expectedBitCount) => BitCountingSolution.CountBits(n).Should().Be(expectedBitCount);
    }
}
