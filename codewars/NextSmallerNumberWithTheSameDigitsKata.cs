using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NextSmallerNumberWithTheSameDigitsSolution
    {
        public static long NextSmaller(long n)
        {
            IEnumerable<long> CreateNumbers()
            {
                var i = n;

                while (i >= 0) yield return --i;
            }

            var firstOrDefault = CreateNumbers().FirstOrDefault(t => t.ToString().OrderBy(_ => _).SequenceEqual(n.ToString().OrderBy(_ => _)));
            
            return firstOrDefault != default ? firstOrDefault : -1;
        }
    }

    public class NextSmallerNumberWithTheSameDigitsTests
    {
        [Theory]
        [InlineData(21, 12)]
        [InlineData(907, 790)]
        [InlineData(531, 513)]
        [InlineData(1027, -1)]
        [InlineData(441, 414)]
        [InlineData(123456798, 123456789)]
        [InlineData(29009, 20990)]
        [InlineData(315, 153)]
        [InlineData(1207, 1072)]
        [InlineData(59884848483559, 59884848459853)]
        [InlineData(51226262651257, 51226262627551)]
        public void VerifyNextSmallerWith(long n, long expectedNextSmaller)
        {
            NextSmallerNumberWithTheSameDigitsSolution.NextSmaller(n).Should().Be(expectedNextSmaller);
        }
    }
}
