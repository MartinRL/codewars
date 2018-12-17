using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class ArrayDiffKata
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            return a.Where(x => !b.Contains(x)).ToArray();
        }
    }

    public class ArrayDiffTests
    {
        [Theory]
        [InlineData(new [] { 1, 2}, new [] { 1 }, new [] { 2 })]
        [InlineData(new [] { 1, 2, 2}, new [] { 1 }, new [] { 2, 2 })]
        [InlineData(new [] { 1, 2, 2}, new [] { 2 }, new [] { 1 })]
        public void ElementsInBShouldBeRemovedFromA(int[] a, int[] b, int[] c)
        {
            ArrayDiffKata.ArrayDiff(a, b).Should().BeEquivalentTo(c);
        }
    }
}
