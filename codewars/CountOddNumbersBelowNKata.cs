using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class CountOddNumbersBelowNSolution
    {
        public static ulong OddCount(ulong n) => n / 2;
    }

    public class CountOddNumbersBelowNTests
    {
        [Theory]
        [InlineData(7, 3)]
        [InlineData(15, 7)]
        [InlineData(15023, 7511)]
        public void VerifyOddCountWith(ulong n, ulong count) => CountOddNumbersBelowNSolution.OddCount(n).Should().Be(count);
    }
}
