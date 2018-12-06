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
            throw new NotImplementedException();
        }
    }

    public class ScrambliesTests
    {
        [Theory]
        [InlineData("rkqodlw", "world", true)]
        [InlineData("cedewaraaossoqqyt", "codewars", true)]
        [InlineData("katas", "steak", false)]
        public void ExecuteOrderExample(string scrambled, string word, bool isMatch)
        {
            ScrambliesKata.Scramble(scrambled, word).Should().Be(isMatch);
        }
    }
}
