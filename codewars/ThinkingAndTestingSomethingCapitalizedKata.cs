namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingSomethingCapitalizedSolution
    {
        public static string TestIt(string s) => new string(s.Select(_ => char.IsLower(_) ? char.ToUpper(_) : char.ToLower(_)).ToArray());
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
