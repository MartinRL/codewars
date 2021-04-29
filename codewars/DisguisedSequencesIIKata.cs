namespace codewars
{
    using System;
    using System.Linq;
    using System.Numerics;
    using FluentAssertions;
    using Xunit;

    public class DisguisedSequencesIISolution
    {
        public static BigInteger U1(int n, int p) => Enumerable.Range(0, n).Select(k => (int)Math.Pow(-1, k) * p * (int)Math.Pow(4, n - k)).Sum();

        public static BigInteger V1(int n, int p) => throw new NotImplementedException();
    }

    public class DisguisedSequencesIITests
    {
        [Theory]
        [InlineData(13, 18, "252")]
        public void VerifyU1With(int n, int p, string expected) => DisguisedSequencesIISolution.U1(n, p).Should().Be(BigInteger.Parse(expected));

        [Theory]
        [InlineData(16, 68, "2244")]
        public void VerifyV1With(int n, int p, string expected) => DisguisedSequencesIISolution.V1(n, p).Should().Be(BigInteger.Parse(expected));
    }
}
