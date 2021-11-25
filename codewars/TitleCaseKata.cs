namespace codewars;

using static System.Globalization.CultureInfo;

public static class TitleCaseSolution
{
    public static string TitleCase(string title, string minorWords)
    {
        var titleCasedTitle = CurrentCulture.TextInfo.ToTitleCase(title.ToLower());

        if (string.IsNullOrWhiteSpace(minorWords))
            return titleCasedTitle;

        return string.Join(" ",
            titleCasedTitle
                .Split()
                .Select((w, i) => minorWords.ToLower().Split().Contains(w.ToLower()) && i != 0 ? w.ToLower() : w)
        );
    }
}

public class TitleCaseTests
{
    [Theory]
    [InlineData("a clash of KINGS", "a an the of", "A Clash of Kings")]
    [InlineData("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
    [InlineData("", "", "")]
    [InlineData("the quick brown fox", "", "The Quick Brown Fox")]
    [InlineData("aBC deF Ghi", null, "Abc Def Ghi")]
    public void VerifyTitleCaseWith(string title, string minorWords, string titleCased) => TitleCaseSolution.TitleCase(title, minorWords).Should().Be(titleCased);
}