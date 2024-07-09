namespace codewars;

public class PowerOfTwoSolution
{
    public static bool IsPowerOfTwo(int n) => n != 0 && ((n - 1) & n) == 0;
}

public class PowerOfTwoTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(4096, true)]
    [InlineData(1024, true)]
    [InlineData(5, false)]
    [InlineData(333, false)]
    [InlineData(1, true)]
    [InlineData(0, false)]
    public void VerifyIsPowerOfTwqWith(int n, bool expected) => PowerOfTwoSolution.IsPowerOfTwo(n).Should().Be(expected);
}
