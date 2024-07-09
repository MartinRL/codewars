namespace codewars;

public class PlayingOnAChessboardSolution
{
    public static string Game(long n) => (n % 2) switch
    {
        0 => $"[{n * n / 2}]",
        _ => $"[{n * n}, 2]"
    };
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
    public void VerifyGameWith(long n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);
}
