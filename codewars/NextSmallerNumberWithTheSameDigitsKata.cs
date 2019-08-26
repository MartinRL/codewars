using System;
using System.Collections;
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
            return prnPermut(n.ToString().ToCharArray(), 0, n.ToString().Length - 1)
                .Select(_ => new string(_))
                .OrderByDescending(_ => _)
                .Select(long.Parse)
                .First(_ => _ < n);
        }

        public static void Swap (ref char a, ref char b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
        
        public static IEnumerable<char[]> prnPermut(char[] list, int k, int m)
        {
            var permutations = new List<char[]>();
            int i;
            if (k == m)
            { 
                for (i = 0; i <= m; i++)
                    permutations.Add(list);
            }
            else
                for (i = k; i <= m; i++)
                {
                    Swap (ref list [k], ref list [i]);
                    prnPermut (list, k+1, m);
                    Swap (ref list [k], ref list [i]);
                }
            
            return permutations;
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
