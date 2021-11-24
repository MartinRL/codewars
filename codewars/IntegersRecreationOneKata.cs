namespace codewars;

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

public class IntegersRecreationOneSolution
{
    public static string ListSquared(long m, long n)
    {
        return "[" + string.Join(", ", Enumerable.Range((int) m, (int) (n - m)) /* would have loved to be able to use C# 8's Range instead */
                .Select(_ =>
                {
                    var sumOfSquaredDivisors = _
                        .Divisors()
                        .Select(d => d.Square())
                        .Sum();

                    var sqrtIsInteger = Math.Sqrt(sumOfSquaredDivisors).IsInteger();

                    return sqrtIsInteger ? new Tuple<int, double>(_, sumOfSquaredDivisors) : default;
                })
                .Where(_ => _ != null)
                .Select(_ => _.ToString()).ToArray())
            .Replace("(", "[")
            .Replace(")", "]") + "]";
    }
}

public class IntegersRecreationOneTests
{
    [Theory]
    [InlineData(1, 250, "[[1, 1], [42, 2500], [246, 84100]]")]
    [InlineData(42, 250, "[[42, 2500], [246, 84100]]")]
    [InlineData(250, 500, "[[287, 84100]]")]
    public void VerifyListSquaredWith(long m, long n, string expectedSquared) => IntegersRecreationOneSolution.ListSquared(m, n).Should().Be(expectedSquared);
}