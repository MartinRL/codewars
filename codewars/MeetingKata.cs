namespace codewars;

public class MeetingSolution
{
    public static string FormatAndOrderAccordingToJohnsRequirements(string friends) =>
        friends
            .ToUpperInvariant()
            .Split(';')
            .Select(name => name.Split(':'))
            .OrderBy(names => names[1]).ThenBy(names => names[0])
            .Select(names => $"({names[1]}, {names[0]})")
            .Aggregate((concat, name) => $"{concat}{name}");
}

public class MeetingTests
{
    [Theory]
    [InlineData("Alexis:Wahl;John:Bell;Victoria:Schwarz;Abba:Dorny;Grace:Meta;Ann:Arno;Madison:STAN;Alex:Cornwell;Lewis:Kern;Megan:Stan;Alex:Korn",
        "(ARNO, ANN)(BELL, JOHN)(CORNWELL, ALEX)(DORNY, ABBA)(KERN, LEWIS)(KORN, ALEX)(META, GRACE)(SCHWARZ, VICTORIA)(STAN, MADISON)(STAN, MEGAN)(WAHL, ALEXIS)")]
    [InlineData("John:Gates;Michael:Wahl;Megan:Bell;Paul:Dorries;James:Dorny;Lewis:Steve;Alex:Meta;Elizabeth:Russel;Anna:Korn;Ann:Kern;Amber:Cornwell",
        "(BELL, MEGAN)(CORNWELL, AMBER)(DORNY, JAMES)(DORRIES, PAUL)(GATES, JOHN)(KERN, ANN)(KORN, ANNA)(META, ALEX)(RUSSEL, ELIZABETH)(STEVE, LEWIS)(WAHL, MICHAEL)")]
    [InlineData("Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern",
        "(ARNO, ALEX)(ARNO, HALEY)(BELL, SARAH)(CORNWELL, ALISSA)(DORNY, PAUL)(DORRIES, ANDREW)(KERN, ANN)(KERN, MADISON)")]
    [InlineData("Martin:Rosenholm;Axel:Rosenholm;Sarah:Cracknell;Nils:Rosenholm",
        "(CRACKNELL, SARAH)(ROSENHOLM, AXEL)(ROSENHOLM, MARTIN)(ROSENHOLM, NILS)")]
    public void VerifyFormatAndOrderAccordingToJohnsRequirementsWith(string friends, string formattedAndOrderedFriends) =>
        MeetingSolution.FormatAndOrderAccordingToJohnsRequirements(friends).Should().Be(formattedAndOrderedFriends);
}