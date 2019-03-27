using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class BalancedNumberKata
    {
        public static string BalancedNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
    
    public class BalancedNumberTests
    {
        [Theory]
        [InlineData(7, "Balanced")]
        [InlineData(959, "Balanced")]
        [InlineData(13, "Balanced")]
        [InlineData(56239814, "Balanced")]
        [InlineData(424, "Balanced")]
        [InlineData(1024, "Not Balanced")]
        [InlineData(66545, "Not Balanced")]
        [InlineData(295591, "Not Balanced")]
        [InlineData(1230987, "Not Balanced")]
        [InlineData(432, "Not Balanced")]
        public void ExecuteBalancedNumber(int input, string expected)
        {
            BalancedNumberKata.BalancedNumber(input).Should().Be(expected);
        }
    }
}
