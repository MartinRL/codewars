namespace codewars
{
    using System;
    using System.Numerics;
    using FluentAssertions;
    using Xunit;

    public class PlayingOnAChessboardSolution
    {
        public static string Game(BigInteger n)
        {
            if (n == 0)
                return "[0]";

            if (n % 2 == 0)
                return $"[{n * n / 2}]";

            return $"[{n * n}, 2]";
        }
    }

    public class PlayingOnAChessboardTests
    {
        [Theory]
        [InlineData(0, "[0]")]
        [InlineData(1, "[1, 2]")]
        [InlineData(2, "[2]")]
        [InlineData(3, "[9, 2]")]
        [InlineData(4, "[8]")]
        [InlineData(5, "[25, 2]")]
        [InlineData(6, "[18]")]
        [InlineData(7, "[49, 2]")]
        [InlineData(8, "[32]")]
        //[InlineData(10000, "dummy")]
        public void VerifyGameWith(BigInteger n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);
    }
}
