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

            if (period == "AM")
            {
                if (hour == "12")
                    throw new NotImplementedException();

                return time.Substring(0, time.Length - period.Length);
            }
            
            throw new NotImplementedException($"time: {time}, period: {period}, hour: {hour}");
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
