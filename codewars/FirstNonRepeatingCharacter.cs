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
            
            return s.GroupBy(g => new Letter(g)).First(g => g.Count() == 1).Key.ToString();
        }
    }

    public class Letter
    {
        private readonly char letter;

        public Letter(char letter)
        {
            this.letter = letter;
        }

        protected bool Equals(Letter other)
        {
            return char.ToLower(letter) == char.ToLower(other.letter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            return obj.GetType() == GetType() && Equals((Letter) obj);
        }

        public override int GetHashCode()
        {
            return char.ToLower(letter).GetHashCode();
        }

        public override string ToString()
        {
            return letter.ToString();
        }
    }

    public class FirstNonRepeatingCharacterTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("stress", "t")]
        [InlineData("moonmen", "e")]
        [InlineData("SsT", "T")]
        public void ExecuteOrderExample(string s, string l)
        {
            FirstNonRepeatingCharacterKata.FirstNonRepeatingLetter(s).Should().Be(l);
        }
    }
}
