using System;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TitleCaseKata
    {
        public static string TitleCase(string title, string minorWords)
        {
            return string.Join(" ",
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower())
                .Split()
                .Select((w, i) => minorWords.ToLower().Split().Contains(w.ToLower()) && i != 0 ? w.ToLower() : w )
            );
        }
    }

    public class TitleCaseTests
    {
        [Theory]
        [InlineData("a clash of KINGS", "a an the of", "A Clash of Kings")]
        [InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [InlineData("", "", "")]
        [InlineData("the quick brown fox", "", "The Quick Brown Fox")]
        public void ExecuteOrderExample(string title, string minorWords, string titleCased)
        {
            TitleCaseKata.TitleCase(title, minorWords).Should().Be(titleCased);
        }
    }
}
