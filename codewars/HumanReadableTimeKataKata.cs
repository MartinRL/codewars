namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class HumanReadableTimeSolution
    {
        public static string GetReadableTime(int seconds) => throw new NotImplementedException();
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
