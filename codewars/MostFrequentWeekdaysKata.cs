namespace codewars
{
    using System;
    using static System.DateTime;
    using FluentAssertions;
    using Xunit;

    public class MostFrequentWeekdaysSolution
    {
        public static string[] GetMostFrequentDaysOf(int year)
        {
            var firstDateOfYear = new DateTime(year, 01, 01);

            switch (IsLeapYear(year))
            {
                case true when firstDateOfYear.DayOfWeek == DayOfWeek.Sunday:
                    return new []{DayOfWeek.Monday.ToString(), DayOfWeek.Sunday.ToString()};
                case true when firstDateOfYear.DayOfWeek != DayOfWeek.Sunday:
                    return new[] {firstDateOfYear.DayOfWeek.ToString(), firstDateOfYear.AddDays(1).DayOfWeek.ToString()};
                default:
                    return new[] {firstDateOfYear.DayOfWeek.ToString()};
            }
        }

        public static string[] GetMostFrequentDaysOf_(int year)
        {
            var firstDateOfYear = new DateTime(year, 01, 01);

            if (!IsLeapYear(year))
                return new[] {firstDateOfYear.DayOfWeek.ToString()};

            if (firstDateOfYear.DayOfWeek == DayOfWeek.Sunday)
                return new []{DayOfWeek.Monday.ToString(), DayOfWeek.Sunday.ToString()};

            return new[] {firstDateOfYear.DayOfWeek.ToString(), firstDateOfYear.AddDays(1).DayOfWeek.ToString()};
        }
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
}
