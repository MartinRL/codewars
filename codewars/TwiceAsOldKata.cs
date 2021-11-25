namespace codewars;

public class TwiceAsOldSolution
{
    public static int TwiceAsOld(int dadYears, int sonYears) => Math.Abs(dadYears - sonYears * 2);
}

public class TwiceAsOldTests
{
    [Theory]
    [InlineData(30, 0, 30)]
    [InlineData(30, 7, 16)]
    [InlineData(45, 30, 15)]
    public void VerifyTwiceAsOldWith(int dadYears, int sonYears, int expectedYears) => TwiceAsOldSolution.TwiceAsOld(dadYears, sonYears).Should().Be(expectedYears);
}