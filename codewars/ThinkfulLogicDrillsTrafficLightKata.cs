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
            throw new NotImplementedException();
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
