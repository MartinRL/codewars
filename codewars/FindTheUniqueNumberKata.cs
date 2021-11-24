namespace codewars;

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

public static class FindTheUniqueNumberSolution
{
    public static int GetUnique(IEnumerable<int> numbers) =>
        numbers
            .GroupBy(_ => _)
            .Select(g => new {Number = g.Key, Count = g.Count()})
            .Single(_ => _.Count == 1)
            .Number;
}

public class FindTheUniqueNumberTests
{
    [Theory]
    [InlineData(new[] {1, 2, 2, 2}, 1)]
    [InlineData(new[] {-2, 2, 2, 2}, -2)]
    [InlineData(new[] {11, 11, 14, 11, 11}, 14)]
    public void VerifyGetUniqueWith(IEnumerable<int> numbers, int uniqueNumber) => FindTheUniqueNumberSolution.GetUnique(numbers).Should().Be(uniqueNumber);
}