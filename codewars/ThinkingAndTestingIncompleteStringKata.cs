namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingIncompleteStringSolution
    {
        public static string TestIt(string s) => throw new NotImplementedException();
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
        [InlineData("aa", "aaaa")]
        [InlineData("aaa", "aaaaaa")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingIncompleteStringSolution.TestIt(s).Should().Be(expected);
    }
}
