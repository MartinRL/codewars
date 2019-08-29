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
            
            // If all digits sorted in descending order, then output is -1. For example, 4321
            if (nAsCharArray.OrderByDescending(_ => _).SequenceEqual(nAsCharArray))
                return -1;

            // If all digits are sorted in ascending order, then we need to swap last two digits. For example, 1234
            if (nAsCharArray.OrderBy(_ => _).SequenceEqual(nAsCharArray))
                return long.Parse(new string(nAsCharArray.Swap(nAsCharArray.LastIndex(), nAsCharArray.SecondLastIndex())));

            // I) Traverse the given number from rightmost digit, keep traversing till you find a digit which is smaller than the previously traversed digit. For example, if the input number is “534976”, we stop at 4 because 4 is smaller than next digit 9. If we do not find such a digit, then output is -1.
            var d = nAsCharArray[nAsCharArray.LastIndex()];
            var i = nAsCharArray.SecondLastIndex();

            while (d < nAsCharArray[i])
            {
                d = nAsCharArray[i];
                --i;
            }

            d = nAsCharArray[i];

            // II) Now search the right side of above found digit ‘d’ for the smallest digit greater than ‘d’. For “534976″, the right side of 4 contains “976”. The smallest digit greater than 4 is 6.
            var subArrayToTheRightOfDigit = nAsCharArray.SubArray(i + 1);

            var smallestGreaterThanDigit = subArrayToTheRightOfDigit.Where(_ => _ > d).Min();
            var indexOfSmallestGraterThanDigit = Array.LastIndexOf(nAsCharArray, smallestGreaterThanDigit);

            // III) Swap the above found two digits, we get 536974 in above example.
            var nWithDigitsSwapped = nAsCharArray.Swap(i, indexOfSmallestGraterThanDigit);
            
            // IV) Now sort all digits from position next to ‘d’ to the end of number. The number that we get after sorting is the output. For above example, we sort digits in bold 536974. We get “536479” which is the next greater number for input 534976.
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
