namespace codewars
{
    using FluentAssertions;
    using Xunit;
    using static System.Math;

    public class YouAreASquareSolution
    {
        public static bool IsSquare(int n) => Floor(Sqrt(n)) == Sqrt(n);
    }

    public class YouAreASquareTests
    {
        [Theory]
        [InlineData(-1, false, "negative numbers aren't square numbers")]
        [InlineData(3, false, "3 isn't a square number")]
        [InlineData(4, true, "4 is a square number")]
        [InlineData(25, true, "25 is a square number")]
        [InlineData(26, false, "26 isN'T a square number")]
        public void VerifyIsSquareWith(int n, bool expectedIsSquare, string because) => YouAreASquareSolution.IsSquare(n).Should().Be(expectedIsSquare, because);
    }
}
