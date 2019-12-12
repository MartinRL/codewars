namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HammingNumbersSolution
    {
        public static long CalculateSmallestFor(int n)
        {
            throw new NotImplementedException();
        }
    }

    public class HammingNumbersTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(7, 8)]
        [InlineData(8, 9)]
        [InlineData(9, 10)]
        [InlineData(10, 12)]
        [InlineData(11, 15)]
        [InlineData(12, 16)]
        [InlineData(13, 18)]
        [InlineData(14, 20)]
        [InlineData(15, 24)]
        [InlineData(16, 25)]
        [InlineData(17, 27)]
        [InlineData(18, 30)]
        [InlineData(19, 32)]
        public void VerifyCalculateSmallestForWith(int n, long expectedSmallestHammingNumber) => HammingNumbersSolution.CalculateSmallestFor(n).Should().Be(expectedSmallestHammingNumber);
    }
}
