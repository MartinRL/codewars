using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class FindTheUniqueNumberKata
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            return numbers
                .GroupBy(_ => _)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Single(_ => _.Count == 1)
                .Number;
        }
    }

    public class FindTheUniqueNumberTests
    {
        [Theory]
        [InlineData(new [] {1, 2, 2, 2}, 1)]
        [InlineData(new [] {-2, 2, 2, 2}, -2)]
        [InlineData(new [] {11, 11, 14, 11, 11}, 14)]
        public void ExecuteGetUniqueExample(IEnumerable<int> numbers, int uniqueNumber)
        {
            FindTheUniqueNumberKata.GetUnique(numbers).Should().Be(uniqueNumber);
        }
    }
}
