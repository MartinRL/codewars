using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class CountTheMonkeysSolution
    {
        public static int[] MonkeyCount(int n)
        {
            throw new NotImplementedException();
        }
    }

    public class CountTheMonkeysTests
    {
        [Theory]
        [InlineData(5, new[] {1, 2, 3, 4, 5})]
        [InlineData(3, new[] {1, 2, 3})]
        [InlineData(9, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [InlineData(10, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [InlineData(20, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})]
        public void VerifyMonkeyCountWith(int n, int[] monkeys)
        {
            CountTheMonkeysSolution.MonkeyCount(n).Should().BeEquivalentTo(monkeys);
        }
    }
}
