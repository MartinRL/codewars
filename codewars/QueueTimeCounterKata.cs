namespace codewars;

public class QueueTimeCounterSolution
{
    public static int CalculateQueueTime(int[] queuers, int pos)
    {
        IEnumerable<int> currentQueuers = queuers;
        var counter = 0;
        bool IsStillQueueing(int queuer) => queuer > 0;

        while (currentQueuers.ElementAt(pos) > 1)
        {
            counter += currentQueuers.Count(IsStillQueueing);
            currentQueuers = currentQueuers.Select(_ => _ - 1);
        }

        return counter + currentQueuers.Take(pos + 1).Count(IsStillQueueing);
    }
}

public class QueueTimeCounterTests
{
    [Theory]
    [InlineData(new[] { 2, 5, 3, 6, 4 }, 0, 6)]
    [InlineData(new[] { 2, 5, 3, 6, 4 }, 1, 18)]
    [InlineData(new[] { 2, 5, 3, 6, 4 }, 2, 12)]
    [InlineData(new[] { 2, 5, 3, 6, 4 }, 3, 20)]
    [InlineData(new[] { 2, 5, 3, 6, 4 }, 4, 17)]
    public void VerifyCalculateQueueTimeWith(int[] queuers, int pos, int expectedQueueTime) => QueueTimeCounterSolution.CalculateQueueTime(queuers, pos).Should().Be(expectedQueueTime);
}