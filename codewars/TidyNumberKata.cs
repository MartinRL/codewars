namespace codewars;

public class TidyNumberSolution
{
    public static bool TidyNumber(int n) => n.ToString() == new string(n.ToString().OrderBy(_ => _).ToArray());
}

public class TidyNumberTests
{
    [Theory]
    [InlineData(12, true)]
    [InlineData(2789, true)]
    [InlineData(2335, true)]
    [InlineData(102, false)]
    [InlineData(9672, false)]
    public void VerifyTidyNumberWith(int n, bool expected) => TidyNumberSolution.TidyNumber(n).Should().Be(expected);
}