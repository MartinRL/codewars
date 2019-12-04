namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class ShortestWordSolution
    {
        public static int FindShort(string s) => s.Split(' ').Min(w => w.Length);
    }

    public class ShortestWordTests
    {
        [Theory]
        [InlineData("bitcoin take over the world maybe who knows perhaps", 3)]
        [InlineData("turns out random test cases are easier than writing out basic ones", 3)]
        public void VerifyFindShortWith(string s, int shortestLength) => ShortestWordSolution.FindShort(s).Should().Be(shortestLength);
    }
}
