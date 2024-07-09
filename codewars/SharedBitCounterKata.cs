namespace codewars;

public class SharedBitCounterSolution
{
    public static bool HasSharedBits(int a, int b) => (a &= b) != 0 && (a &= a - 1) != 0;
}

public class SharedBitCounterTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(16, 18)]
    [InlineData(1, 1)]
    [InlineData(2, 3)]
    public void VerifyHaveNotSharedBitsWith(int a, int b) => SharedBitCounterSolution.HasSharedBits(a, b).Should().BeFalse();

    [Theory]
    [InlineData(43, 77)]
    [InlineData(7, 15)]
    [InlineData(23, 7)]
    public void VerifyHaveSharedBitsWith(int a, int b) => SharedBitCounterSolution.HasSharedBits(a, b).Should().BeTrue();
}
