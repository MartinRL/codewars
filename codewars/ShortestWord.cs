using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class ShortestWordKata
    {
        public static int FindShort(string s)
        {
            return 0;
        }
    }

    public class ShortestWordTests
    {
        [Theory]
        [InlineData("bitcoin take over the world maybe who knows perhaps", 3)]
        [InlineData("turns out random test cases are easier than writing out basic ones", 3)]
        public void RunFindShortTheory(string s, int shortestLength)
        {
            ShortestWordKata.FindShort(s).Should().Be(shortestLength);
        }
    }
}
