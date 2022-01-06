namespace codewars;

public static class HandshakeProblemSolution
{
    public static int GetParticipants(int handshakes)
    {
        if (handshakes == 0)
            return 1;

        var participants = 2;

        static int possibleHandshakes(int p) => (p * (p - 1)) / 2;

        while (possibleHandshakes(participants) < handshakes)
            ++participants;

        return participants;
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
