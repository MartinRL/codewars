namespace codewars;

public class ReversedSequenceSolution
{
    public static int[] ReverseSeq(int n) => [.. Enumerable.Range(1, n).Reverse()];
}

public class ReversedSequenceTests
{
    [Fact]
    public void VerifyReverseSeq() => ReversedSequenceSolution.ReverseSeq(5).Should().BeEquivalentTo(new[] { 5, 4, 3, 2, 1 });
}
