namespace codewars;

public class ThinkingAndTestingAAndBSolution
{
    public static int TestIt(int a, int b) => a | b;
}

public class ThinkingAndTestingAAndBTests
{
    [Theory]
    // 0
    // 1
    // 1
    [InlineData(0, 1, 1)]
    // 01
    // 10
    // 11
    [InlineData(1, 2, 3)]
    // 01010
    // 10100
    // 11110
    [InlineData(10, 20, 30)]
    // 1
    // 1
    // 1
    [InlineData(1, 1, 1)]
    // 01
    // 11
    // 11
    [InlineData(1, 3, 3)]
    public void VerifyTestItWith(int a, int b, int expected) => ThinkingAndTestingAAndBSolution.TestIt(a, b).Should().Be(expected);
}