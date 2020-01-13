namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HumanReadableDurationFormatSolution
    {
        public static string FormatDuration(int seconds)
        {
            var duration = new Duration((uint)seconds);

            if (seconds == 0)
                return "now";

            throw new NotImplementedException();
        }

        public class Duration
        {
            private readonly TimeSpan timeSpan;
            private const int year = 365; // days
            private const int day = 24; // hours
            private const int hours = 60; // minutes
            private const int minute = 60; // seconds

            public Duration(uint seconds)
            {
                timeSpan = TimeSpan.FromSeconds(seconds);
            }
        }
    }

    public class HumanReadableDurationFormatTests
    {
        [Theory]
        [InlineData(0, "now")]
        [InlineData(1, "1 second")]
        [InlineData(62, "1 minute and 2 seconds")]
        [InlineData(120, "2 minutes")]
        [InlineData(3662, "1 hour, 1 minute and 2 seconds")]
        [InlineData(15731080, "182 days, 1 hour, 44 minutes and 40 seconds")]
        [InlineData(132030240, "4 years, 68 days, 3 hours and 4 minutes")]
        [InlineData(205851834, "6 years, 192 days, 13 hours, 3 minutes and 54 seconds")]
        [InlineData(253374061, "8 years, 12 days, 13 hours, 41 minutes and 1 second")]
        [InlineData(242062374, "7 years, 246 days, 15 hours, 32 minutes and 54 seconds")]
        [InlineData(101956166, "3 years, 85 days, 1 hour, 9 minutes and 26 seconds")]
        [InlineData(33243586, "1 year, 19 days, 18 hours, 19 minutes and 46 seconds")]
        public void VerifyFormatDurationWith(int seconds, string expectedFormatting) => HumanReadableDurationFormatSolution.FormatDuration(seconds).Should().Be(expectedFormatting);

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 1)]
        [InlineData(62, 0, 0, 0, 1, 2)]
        [InlineData(120, 0, 0, 0, 2, 0)]
        [InlineData(3662, 0, 0, 1, 1, 2)]
        [InlineData(15731080, 0, 182, 1, 44, 40)]
        [InlineData(132030240, 4, 68, 3, 4, 0)]
        [InlineData(205851834, 6, 192, 13, 3, 54)]
        [InlineData(253374061, 8, 12, 13, 41, 1)]
        [InlineData(242062374, 7, 246, 15, 32, 54)]
        [InlineData(101956166, 3, 85, 1, 9, 26)]
        [InlineData(33243586, 1, 19, 18, 19, 46)]
        public void VerifyDurationWith(int seconds, uint expectedYears, uint expectedDays, uint expectedHours, uint expectedMinutes, uint expectedSeconds) =>
            new HumanReadableDurationFormatSolution.Duration((uint)seconds).Should().BeEquivalentTo(
                new
                {
                    Years = expectedYears,
                    Days = expectedDays,
                    Hours = expectedHours,
                    Minutes = expectedMinutes,
                    Seconds = expectedSeconds
                });
    }
}
