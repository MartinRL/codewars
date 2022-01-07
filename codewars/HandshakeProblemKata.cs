namespace codewars;

using static System.Math;

public static class HandshakeProblemSolution
{
    public static int GetParticipants(int handshakes) => (int) Ceiling((1 + Sqrt(1 + 8 * handshakes)) / 2);
}

public class HandshakeProblemTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    [InlineData(6, 4)]
    [InlineData(7, 5)]
    public void VerifyGetParticipantsWith(int handshakes, int expectedParticipants) 
        => HandshakeProblemSolution.GetParticipants(handshakes).Should().Be(expectedParticipants);
}
