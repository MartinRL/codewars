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

            var d = nAsCharArray[nAsCharArray.LastIndex()];
            var i = nAsCharArray.SecondLastIndex();

            while (d < nAsCharArray[i])
            {
                d = nAsCharArray[i];
                --i;
            }

            d = nAsCharArray[i];

            var subArrayToTheRightOfDigit = nAsCharArray.SubArray(i + 1);

            var smallestGreaterThanDigit = subArrayToTheRightOfDigit.Where(_ => _ > d).Min();
            var indexOfSmallestGraterThanDigit = Array.LastIndexOf(nAsCharArray, smallestGreaterThanDigit);

            var nWithDigitsSwapped = nAsCharArray.Swap(i, indexOfSmallestGraterThanDigit);
            
            var sortedRightOfDigit = nWithDigitsSwapped.SubArray(i + 1).OrderBy(_ => _);

            return long.Parse(new string(nWithDigitsSwapped
                .SubArray(0, nWithDigitsSwapped.Length - sortedRightOfDigit.Count()).Concat(sortedRightOfDigit)
                .ToArray()));
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
        
        public static T[] SubArray<T>(this T[] @this, int index, int length = -1)
        {
            var l = length == -1 ? @this.Length - index : length;
            
            var result = new T[l];
            Array.Copy(@this, index, result, 0, l);
            
            return result;
        }
    }

    public class NextBiggerNumberWithTheSameDigitsTests
    {
        [Theory]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(1234, 1243)]
        [InlineData(534976, 536479)]
        [InlineData(9, -1)]
        [InlineData(111, -1)]
        [InlineData(531, -1)]
        public void VerifyCalculateNextBiggerNumberWith(long n, long expectedNextBiggerWithTheSameDigits)
        {
            NextBiggerNumberWithTheSameDigitsSolution.CalculateNextBiggerNumber(n).Should().Be(expectedNextBiggerWithTheSameDigits);
        }
    }
}
