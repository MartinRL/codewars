using System;
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
            
            throw new NotImplementedException();
        }
    }
    
    public class YourOrderTests
    {
        [Theory]
        [InlineData("is2 Thi1s T4est 3a", "Thi1s is2 3a T4est")]
        [InlineData("4of Fo1r pe6ople g3ood th5e the2", "Fo1r the2 g3ood 4of th5e pe6ople")]
        [InlineData("", "")]
        public void RunOrderTheory(string s, string expected)
        {
            YourOrderKata.Order(s).Should().Be(expected);
        }
    }
}
