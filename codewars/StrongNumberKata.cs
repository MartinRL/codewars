using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class StrongNumberSolution
    {
        public static string StrongNumber(int number)
        {
            throw new NotImplementedException();
        }
    }

    public class StrongNumberTests
    {
        [Theory]
        [InlineData(1, "STRONG!!!!")]
        [InlineData(2, "STRONG!!!!")]
        [InlineData(145, "STRONG!!!!")]
        [InlineData(7, "Not Strong !!")]
        [InlineData(93, "Not Strong !!")]
        [InlineData(185, "Not Strong !!")]
        public void VerifyStrongNumberWith(int number, string strongMsg)
        {
            StrongNumberSolution.StrongNumber(number).Should().Be(strongMsg);
        }
    }
}
