namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class QueueTimeCounterSolution
    {
        public static int CalculateQueueTime(int[] queuers, int pos)
        {
            var currentQueuers = queuers;
            var counter = 0;

            while (currentQueuers[pos] > 1)
            {
                counter += currentQueuers.Count(_ => _ > 0);
                currentQueuers = currentQueuers.Select(_ => _ - 1).ToArray();
            }

            return counter + currentQueuers[pos];
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
}
