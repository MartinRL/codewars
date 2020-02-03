namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingAAndBSolution
    {
        public static int TestIt(int a, int b) => a + (b - a);
    }

    public class ThinkingAndTestingAAndBTests
    {
        [Theory]
        [InlineData(0, 1, 1)] // 0 + (1 - 0) = 1
        [InlineData(1, 2, 3)]
        [InlineData(10, 20, 30)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 3, 3)] // 1 + (3 - 1) = 3
        public void VerifyTestItWith(int a, int b, int expected) => ThinkingAndTestingAAndBSolution.TestIt(a, b).Should().Be(expected);
    }
}
