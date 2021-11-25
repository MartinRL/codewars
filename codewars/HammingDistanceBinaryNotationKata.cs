namespace codewars;

public class HammingDistanceBinaryNotationSolution
{
    public static int CalculateDistance(int a, int b) => (a ^ b).ToBinaryString().Count(_ => _ == '1');
}

public class HammingDistanceBinaryNotationTests
{
    [Theory]
    [InlineData(25,87, 4)]
    [InlineData(256,302, 4)]
    [InlineData(34013,702, 7)]
    public void VerifyCalculateDistanceWith(int a, int b, int expectedDistance) => HammingDistanceBinaryNotationSolution.CalculateDistance(a, b).Should().Be(expectedDistance);
}