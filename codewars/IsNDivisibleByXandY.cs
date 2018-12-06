using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class IsNDivisibleByXandYKata
    {
        public static bool IsDivisible(long n, long x, long y)
        {
            throw new NotImplementedException();
        }
    }

    public class IsNDivisibleByXandYTests
    {
        [Theory]
        [InlineData(12,4,3, true)]
        [InlineData(3,3,4, false)]
        [InlineData(8,3,4, false)]
        public void ExecuteIsDivisibleExample(long n, long x, long y, bool isDivisible)
        {
            IsNDivisibleByXandYKata.IsDivisible(n, x, y).Should().Be(isDivisible);
        }
    }
}
