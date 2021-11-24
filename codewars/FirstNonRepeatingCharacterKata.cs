namespace codewars;

using System.Linq;
using FluentAssertions;
using Xunit;

public static class FirstNonRepeatingCharacterSolution
{
    public static string FirstNonRepeatingLetter(string s) =>
        s.GroupBy(char.ToLower)
            .Where(g => g.Count() == 1)
            .Select(g => g.First().ToString())
            .DefaultIfEmpty(string.Empty)
            .First();
}

public class FirstNonRepeatingCharacterTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("__D ", "D")]
    [InlineData("adDkp ", "a")]
    [InlineData("  D", "D")]
    [InlineData("s S B", "B")]
    [InlineData("a", "a")]
    [InlineData("stress", "t")]
    [InlineData("moonmen", "e")]
    [InlineData("abcd", "a")]
    [InlineData("aabBCc", "")]
    [InlineData("abcC", "a")]
    [InlineData("sTreSS", "T")]
    [InlineData("sStT", "")]
    public void VerifyFirstNonRepeatingLetterWith(string s, string l) => FirstNonRepeatingCharacterSolution.FirstNonRepeatingLetter(s).Should().Be(l);
}