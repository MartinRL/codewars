using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class IsNDivisibleByXandYSolution
    {
        public static bool IsDivisible(long n, long x, long y)
        {
            return n % x == 0 && n % y == 0;
        }
    }

    public class IsNDivisibleByXandYTests
    {
        [Theory]
        [InlineData(12,4,3, true)]
        [InlineData(3,3,4, false)]
        [InlineData(8,3,4, false)]
        public void VerifyIsDivisibleWith(long n, long x, long y, bool isDivisible)
        {
            IsNDivisibleByXandYSolution.IsDivisible(n, x, y).Should().Be(isDivisible);
        }
    }
}
