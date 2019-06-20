using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class WhatTimeIsItSolution
    {
        public static string GetMilitaryTimeFromStandardTime(string time)
        {
            // NB. Not allowed to use System.DateTime.

            var period = time.Substring(time.Length - 2);
            var hour = time.Substring(0, 2);
            var timeWithRemovedPeriod = time.Substring(0, time.Length - period.Length);

            if (period == "AM")
                return hour != "12" ? timeWithRemovedPeriod : "00" + timeWithRemovedPeriod.Substring(2);

            return hour != "12" ? $"{byte.Parse(hour) + 12}{timeWithRemovedPeriod.Substring(2)}" : timeWithRemovedPeriod;
        }
    }

    public class WhatTimeIsItTests
    {
        [Theory]
        [InlineData("12:00:01AM", "00:00:01")]
        [InlineData("11:46:47PM", "23:46:47")]
        [InlineData("11:46:47AM", "11:46:47")]
        [InlineData("12:00:00AM", "00:00:00")]
        [InlineData("12:00:00PM", "12:00:00")]
        [InlineData("07:05:45PM", "19:05:45")]
        public static void VerifyGetMilitaryTimeFromStandardTime(string time, string expectedMilitaryTime)
        {
            WhatTimeIsItSolution.GetMilitaryTimeFromStandardTime(time).Should().Be(expectedMilitaryTime);
        }
    }
}
