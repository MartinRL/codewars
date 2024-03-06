namespace codewars;

using System.Numerics;

public class DisguisedSequencesIISolution
{
    public static BigInteger U1(int n, int p) => (new BigInteger(n + 1)) * p;

    public static BigInteger V1(int n, int p) => 2 * (new BigInteger(n)) * p + p;

}

public class DisguisedSequencesIITests
{
    [Fact]
    public void VerifyU1() => DisguisedSequencesIISolution.U1(13, 18).Should().Be(new BigInteger(252));

    [Fact]
    public void VerifyV1() => DisguisedSequencesIISolution.V1(16, 68).Should().Be(new BigInteger(2244));
}