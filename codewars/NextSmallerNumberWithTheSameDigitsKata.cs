using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NextSmallerNumberWithTheSameDigitsSolution
    {
        public static long NextSmaller(long n)
        {
            var nAsCharArray = n.ToString().ToCharArray();

            var next = n + 1;
            var i = nAsCharArray.Length - 1;

            while (next > n)
            {
                swap(ref nAsCharArray[i], ref nAsCharArray[i - 1]);
                next = long.Parse(new string(nAsCharArray));
                i--;
            }

            return next;
        }
        
        static void swap(ref char a, ref char b)
        {
            var temp = a;
            a = b;
            b = temp;
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
        public void VerifyNextSmallerWith(long n, long expectedNextSmaller)
        {
            NextSmallerNumberWithTheSameDigitsSolution.NextSmaller(n).Should().Be(expectedNextSmaller);
        }
    }
}
