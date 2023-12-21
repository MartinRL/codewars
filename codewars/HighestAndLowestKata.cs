namespace codewars;

using static Int32;

public class HighestAndLowestSolution
{
    public static string HighAndLow(string numbers) => $"{numbers.Split(' ').Select(Parse).Max()} {numbers.Split(' ').Select(Parse).Min()}";
}

public class HighestAndLowestTests
{
    [Theory]
    [InlineData("1 2 3 4 5", "5 1")]
    [InlineData("1 2 -3 4 5", "5 -3")]
    [InlineData("1 9 3 4 -5", "9 -5")]
    [InlineData("8 3 -5 42 1 0 0 -9 4 7 4 -4", "42 -9")]
    [InlineData("1 2 3", "3 1")]
    public void VerifyHighAndLowWith(string numbers, string expectedHighAndLow) => HighestAndLowestSolution.HighAndLow(numbers).Should().Be(expectedHighAndLow);
}
