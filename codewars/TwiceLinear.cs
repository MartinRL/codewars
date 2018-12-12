using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class TwiceLinearKata
    {
        private static ISet<int> elements = new SortedSet<int>();

        private static int index;
        
        public static int DblLinear(int n)
        {
            index = n;
            
            InitElements(1);

            return elements.ElementAt(n);
        }

        private static void InitElements(params int[] elementsToAdd)
        {
            while (elements.Count < index)
            {
                var yZ = new List<int>();
                
                foreach (var element in elementsToAdd)
                {
                    elements.Add(element);
                    yZ.Add(element * 2 + 1);
                    yZ.Add(element * 3 + 1);
                }
                
                InitElements(yZ.ToArray());
            }
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
