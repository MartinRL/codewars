namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ExpressionsMatterSolution
    {
        public static int ExpressionsMatter(int a, int b, int c) =>
        new[]
        {
            a + b + c,
            a + b * c,
            (a + b) * c,
            a * b + c,
            a * (b + c),
            a * b * c
        }.Max();
    }

    public class ExpressionsMatterTests
    {
        [Theory]
        [InlineData(2, 1, 2, 6)]
        [InlineData(1, 1, 1, 3)]
        [InlineData(2, 1, 1, 4)]
        [InlineData(1, 2, 3, 9)]
        [InlineData(2, 2, 2, 8)]
        public void VerifyExpressionsMatterWith(int a, int b, int c, int expectedLargestNumber) => ExpressionsMatterSolution.ExpressionsMatter(a, b, c).Should().Be(expectedLargestNumber);
    }
}
