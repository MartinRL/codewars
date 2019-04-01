using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class StrongNumberSolution
    {
        public static string StrongNumber(int number)
        {
            return number == number.ToDigits().Select(Factorial).Sum() ? "STRONG!!!!" : "Not Strong !!";
        }

        private static int Factorial(int number)
        {
            var result = 1;
            
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            
            return result;
        }
    }

    public static class StrongNumberSolutionExtensions
    {
        public static IEnumerable<int> ToDigits(this int @this)
        {
            return @this.ToString().Select(_ => (int)char.GetNumericValue(_));
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
