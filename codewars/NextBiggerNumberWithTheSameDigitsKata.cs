using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NextBiggerNumberWithTheSameDigitsSolution
    {
        public static long CalculateNextBiggerNumber(long n)
        {
            var nAsCharArray = n.ToString().ToCharArray();
            
            if (nAsCharArray.OrderByDescending(_ => _).SequenceEqual(nAsCharArray))
                return -1;

            if (nAsCharArray.OrderBy(_ => _).SequenceEqual(nAsCharArray))
                return long.Parse(new string(nAsCharArray.Swap(nAsCharArray.LastIndex(), nAsCharArray.SecondLastIndex())));

            throw new NotImplementedException();
        }
    }

    public static class NextBiggerNumberWithTheSameDigitsExtensions
    {
        public static T[] Swap<T>(this T[] @this, int firstIndex, int secondIndex)
        {
            Swap(ref @this[firstIndex], ref @this[secondIndex]);

            return @this;
        }
        
        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static int LastIndex<T>(this IEnumerable<T> @this)
        {
            return @this.Count() - 1;
        }
        
        public static int SecondLastIndex<T>(this IEnumerable<T> @this)
        {
            return @this.LastIndex() - 1;
        }
    }

    public class NextBiggerNumberWithTheSameDigitsTests
    {
        [Theory]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(1234, 1243)]
        [InlineData(9, -1)]
        [InlineData(111, -1)]
        [InlineData(531, -1)]
        public void VerifyCalculateNextBiggerNumberWith(long n, long expectedNextBiggerWithTheSameDigits)
        {
            NextBiggerNumberWithTheSameDigitsSolution.CalculateNextBiggerNumber(n).Should().Be(expectedNextBiggerWithTheSameDigits);
        }
    }
}
