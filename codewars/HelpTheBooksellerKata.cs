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
            throw new NotImplementedException();
        }
    }

    public class HelpTheBooksellerTests
    {
        [Fact]
        public void VerifyStockSummaryWith() => HelpTheBooksellerSolution.StockSummary(new[] {"ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600"}, new[] {"A", "B"}).Should().Be("(A : 200) - (B : 1140)");
    }
}
