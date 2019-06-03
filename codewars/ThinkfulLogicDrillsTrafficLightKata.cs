using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ThinkfulLogicDrillsTrafficLightSolution
    {
        public static string UpdateLight(string current)
        {
            switch (current)
            {
                case "yellow":
                    return "green";
                
                case "red":
                    return "yellow";
                
                case "green":
                    return "red";
                
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class ThinkfulLogicDrillsTrafficLightTests
    {
        [Theory]
        [InlineData("yellow", "green")]
        [InlineData("red", "yellow")]
        [InlineData("green", "red")]
        public void VerifyUpdateLightWith(string current, string expectedNext)
        {
            ThinkfulLogicDrillsTrafficLightSolution.UpdateLight(current).Should().Be(expectedNext);
        }
    }
}
