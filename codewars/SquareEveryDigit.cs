using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class SquareEveryDigitKata
    {
        public static int SquareDigits(int n)
        {
            return 0;
        }
    }
    
    public class SquareEveryDigitKataTests
    {
        [Theory]
        [InlineData(9119, 811181)]
        public void RunSquareDigitsTheory(int n, int squaredDigits)
        {
            SquareEveryDigitKata.SquareDigits(n).Should().Be(squaredDigits);
        }
    }
}
