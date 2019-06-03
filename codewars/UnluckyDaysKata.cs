using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class UnluckyDaysSolution
    {
        public static int GetUnluckyDays(int year)
        {
            throw new NotImplementedException();
        }
    }

    public class UnluckyDaysTests
    {
        [Theory]
        [InlineData(1586, 1)]
        [InlineData(1001, 3)]
        [InlineData(2819, 2)]
        [InlineData(2792, 2)]
        [InlineData(2723, 2)]
        [InlineData(1909, 1)]
        [InlineData(1812, 2)]
        [InlineData(1618, 2)]
        [InlineData(2132, 1)]
        [InlineData(2065, 3)]
        public void VerifyGetUnluckyDaysWith(int year, int expectedUnluckyDays)
        {
            UnluckyDaysSolution.GetUnluckyDays(year).Should().Be(expectedUnluckyDays);
        }
    }
}
