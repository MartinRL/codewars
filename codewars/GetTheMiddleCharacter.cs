using System;
using FluentAssertions;
using Xunit;


namespace codewars
{
    public static class GetTheMiddleCharacterKata
    {
        public static string GetMiddle(string s)
        {
            //TODO
        }
    }
    
    public class GetTheMiddleCharacterTests
    {
        [Theory]
        [InlineData("test", "es")]
        [InlineData("testing", "t")]
        [InlineData("middle", "dd")]
        [InlineData("A", "A")]
        public void RunGetMiddleTheory(string argument, string expected)
        {
            GetTheMiddleCharacterKata.GetMiddle(argument).Should().Be(expected);
        }
    }
}
