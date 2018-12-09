using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class FirstNonRepeatingCharacterKata
    {
        public static string FirstNonRepeatingLetter(string s)
        {
            if (s.Length == 1)
                return s;
            
            if (s.GroupBy(_ => _, new CaseInsensitiveLetterComparer()).All(g => g.Count() == 1))
                return string.Empty;
            
            return s.GroupBy(_ => _, new CaseInsensitiveLetterComparer()).First(g => g.Count() == 1).Key.ToString();
        }
    }

    public class CaseInsensitiveLetterComparer : IEqualityComparer<char>
    {
        public bool Equals(char a, char b)
        {
            return char.ToLower(a).Equals(char.ToLower(b));
        }

        public int GetHashCode(char c)
        {
            return char.ToLower(c).GetHashCode();
        }
    }

    public class FirstNonRepeatingCharacterTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("stress", "t")]
        [InlineData("moonmen", "e")]
        [InlineData("abcd", "")]
        [InlineData("abcC", "a")]
        [InlineData("sTreSS", "T")]
        public void ExecuteOrderExample(string s, string l)
        {
            FirstNonRepeatingCharacterKata.FirstNonRepeatingLetter(s).Should().Be(l);
        }
    }
}
