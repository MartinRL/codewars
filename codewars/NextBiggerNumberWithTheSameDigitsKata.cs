using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NextBiggerNumberWithTheSameDigitsSolution
    {
        public static long CalculateNextBiggerNumber(long n)
        {
            if (n.ToString().OrderByDescending(_ => _).SequenceEqual(n.ToString()))
                return -1;

            throw new NotImplementedException();
        }
    }

    public class NextBiggerNumberWithTheSameDigitsTests
    {
        [Theory]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(9, -1)]
        [InlineData(111, -1)]
        [InlineData(531, -1)]
        public void VerifyCalculateNextBiggerNumberWith(long n, long expectedNextBiggerWithTheSameDigits)
        {
            NextBiggerNumberWithTheSameDigitsSolution.CalculateNextBiggerNumber(n).Should().Be(expectedNextBiggerWithTheSameDigits);
        }
    }
}
