namespace codewars
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingMathOfMiddleSchoolSolution
    {
        public static int[] TestIt(int[] a, int[] b) => throw new NotImplementedException();
    }

    public class ThinkingAndTestingMathOfMiddleSchoolTests
    {
        [Theory]
        [InlineData(new[] {0, 0, 0, 0}, new[] {0, 0, 0, 0}, new[] {0, 0, 0, 0})]
        [InlineData(new[] {22, 88, 0, 0}, new[] {0, 100, 0, 100}, new[] {0, 11000, 0, 0})]
        [InlineData(new[] {0, 0, 96, 49}, new[] {86, 0, 53, 0}, new[] {0, 0, 10853, 0})]
        [InlineData(new[] {0, 0, 83, 88}, new[] {0, 27, 0, 99}, new[] {0, 0, 0, 10953})]
        public void VerifyTestItWith(int[] a, int[] b, int[] expected) => ThinkingAndTestingMathOfMiddleSchoolSolution.TestIt(a, b).Should().BeEquivalentTo(expected);
    }
}
