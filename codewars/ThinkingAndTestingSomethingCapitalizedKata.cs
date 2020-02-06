namespace codewars
{
    using System;
    using System.Globalization;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingSomethingCapitalizedSolution
    {
        public static string TestIt(string s) => new CultureInfo("en-US",false).TextInfo.ToTitleCase(s.ReverseString()).ReverseString();
    }

    public class ThinkingAndTestingSomethingCapitalizedTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "A")]
        [InlineData("a b c", "A B C")]
        [InlineData("aa", "aA")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingSomethingCapitalizedSolution.TestIt(s).Should().Be(expected);
    }
}
