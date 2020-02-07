namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingUniqOrNotUniqSolution
    {
        public static int[] TestIt(int[] a, int[] b) => a.Concat(b).OrderBy(_ => _).ToArray();
    }

    public class ThinkingAndTestingUniqOrNotUniqTests
    {
        [Theory]
        [InlineData(new[] {0}, new[] {1}, new[] {0, 1})]
        [InlineData(new[] {1, 2}, new[] {3, 4}, new[] {1, 2, 3, 4})]
        [InlineData(new[] {1}, new[] {2, 3, 4}, new[] {1, 2, 3, 4})]
        [InlineData(new[] {1, 2, 3}, new[] {4}, new[] {1, 2, 3, 4})]
        [InlineData(new[] {1, 2}, new[] {1, 2}, new[] {1, 1, 2, 2})]
        public void VerifyTestItWith(int[] a, int[] b, int[] expected) => ThinkingAndTestingUniqOrNotUniqSolution.TestIt(a, b).Should().BeEquivalentTo(expected);
    }
}