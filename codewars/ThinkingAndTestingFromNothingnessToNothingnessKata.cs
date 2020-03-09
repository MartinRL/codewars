namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingFromNothingnessToNothingnessSolution
    {
        public static string TestIt(string s) => s.Any(_ => _ == ' ') ? s.Split(' ')[1] : null;
    }

    public class ThinkingAndTestingFromNothingnessToNothingnessTests
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(" ", "")]
        [InlineData("a", null)]
        [InlineData(" a", "a")]
        [InlineData(" a ", "a")]
        [InlineData(" aa", "aa")]
        [InlineData("  aaa", "")]
        [InlineData("  a{", "")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingFromNothingnessToNothingnessSolution.TestIt(s).Should().Be(expected);
    }
}
