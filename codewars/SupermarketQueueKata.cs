using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class SupermarketQueueSolution
    {
        public static long CalculateQueueTime(int[] customers, int n)
        {
            if (customers.Length == 0)
                return 0;

            throw new NotImplementedException();
        }
    }

    public class SupermarketQueueTests
    {
        [Theory]
        [InlineData(new int[] { }, 1, 0)]
        [InlineData(new[] { 1, 2, 3, 4 }, 1, 10)]
        [InlineData(new[] { 2, 2, 3, 3, 4, 4 }, 2, 9)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 100, 5)]
        [InlineData(new [] { 5, 3, 4 }, 1, 12)]
        [InlineData(new [] { 10, 2, 3, 3 }, 2, 10)]
        [InlineData(new [] { 2, 3, 10 }, 2, 12)]
        public void VerifyCalculateQueueTimeWith(int[] customers, int n, long expectedQueueTime) => SupermarketQueueSolution.CalculateQueueTime(customers, n).Should().Be(expectedQueueTime);
    }
}
