namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingTrueOrFalseSolution
    {
        public static int TestIt(int n) => throw new NotImplementedException();
    }

    public class ThinkingAndTestingTrueOrFalseTests
    {
        [Theory]
        [InlineData(0, 0)] // 0
        [InlineData(1, 1)] // 1
        [InlineData(1, 2)] // 10
        [InlineData(2, 3)] // 011
        [InlineData(1, 4)] // 100
        [InlineData(2, 5)] // 0101
        [InlineData(2, 6)] // 0110
        [InlineData(3, 7)] // 0111
        [InlineData(1, 8)]
        [InlineData(2, 9)]
        [InlineData(2, 10)]
        [InlineData(3, 100)]
        [InlineData(6, 1000)]
        [InlineData(5, 10000)]
        public void VerifyTestItWith(int n, int expected) => ThinkingAndTestingTrueOrFalseSolution.TestIt(n).Should().Be(expected);
    }
}
