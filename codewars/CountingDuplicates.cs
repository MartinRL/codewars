using FluentAssertions;
using Xunit;

namespace codewars
{
    public class CountingDuplicatesKata
    {
        public static int CountDuplicates(string s)
        {
            return -1;
        }
    }

    public class CountingDuplicatesTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("abcde", 0)]
        [InlineData("aabbcde", 2)]
        [InlineData("aabBcde", 2)]
        [InlineData("Indivisibility", 1)]
        [InlineData("Indivisibilities", 2)]
        public void RunCountDuplicatesTheory(string argument, int expected)
        {
            CountingDuplicatesKata.CountDuplicates(argument).Should().Be(expected);
        }
    }
}
