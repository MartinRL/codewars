namespace codewars;

using static Convert;

public class HammingDistanceBinaryCodesSolution
{
    public static int CalculateDistance(string a, string b) => (ToInt32(a, 2) ^ ToInt32(b, 2)).ToBinaryString().Count(_ => _ == '1');
}

public class HammingDistanceBinaryCodesTests
{
    [Theory]
    [InlineData("100101", "101001", 2)]
    [InlineData("1010", "0101", 4)]
    [InlineData("100101011011010010010", "101100010110010110101", 9)]
    public void VerifyCalculateDistanceWith(string a, string b, int expectedDistance) => HammingDistanceBinaryCodesSolution.CalculateDistance(a, b).Should().Be(expectedDistance);
}