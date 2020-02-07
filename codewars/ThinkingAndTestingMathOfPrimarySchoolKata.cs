namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingMathOfPrimarySchoolSolution
    {
        public static int TestIt(int[] a) => Convert.ToInt32(new string(a.Select(_ => char.Parse(_.ToString())).ToArray()), 2).IsPrime() ? 0 : 1;
    }

    public static class ThinkingAndTestingMathOfPrimarySchoolExtensions
    {
        public static bool IsPrime(this int @this)
        {
            for (var i=2; i < @this; i++) if (@this %i == 0) return false;

            return true;
        }
    }

    public class ThinkingAndTestingMathOfPrimarySchoolTests
    {
        [Theory]
        [InlineData(new[] {0, 0, 0, 0}, 0)]
        [InlineData(new[] {0, 0, 0, 1}, 0)]
        [InlineData(new[] {0, 0, 1, 1}, 0)]
        [InlineData(new[] {0, 1, 0, 1}, 0)]
        [InlineData(new[] {0, 1, 1, 0}, 1)]
        [InlineData(new[] {1, 0, 0, 1}, 1)]
        public void VerifyTestItWith(int[] a, int expected) => ThinkingAndTestingMathOfPrimarySchoolSolution.TestIt(a).Should().Be(expected);
    }
}
