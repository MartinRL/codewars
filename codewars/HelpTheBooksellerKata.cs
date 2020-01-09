namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HelpTheBooksellerSolution
    {
        public static string StockSummary(string[] lstOfArt, string[] lstOf1stLetter)
        {
            if (!lstOfArt.Any())
                return string.Empty;

            var groupedAndSummedBy1stLetter = lstOfArt.Select(_ => _.Split(' '))
                .GroupBy(_ => _[0].First().ToString(), _ => Convert.ToInt32(_[1]))
                .Select(group => new { Label = group.Key, Total = group.Sum()});

            return lstOf1stLetter
                .Select(letter => $"({letter} : {groupedAndSummedBy1stLetter.Where(_ => _.Label == letter).Sum(_ => _.Total)})")
                .Aggregate((r, _) => r + " - " + _);
        }
    }

    public class HelpTheBooksellerTests
    {
        [Fact]
        public void ShouldCreateStockSummary() => HelpTheBooksellerSolution.StockSummary(new[] {"ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600"}, new[] {"A", "B"}).Should().Be("(A : 200) - (B : 1140)");

        [Fact]
        public void ShouldNotCreateStockSummary() => HelpTheBooksellerSolution.StockSummary(new string [] {}, new[] {"A", "B"}).Should().Be(string.Empty);
    }
}
