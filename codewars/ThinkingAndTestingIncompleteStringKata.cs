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
            var modString = string.Empty;

            for(var i = 0; i < s.Length; i += 2)
            {
                var meanChar = s[i];
                if(i + 1 < s.Length)
                {
                    meanChar = (char)((meanChar + s[i+1]) / 2);
                }
                modString += meanChar;
            }

            return modString;
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
