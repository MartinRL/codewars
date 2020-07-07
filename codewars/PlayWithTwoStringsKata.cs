namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class PlayWithTwoStringsSolution
    {
        public static string WorkOnStrings(string a, string b) => throw new NotImplementedException();
    }

    public class PlayWithTwoStringsTests
    {
        [Theory]
        [InlineData("abc","cde", "abCCde")]
        [InlineData("abc","cde", "ABABbababa")]
        [InlineData("abcdeFgtrzw", "defgGgfhjkwqe", "abcDeFGtrzWDEFGgGFhjkWqE")]
        [InlineData("abcdeFg", "defgG", "abcDEfgDEFGg")]
        public void VerifyWorkOnStringsWith(string a, string b, string expectedCombination) => PlayWithTwoStringsSolution.WorkOnStrings(a, b).Should().Be(expectedCombination);
    }
}
