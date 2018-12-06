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
            return int.Parse(n
                .ToString()
                .ToCharArray()
                .Select(char.GetNumericValue)
                .Select(d => Math.Pow(d, 2).ToString())
                .Aggregate((s1, s2) => s1 + s2));
        }
    }
    
    public class SquareEveryDigitKataTests
    {
        [Theory]
        [InlineData(9119, 811181)]
        [InlineData(1, 1)]
        [InlineData(765, 493625)]
        public void ExecuteSquareDigitsExample(int n, int squaredDigits)
        {
            SquareEveryDigitKata.SquareDigits(n).Should().Be(squaredDigits);
        }
    }
}
