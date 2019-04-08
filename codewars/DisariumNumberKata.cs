using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class DisariumNumberSolution
    {
        public static string DisariumNumber(int number)
        {
            return number == number.ToDigits().Select((digit, position) => Math.Pow(digit, position + 1)).Sum() ? "Disarium !!" : "Not !!";
        }
    }
    
    public class DisariumNumberTests
    {
        [Theory]
        [InlineData(89, "Disarium !!")]
        [InlineData(564, "Not !!")]
        [InlineData(1024, "Not !!")]
        [InlineData(135, "Disarium !!")]
        [InlineData(136586, "Not !!")]
        public void VerifyDisariumNumberWith(int number, string expected)
        {
            DisariumNumberSolution.DisariumNumber(number).Should().Be(expected);
        }
    }
}
