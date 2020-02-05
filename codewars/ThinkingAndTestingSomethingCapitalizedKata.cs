namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingSomethingCapitalizedSolution
    {
        public static string TestIt(string s)
        {
            if (s == string.Empty)
                return string.Empty;

            char Invert(char c) => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c);

            string InvertFirstChar(string w) => $"{Invert(w.First()).ToString()}{w.Substring(1)}";

            return string.Join(" ", s.Split(' ').Select(InvertFirstChar));
        }
    }

    public class ThinkingAndTestingSomethingCapitalizedTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "A")]
        [InlineData("a b c", "A B C")]
        [InlineData("AA", "aA")]
        public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingSomethingCapitalizedSolution.TestIt(s).Should().Be(expected);
    }
}
