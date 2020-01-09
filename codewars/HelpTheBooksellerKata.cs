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
            if (!lstOfArt.Any() || !lstOf1stLetter.Any())
                return string.Empty;

            var groupedAndSummedBy1stLetter = lstOfArt
                .Select(_ => _.Split(' '))
                .GroupBy(_ => _[0].First().ToString(), _ => Convert.ToInt32(_[1]))
                .ToDictionary(g => g.Key, g => g.Sum());

            return lstOf1stLetter
                .Select(letter => "(" + letter + " : " + (groupedAndSummedBy1stLetter.ContainsKey(letter) ? groupedAndSummedBy1stLetter[letter] : 0) + ")")
                .Aggregate((r, _) => r + " - " + _);
        }
    }

    public class HelpTheBooksellerTests
    {
        [Fact]
        public void ShouldCreateStockSummary() => HelpTheBooksellerSolution.StockSummary(new[] {"ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600"}, new[] {"A", "B"}).Should().Be("(A : 200) - (B : 1140)");

        [Fact]
        public void ShouldNotCreateStockSummary() => HelpTheBooksellerSolution.StockSummary(new string [0], new[] {"A", "B"}).Should().Be(string.Empty);

        [Fact]
        public void ShouldNotCreateStockSummary2() => HelpTheBooksellerSolution.StockSummary(new[] {"ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600"}, new string[0]).Should().Be(string.Empty);
    }
}
