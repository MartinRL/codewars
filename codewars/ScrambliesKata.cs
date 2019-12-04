namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class ScrambliesSolution
    {
        public static bool Scramble(string scrambled, string word) =>
            word.ToCharArray().All(l => scrambled.ToCharArray().Contains(l)) &&
            scrambled.ToCharArray()
                .Where(l => word.ToCharArray().Contains(l)).OrderBy(_ => _).GroupBy(_ => _)
                .Zip(word.ToCharArray().OrderBy(_ => _).GroupBy(_ => _), (sg, wg) => sg.Count() >= wg.Count())
                .All(_ => _);
    }

    public class ScrambliesTests
    {
        [Theory]
        [InlineData("rkqodlw", "world", true)]
        [InlineData("cedewaraaossoqqyt", "codewars", true)]
        [InlineData("katas", "steak", false)]
        [InlineData("scriptjavx", "javascript", false)]
        public void VerifyScrambleWith(string scrambled, string word, bool isMatch) => ScrambliesSolution.Scramble(scrambled, word).Should().Be(isMatch);
    }
}
