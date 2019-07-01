using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MeetingSolution
    {
        public static string FormatAndOrderAccordingToJohnsRequirements(string friends)
        {
            return string.Join(string.Empty, friends
                .ToUpper()
                .Split(';')
                .OrderBy(name => new Name(name).Last)
                .ThenBy(name => new Name(name).First)
                .Select(name => $"({new Name(name).Last}, {new Name(name).First})")
                .ToArray());
        }

        private class Name
        {
            public readonly string First;
            public readonly string Last;
            
            public Name(string name)
            {
                var names = name.Split(':');
                First = names[0];
                Last = names[1];
            }
        }
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
        public void VerifyFormatAndOrderAccordingToJohnsRequirementsWith(string friends, string formattedAndOrderedFriends)
        {
            MeetingSolution.FormatAndOrderAccordingToJohnsRequirements(friends).Should().Be(formattedAndOrderedFriends);
        }
    }
}
