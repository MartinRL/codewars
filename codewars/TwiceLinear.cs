using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TwiceLinearKata
    {
        public static int DblLinear(int n)
        {
            throw new NotImplementedException();
        }
    }

    public class TwiceLinearTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(10, 22)]
        public void ExecuteDblLinearExample(int index, int element)
        {
            TwiceLinearKata.DblLinear(index).Should().Be(element);
        }
    }
}
