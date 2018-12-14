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
            IEnumerable<int> elements = new List<int> { 1 };

            while (elements.Count() <= n * 2)
            {
                elements = elements.SelectMany(x => new List<int> {x, x * 2 + 1, x * 3 + 1}).Distinct();
            }

            return elements.OrderBy(_ => _).ElementAt(n);
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
