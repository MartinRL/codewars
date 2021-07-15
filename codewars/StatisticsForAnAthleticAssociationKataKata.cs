namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class StatisticsForAnAthleticAssociationSolution
    {
        public static string CalculateStats(string teamResults)
        {
            var results = teamResults.Split(", ")
                .Select(r => r.Split('|').Select(int.Parse))
                .Select(r => new TimeSpan(r.First(), r.ElementAt(1), r.Last()));

            var range = results.Max() - results.Min();
            var average = results.Aggregate((sum, r) => sum = sum.Add(r)) / results.Count();

            return $"Range: {range.ToString().Replace(':', '|')} Average: {average.ToString().Substring(0, 8).Replace(':', '|')}";
        }
    }

    public class StatisticsForAnAthleticAssociationTests
    {
        [Theory]
        [InlineData("01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17", "Range: 01|01|18 Average: 01|38|05 Median: 01|32|34")]
        [InlineData("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41", "Range: 00|31|17 Average: 02|26|18 Median: 02|22|00")]
        public void VerifyCalculateStatsWith(string teamResults, string expectedStats) => StatisticsForAnAthleticAssociationSolution.CalculateStats(teamResults).Should().Be(expectedStats);
    }
}
