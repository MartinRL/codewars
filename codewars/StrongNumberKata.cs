namespace codewars;

public class StrongNumberSolution
{
    private static readonly int[] digitFactorials = new int[10] {0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880};

    public static string StrongNumber(int number) => number == number.ToDigits().Select(d => digitFactorials[d]).Sum() ? "STRONG!!!!" : "Not Strong !!";
}

public class StrongNumberTests
{
    [Theory]
    [InlineData(1, "STRONG!!!!")]
    [InlineData(2, "STRONG!!!!")]
    [InlineData(145, "STRONG!!!!")]
    [InlineData(7, "Not Strong !!")]
    [InlineData(93, "Not Strong !!")]
    [InlineData(185, "Not Strong !!")]
    public void VerifyStrongNumberWith(int number, string strongMsg) => StrongNumberSolution.StrongNumber(number).Should().Be(strongMsg);
}
