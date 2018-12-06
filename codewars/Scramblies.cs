using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class ScrambliesKata
    {
        public static bool Scramble(string scrambled, string word)
        {
            return scrambled.ToCharArray().Distinct().Union(word.ToCharArray()).Count() == scrambled.ToCharArray().Distinct().Count();
        }
    }

    public class ScrambliesTests
    {
        [Theory]
        [InlineData("rkqodlw", "world", true)]
        [InlineData("cedewaraaossoqqyt", "codewars", true)]
        [InlineData("katas", "steak", false)]
        [InlineData("scriptjavx", "javascript", false)]
        public void ExecuteScrambleExample(string scrambled, string word, bool isMatch)
        {
            ScrambliesKata.Scramble(scrambled, word).Should().Be(isMatch);
        }
    }
}
