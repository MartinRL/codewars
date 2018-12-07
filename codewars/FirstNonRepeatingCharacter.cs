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
            throw new NotImplementedException();
        }
    }

    public class FirstNonRepeatingCharacterTests
    {
        [Theory]
        [InlineData("a", "a")]
        [InlineData("t", "stress")]
        [InlineData("e", "moonmen")]
        public void ExecuteOrderExample(string s, string l)
        {
            FirstNonRepeatingCharacterKata.FirstNonRepeatingLetter(s).Should().Be(l);
        }
    }
}
