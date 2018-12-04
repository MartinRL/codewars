using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class YourOrderKata
    {
        public static string Order(string words)
        {
            if (string.IsNullOrEmpty(words))
                return string.Empty;

            return string.Join(" ", 
                words
                .Split(' ')
                .OrderBy(s => s.First(char.IsDigit)));
        }
    }
    
    public class YourOrderTests
    {
        [Theory]
        [InlineData("is2 Thi1s T4est 3a", "Thi1s is2 3a T4est")]
        [InlineData("4of Fo1r pe6ople g3ood th5e the2", "Fo1r the2 g3ood 4of th5e pe6ople")]
        [InlineData("", "")]
        public void RunOrderTheory(string words, string orderedWords)
        {
            YourOrderKata.Order(words).Should().Be(orderedWords);
        }
    }
}
