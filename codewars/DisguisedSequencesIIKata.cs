namespace codewars
{
    using System;
    using System.Numerics;
    using FluentAssertions;
    using Xunit;

    public class DisguisedSequencesIISolution
    {
        public static BigInteger U1(int n, int p)
        {
            BigInteger result = 0;

            for (var k = 0; k <= n; k++)
            {
                result += BigInteger.Pow(-1, k) * p * BigInteger.Pow(4, n - k) * (2 * n - k + 1).Choose(k);
            }

            return result;
        }

        public static BigInteger V1(int n, int p)
        {
            BigInteger result = 0;

            for (var k = 0; k <= n; k++)
            {
                result += BigInteger.Pow(-1, k) * p * BigInteger.Pow(4, n - k) * (2 * n - k).Choose(k);
            }

            return result;
        }
    }

    public static class DisguisedSequencesIIExtensions
    {
        public static BigInteger Choose(this int @this, int k)
        {
            BigInteger result = 1;

            for (var i = 1; i <= k; i++)
            {
                result *= @this - (k - i);
                result /= i;
            }

            return result;
        }
    }


    public class DisguisedSequencesIITests
    {
        [Theory]
        [InlineData(13, 18, "252")]
        public void VerifyU1With(int n, int p, string expected) => DisguisedSequencesIISolution.U1(n, p).Should().Be(BigInteger.Parse(expected));

        [Theory]
        [InlineData(16, 68, "2244")]
        public void VerifyV1With(int n, int p, string expected) => DisguisedSequencesIISolution.V1(n, p).Should().Be(BigInteger.Parse(expected));

        [Theory]
        [InlineData(5, 3, 10)]
        public void VerifyChooseWith(int n, int k, int expected) => n.Choose(k).Should().Be(expected);
    }
}
