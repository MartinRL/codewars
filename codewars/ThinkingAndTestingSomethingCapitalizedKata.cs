namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingSomethingCapitalizedSolution
    {
        public static string TestIt(string s) => throw new NotImplementedException();
    }

    public class ThinkingAndTestingSomethingCapitalizedTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "A")]
        [InlineData("a b c", "A B C")]
        [InlineData("Aa", "aA")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingSomethingCapitalizedSolution.TestIt(s).Should().Be(expected);
    }
}
