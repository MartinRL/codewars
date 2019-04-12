using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class TidyNumberSolution
    {
        public static bool TidyNumber(int n)
        {
            var nAsDigits = n.ToDigits();

            return !n.ToDigits().Skip(1).Select((d, pos) => d - nAsDigits[pos]).Any(_ => _ < 0);
        }
    }

    public class TidyNumberTests
    {
        [Theory]
        [InlineData(12, true)]
        [InlineData(2789, true)]
        [InlineData(2335, true)]
        [InlineData(102, false)]
        [InlineData(9672, false)]
        public void VerifyTidyNumberWith(int n, bool expected)
        {
            TidyNumberSolution.TidyNumber(n).Should().Be(expected);
        }
    }
}
