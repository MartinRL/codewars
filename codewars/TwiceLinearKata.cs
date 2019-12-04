using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TwiceLinearSolution
    {
        public static int DblLinear(int n)
        {
            return Sequence().ElementAt(n);
        }

        private static IEnumerable<int> Sequence()
        {
            var set = new SortedSet<int> { 1 };
            
            while (true)
            {
                var top = set.First();
                
                yield return top;
                
                set.Remove(top);
                set.Add(top * 2 + 1);
                set.Add(top * 3 + 1);
            }
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
        public void VerifyDblLinearWith(int index, int element) => TwiceLinearSolution.DblLinear(index).Should().Be(element);
    }
}
