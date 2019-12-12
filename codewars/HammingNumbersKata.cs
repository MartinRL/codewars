namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;
    using static System.Math;

    public class HammingNumbersSolution
    {
        public static long CalculateSmallestFor(int n)
        {
            var pertinents = new SortedSet<long> {1};

            for (var i = 1; i < n; i++)
            {

            }

            return pertinents.First();

            // stolen from https://rosettacode.org/wiki/Hamming_numbers#C.23
            /*const long two = 2;
            const long three = 3;
            const long five = 5;

            var h = new long[n];
            h[0] = 1;
            long x2 = 2, x3 = 3, x5 = 5;
            int i = 0, j = 0, k = 0;

            for (var index = 1; index < n; index++)
            {
                h[index] = Min(x2, Min(x3, x5));
                if (h[index] == x2) x2 = two * h[++i];
                if (h[index] == x3) x3 = three * h[++j];
                if (h[index] == x5) x5 = five * h[++k];
            }

            return h[n - 1];*/
        }
    }

    public class HammingNumbersTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(7, 8)]
        [InlineData(8, 9)]
        [InlineData(9, 10)]
        [InlineData(10, 12)]
        [InlineData(11, 15)]
        [InlineData(12, 16)]
        [InlineData(13, 18)]
        [InlineData(14, 20)]
        [InlineData(15, 24)]
        [InlineData(16, 25)]
        [InlineData(17, 27)]
        [InlineData(18, 30)]
        [InlineData(19, 32)]
        public void VerifyCalculateSmallestForWith(int n, long expectedSmallestHammingNumber) => HammingNumbersSolution.CalculateSmallestFor(n).Should().Be(expectedSmallestHammingNumber);
    }
}
