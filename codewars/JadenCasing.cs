using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class JadenCasingKata
    {
        public static string JadenCase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
        }
    }

    public class JadenCasingTests
    {

        [Theory]
        [InlineData("How can mirrors be real if our eyes aren't real", "How Can Mirrors Be Real If Our Eyes Aren't Real")]
        [InlineData("this is me", "This Is Me")]
        public void RunJadenCaseTheory(string s, string jadenCased)
        {
            JadenCasingKata.JadenCase(s).Should().Be(jadenCased);
        }
    }
}
