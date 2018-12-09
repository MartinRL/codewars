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
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            var groupByChar = s.GroupBy(_ => _, new CaseInsensitiveLetterComparer());
            
            if (groupByChar.All(g => g.Count() > 1))
                return string.Empty;

            return groupByChar.FirstOrDefault(g => g.Count() == 1).Key.ToString();
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
        [InlineData("__D ", "D")]
        [InlineData("adDkp ", "a")]
        [InlineData("  D", "D")]
        [InlineData("s S B", "B")]
        [InlineData("a", "a")]
        [InlineData("stress", "t")]
        [InlineData("moonmen", "e")]
        [InlineData("abcd", "a")]
        [InlineData("aabBCc", "")]
        [InlineData("abcC", "a")]
        [InlineData("sTreSS", "T")]
        [InlineData("sStT", "")]
        public void ExecuteOrderExample(string s, string l)
        {
            FirstNonRepeatingCharacterKata.FirstNonRepeatingLetter(s).Should().Be(l);
        }
    }
}
