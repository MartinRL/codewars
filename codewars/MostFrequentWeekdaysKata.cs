namespace codewars;

using System;
using static System.DateTime;
using FluentAssertions;
using Xunit;

public class MostFrequentWeekdaysSolution
{
    public static string[] GetMostFrequentDaysOf(int year) => IsLeapYear(year) switch
    {
        true when year.January1st().DayOfWeek == DayOfWeek.Sunday => new[] {DayOfWeek.Monday.ToString(), DayOfWeek.Sunday.ToString()},
        true when year.January1st().DayOfWeek != DayOfWeek.Sunday => new[] {year.January1st().DayOfWeek.ToString(), year.January1st().AddDays(1).DayOfWeek.ToString()},
        _ => new[] {year.January1st().DayOfWeek.ToString()}
    };
}

public static class MostFrequentWeekdaysExtensions
{
    public static DateTime January1st(this int @this) => new DateTime(@this, 01, 01);
}

public class MostFrequentWeekdaysTests
{
    [Theory]
    [InlineData(2427, new[] {"Friday"})]
    [InlineData(2185, new[] {"Saturday"})]
    [InlineData(2860, new[] {"Thursday", "Friday"})]
    [InlineData(2016, new[] {"Friday", "Saturday"})]
    [InlineData(1770, new[] {"Monday"})]
    [InlineData(2001, new[] {"Monday"})]
    [InlineData(1968, new[] {"Monday", "Tuesday"})]
    [InlineData(1888, new[] {"Monday", "Sunday"})]
    [InlineData(1785, new[] {"Saturday"})]
    [InlineData(1910, new[] {"Saturday"})]
    [InlineData(2135, new[] {"Saturday"})]
    [InlineData(3043, new[] {"Sunday"})]
    [InlineData(3150, new[] {"Sunday"})]
    [InlineData(3361, new[] {"Thursday"})]
    [InlineData(1901, new[] {"Tuesday"})]
    [InlineData(3230, new[] {"Tuesday"})]
    [InlineData(1794, new[] {"Wednesday"})]
    [InlineData(1986, new[] {"Wednesday"})]
    public void VerifyMostFrequentDaysWith(int year, string[] expectedWeekdays) =>
        MostFrequentWeekdaysSolution.GetMostFrequentDaysOf(year).Should().Equal(expectedWeekdays);
}