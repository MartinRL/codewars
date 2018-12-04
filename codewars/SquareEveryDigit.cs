using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class SquareEveryDigitKata
    {
        public static int SquareDigits(int n)
        {
            return int.Parse(string.Concat(n.ToString().ToCharArray().Select(c => Math.Pow(char.GetNumericValue(c), 2).ToString())));
        }
    }
    
    public class SquareEveryDigitKataTests
    {
        [Theory]
        [InlineData(9119, 811181)]
        [InlineData(1, 1)]
        [InlineData(765, 493625)]
        public void RunSquareDigitsTheory(int n, int squaredDigits)
        {
            SquareEveryDigitKata.SquareDigits(n).Should().Be(squaredDigits);
        }
    }
}
