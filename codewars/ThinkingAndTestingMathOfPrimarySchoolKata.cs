namespace codewars;

public class ThinkingAndTestingMathOfPrimarySchoolSolution
{
    public static int TestIt(int[] a) => a[0] * a[3] + a[1] * a[2];
}

public class ThinkingAndTestingMathOfPrimarySchoolTests
{
    [Theory]
    [InlineData(new[] {0, 0, 0, 0}, 0)]
    [InlineData(new[] {0, 0, 0, 1}, 0)]
    [InlineData(new[] {0, 0, 1, 1}, 0)]
    [InlineData(new[] {0, 1, 0, 1}, 0)]
    [InlineData(new[] {0, 1, 1, 0}, 1)]
    [InlineData(new[] {1, 0, 0, 1}, 1)]
    public void VerifyTestItWith(int[] a, int expected) => ThinkingAndTestingMathOfPrimarySchoolSolution.TestIt(a).Should().Be(expected);
}
