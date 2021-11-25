namespace codewars;

public class ThinkingAndTestingTrueOrFalseSolution
{
    public static int TestIt(int n) => Convert.ToString(n, 2).Count(_ => _ == '1');
}

public class ThinkingAndTestingTrueOrFalseTests
{
    [Theory]
    [InlineData(0, 0)] // 0
    [InlineData(1, 1)] // 1
    [InlineData(2, 1)] // 10
    [InlineData(3, 2)] // 011
    [InlineData(4, 1)] // 100
    [InlineData(5, 2)] // 0101
    [InlineData(6, 2)] // 0110
    [InlineData(7, 3)] // 0111
    [InlineData(8, 1)]
    [InlineData(9, 2)]
    [InlineData(10, 2)]
    [InlineData(100, 3)]
    [InlineData(1000, 6)]
    [InlineData(10000, 5)]
    public void VerifyTestItWith(int n, int expected) => ThinkingAndTestingTrueOrFalseSolution.TestIt(n).Should().Be(expected);
}