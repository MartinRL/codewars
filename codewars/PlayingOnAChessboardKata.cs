namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PlayingOnAChessboardSolution
    {
        public static string Game(long n) => throw new NotImplementedException();
    }

    public class PlayingOnAChessboardTests
    {
        [Theory]
        [InlineData(0, "[0]")]
        [InlineData(1, "[1, 2]")]
        [InlineData(8, "[32]")]
        public void VerifyGameWith(long n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);
    }
}
