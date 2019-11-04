using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class EnglishBeggarsSolution
    {
        public static int[] Beggars(int[] values, int n)
        {
            var beggars = new int[n];

            if (n == 0)
                return beggars;

            var valueQueue = new Queue<int>(values);

            for (var i = 0; i < values.Length; i++)
            {
                beggars[i % n] += valueQueue.Dequeue();
            }

            return beggars;
        }
    }

    public class EnglishBeggarsTests
    {
        [Theory]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 1, new [] { 15 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 2, new [] { 9, 6 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 3, new [] { 5, 7, 3 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 6, new [] { 1, 2, 3, 4, 5, 0 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 0, new int[] {})]

        public void VerifyBeggarsWith(int[] values, int n, int[] expectedBeggars)
        {
            EnglishBeggarsSolution.Beggars(values, n).Should().BeEquivalentTo(expectedBeggars);
        }
    }
}
