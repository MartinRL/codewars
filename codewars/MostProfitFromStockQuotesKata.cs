namespace codewars;

internal static class MostProfitFromStockQuoteSolution
{
    public static int GetMostProfitFromStockQuotes(int[] quotes)
    {
        Array.Reverse(quotes);
        var currentHigh = quotes[0];
        var mostProfit = 0;

        for (int i = 1; i < quotes.Length; i++)
        {
            if (currentHigh > quotes[i])
                mostProfit += currentHigh - quotes[i];
            else
                currentHigh = quotes[i];
        }

        return mostProfit;
    }
}

public class MostProfitFromStockQuoteTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 15)]
    // buy at 1,2,3,4,5 and then sell all at 6
    //   1, 2, 3, 4, 5, 6
    // Σ 5, 4, 3, 2, 1 = 15
    [InlineData(new[] { 6, 5, 4, 3, 2, 1 }, 0)]
    // nothing to buy for profit
    [InlineData(new[] { 1, 6, 5, 10, 8, 7 }, 18)]
    // buy at 1,6,5 and sell all at 10
    //   1, 6, 5, 10, 8, 7
    // Σ 9, 4, 5 = 18
    [InlineData(new[] { 1, 2, 10, 3, 2, 7, 3, 2 }, 26)]
    // buy at 1,2 and sell them at 10. Then buy at 3,2 and sell them at 7
    //   1, 2, 10, 3, 2, 7, 3, 2
    // Σ 9, 8      4, 5 = 26
    public void VerifyGetMostProfitFromStockQuotesWith(int[] quotes, int expectedMostProfit) => MostProfitFromStockQuoteSolution.GetMostProfitFromStockQuotes(quotes).Should().Be(expectedMostProfit);
}
