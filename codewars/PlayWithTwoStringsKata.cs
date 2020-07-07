namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class PlayWithTwoStringsSolution
    {
        public static string WorkOnStrings(string a, string b) => $"{Swap(a, b)}{Swap(b, a)}";

        private static string Swap(string input, string seed) => string.Concat(input.Select(c => seed.Count(_ => char.ToLower(_) == char.ToLower(c)) % 2 == 0 ? c : c.ToggleCase()));
    }

    public static class PlayWithTwoStringsExtensions
    {
        public static char ToggleCase(this char @this)
        {
            if (char.IsLower(@this))
                return char.ToUpper(@this);

            return char.ToLower(@this);
        }
    }

    public class PlayWithTwoStringsTests
    {
        [Theory]
        [InlineData("abc","cde", "abCCde")]
        [InlineData("abab", "bababa", "ABABbababa")]
        [InlineData("abcdeFgtrzw", "defgGgfhjkwqe", "abcDeFGtrzWDEFGgGFhjkWqE")]
        [InlineData("abcdeFg", "defgG", "abcDEfgDEFGg")]
        public void VerifyWorkOnStringsWith(string a, string b, string expectedCombination) => PlayWithTwoStringsSolution.WorkOnStrings(a, b).Should().Be(expectedCombination);
    }
}
