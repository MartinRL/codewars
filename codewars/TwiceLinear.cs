using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TwiceLinearKata
    {
        public static int DblLinear(int n)
        {
            var ix = 0;
            var iy = 0;
            var sequence = new List<int> { 1 };
            
            for (var i = 0; i < n; i++) 
            {
                var nextX  = 2 * sequence.ElementAt(ix) + 1;
                var nextY = 3 * sequence.ElementAt(iy) + 1;

                if (nextX <= nextY)
                {
                    sequence.Add(nextX); 
                    ix++;

                    if (nextX == nextY)
                    {
                        iy++;
                    }
                }
                else
                {
                    sequence.Add(nextY); 
                    iy++;
                }
            }
            
            return sequence.ElementAt(n);
        }
    }

    public class TwiceLinearTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(10, 22)]
        [InlineData(20, 57)]
        [InlineData(30, 91)]
        [InlineData(43, 139)]
        [InlineData(44, 159)]
        [InlineData(50, 175)]
        public void ExecuteDblLinearExample(int index, int element)
        {
            TwiceLinearKata.DblLinear(index).Should().Be(element);
        }
    }
}
