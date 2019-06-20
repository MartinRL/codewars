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
            
            throw new NotImplementedException();
        }
    }

    public class WhatTimeIsItTests
    {
        [Theory]
        [InlineData("12:00:01AM", "00:00:01")]
        [InlineData("11:46:47PM", "23:46:47")]
        [InlineData("12:00:00AM", "00:00:00")]
        [InlineData("12:00:00PM", "12:00:00")]
        [InlineData("07:05:45PM", "19:05:45")]
        public static void VerifyGetMilitaryTimeFromStandardTime(string time, string expectedMilitaryTime)
        {
            WhatTimeIsItSolution.GetMilitaryTimeFromStandardTime(time).Should().Be(expectedMilitaryTime);
        }
    }
}
