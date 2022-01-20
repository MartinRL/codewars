namespace codewars;

internal static class MostProfitFromStockQuoteSolution
{
    public static int GetMostProfitFromStockQuotes(int[] quotes) => throw new NotImplementedException();
}

public class MostProfitFromStockQuoteTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 15)]
    [InlineData(new[] { 6, 5, 4, 3, 2, 1 }, 0)]
    [InlineData(new[] { 1, 6, 5, 10, 8, 7 }, 18)]
    public void VerifyGetMostProfitFromStockQuotesWith(int[] quotes, int expectedMostProfit) => MostProfitFromStockQuoteSolution.GetMostProfitFromStockQuotes(quotes).Should().Be(expectedMostProfit);
}
