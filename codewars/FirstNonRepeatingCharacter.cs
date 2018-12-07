using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class FirstNonRepeatingCharacterKata
    {
        public static string FirstNonRepeatingLetter(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;
            
            return s.GroupBy(_ => _).First(g => g.Count() == 1).Key.ToString();
        }
    }

    public class FirstNonRepeatingCharacterTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("stress", "t")]
        [InlineData("moonmen", "e")]
        public void ExecuteOrderExample(string s, string l)
        {
            FirstNonRepeatingCharacterKata.FirstNonRepeatingLetter(s).Should().Be(l);
        }
    }
}
