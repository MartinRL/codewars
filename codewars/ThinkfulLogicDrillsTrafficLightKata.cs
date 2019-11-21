using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ThinkfulLogicDrillsTrafficLightSolution
    {
        public static string UpdateLight(string current)
        {
            var lights = new LinkedList<string>( new [] { "green", "yellow", "red" });

            return (lights.Find(current).Next ?? lights.First).Value;
        }
    }

    public class ThinkfulLogicDrillsTrafficLightTests
    {
        [Theory]
        [InlineData("green", "yellow")]
        [InlineData("yellow", "red")]
        [InlineData("red", "green")]
        public void VerifyUpdateLightWith(string current, string expectedNext) => ThinkfulLogicDrillsTrafficLightSolution.UpdateLight(current).Should().Be(expectedNext);
    }
}
