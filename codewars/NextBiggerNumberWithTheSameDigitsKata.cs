using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NextBiggerNumberWithTheSameDigitsSolution
    {
        public static long CalculateNextBiggerNumber(long n)
        {
            for (var i = n + 1; i <= long.Parse(n.AsDescendingString()); i++)
            {
                if(n.AsDescendingString() == i.AsDescendingString())
                    return i;
            }
            
            return -1;  
        }
    }

    public static class NextBiggerNumberWithTheSameDigitsExtensions
    {
        public static string AsDescendingString(this long @this) => @this.ToString().OrderByDescending(_ => _).AsString();
    }

    public class NextBiggerNumberWithTheSameDigitsTests
    {
        [Theory]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(1234, 1243)]
        [InlineData(144, 414)]
        [InlineData(534976, 536479)]
        [InlineData(9, -1)]
        [InlineData(111, -1)]
        [InlineData(531, -1)]
        public void VerifyCalculateNextBiggerNumberWith(long n, long expectedNextBiggerWithTheSameDigits) =>
            NextBiggerNumberWithTheSameDigitsSolution.CalculateNextBiggerNumber(n).Should().Be(expectedNextBiggerWithTheSameDigits);
    }
}
