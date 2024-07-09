namespace codewars;

using static Int32;

public static class SquareEveryDigitSolution
{
    public static int SquareDigits(int n) =>
        Parse(n.ToString().ToCharArray()
            .Select(char.GetNumericValue)
            .Select(d => Math.Pow(d, 2).ToString())
            .Aggregate((s1, s2) => s1 + s2));
}

public class SquareEveryDigitKataTests
{
    [Theory]
    [InlineData(9119, 811181)]
    [InlineData(1, 1)]
    [InlineData(765, 493625)]
    public void VerifySquareDigitsWith(int n, int squaredDigits) => SquareEveryDigitSolution.SquareDigits(n).Should().Be(squaredDigits);
}
