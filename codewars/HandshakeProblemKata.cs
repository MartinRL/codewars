namespace codewars;

public static class HandshakeProblemSolution
{
    public static int GetParticipants(int handshakes)
    {
        if (handshakes == 0)
            return 1;

        if (handshakes == 1)
            return 2;

        throw new NotImplementedException();
    }
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
