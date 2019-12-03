namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SupermarketQueueSolution
    {
        public static long CalculateQueueTime(int[] customers, int n)
        {
            if (n == 1)
                return customers.Sum();

            if (n >= customers.Length)
                return customers.Max();

            var customerQueue = new Queue<int>(customers);

            var tills = new int[n];

            var counter = 0;

            while (customerQueue.Any())
            {
                for (var i = 0; i < n; i++)
                {
                    if (tills[i] - 1 <= 0)
                    {
                        if (customerQueue.Any())
                        {
                            tills[i] = customerQueue.Dequeue();
                        }
                    }
                    else
                    {
                        tills[i]--;
                    }
                }

                counter++;
            }

            return counter + tills.Max() - 1;
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
