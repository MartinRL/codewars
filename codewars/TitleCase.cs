using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TitleCaseKata
    {
        public static string TitleCase(string title, string minorWords="")
        {
            throw new NotImplementedException();
        }
    }

    public class TitleCaseTests
    {
        [Theory]
        [InlineData("a clash of KINGS", "a an the of", "A Clash of Kings")]
        [InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [InlineData("", "", "")]
        [InlineData("The Quick Brown Fox", "", "the quick brown fox")]
        public void ExecuteOrderExample(string title, string minorWords, string titleCased)
        {
            TitleCaseKata.TitleCase(title, minorWords).Should().Be(titleCased);
        }
    }
}
