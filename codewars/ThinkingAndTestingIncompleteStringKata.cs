namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingIncompleteStringSolution
    {
        public static string TestIt(string s)
        {
            if(s.Length < 2)
                return s;

            return string.Concat((char)((s[0] + s[1]) / 2), TestIt(s.Substring(2)));
        }
    }

    public class ThinkingAndTestingIncompleteStringTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        [InlineData("aa", "a")]
        [InlineData("ab", "a")]
        [InlineData("bc", "b")]
        [InlineData("aaaa", "aa")]
        [InlineData("aaaaaa", "aaa")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingIncompleteStringSolution.TestIt(s).Should().Be(expected);
    }
}
