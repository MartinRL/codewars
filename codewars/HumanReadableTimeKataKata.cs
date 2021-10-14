namespace codewars
{
    using System;
    using System.Linq;
    using static System.TimeSpan;
    using FluentAssertions;
    using Xunit;

    public static class HumanReadableTimeSolution
    {
        public static string GetReadableTime(int seconds)
        {
            if (seconds <= 60 * 60 * 24)
                return FromSeconds(seconds).ToString();

            var daysAndTheRest = FromSeconds(seconds).ToString().Split('.');
            var days = daysAndTheRest[0];
            var theRest = daysAndTheRest[1].Split(':');
            var hrs = int.Parse(theRest[0]) + int.Parse(days) * 24;
            var mins = theRest[1];
            var secs = theRest[2];

            return $"{hrs}:{mins}:{secs}";
        }
    }

    public class HumanReadableTimeTests
    {
        [Theory]
        [InlineData(0, "00:00:00")]
        [InlineData(5, "00:00:05")]
        [InlineData(60, "00:01:00")]
        [InlineData(86399, "23:59:59")]
        [InlineData(359999, "99:59:59")]
        public void VerifyGetReadableTimeWith(int seconds, string expectedReadableTime) => HumanReadableTimeSolution.GetReadableTime(seconds).Should().Be(expectedReadableTime);
    }
}
