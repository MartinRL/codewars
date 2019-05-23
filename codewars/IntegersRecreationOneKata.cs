using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class IntegersRecreationOneSolution
    {
        public static string ListSquared(long m, long n)
        {
            return "[" + string.Join(", ",Enumerable.Range((int) m, (int) (n - m)) /* would have loved to be able to use C# 8's Range instead */
                .Select(_ =>
                {
                    var sumOfSquaredDivisors = _
                        .Divisors()
                        .Select(d => d.Square())
                        .Sum();

                    var isSquare = sumOfSquaredDivisors == Math.Floor(Math.Sqrt(sumOfSquaredDivisors)).Square();

                    return isSquare ? new Tuple<int, double>(_, sumOfSquaredDivisors) : default;
                })
                .Where(_ => _ != default)
                .Select(_ => _.ToString()).ToArray())
                .Replace("(", "[")
                .Replace(")", "]") + "]";
        }
    }

    public static class IntegersRecreationOneExtensions
    {
        public static IEnumerable<int> Divisors(this int @this)
        {
            return Enumerable.Range(1, @this / 2).Where(_ => @this % _ == 0).Concat(new [] { @this });
        }

        public static double Square(this int @this)
        {
            return Math.Pow(@this, 2);
        }

        public static double Square(this double @this)
        {
            return Math.Pow(@this, 2);
        }
    }

    public class IntegersRecreationOneTests
    {
        [Theory]
        [InlineData(1, 250, "[[1, 1], [42, 2500], [246, 84100]]")]
        [InlineData(42, 250, "[[42, 2500], [246, 84100]]")]
        [InlineData(250, 500, "[[287, 84100]]")]
        public void VerifyListSquaredWith(long m, long n, string expectedSquared)
        {
            IntegersRecreationOneSolution.ListSquared(m, n).Should().Be(expectedSquared);
        }

        [Fact]
        public void VerifyDivisors()
        {
            42.Divisors().Should().BeEquivalentTo(new[] {1, 2, 3, 6, 7, 14, 21, 42});
        }
    }
}
