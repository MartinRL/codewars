using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class BalancedNumberSolution
    {
        public static string BalancedNumber(int number)
        {
            var numberAsString = number.ToString();
            
            if (numberAsString.Length == 1 || numberAsString.Length == 2)
                return "Balanced";

            var termLength = (numberAsString.Length / 2) - 1 + (numberAsString.Length % 2);

            var leftTermAsString = numberAsString.Substring(0, termLength);
            var rightTermAsString = numberAsString.Substring(numberAsString.Length - termLength);

            var leftTerm = (int) leftTermAsString.Sum(_ => char.GetNumericValue(_));
            var rightTerm = (int) rightTermAsString.Sum(_ => char.GetNumericValue(_));

            return (leftTerm == rightTerm ? string.Empty : "Not ") + "Balanced";
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
        public void VerifyBalancedNumberWith(int input, string expected)
        {
            BalancedNumberSolution.BalancedNumber(input).Should().Be(expected);
        }
    }
}
