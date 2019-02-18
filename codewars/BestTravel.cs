using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class SumOfK
    {
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            try
            {
                return new Combinations(ls, k)
                    .Select(_ => _.Sum())
                    .Where(_ => _ <= t)
                    .Max();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class Combinations : IEnumerable<int[]>
    {
        Queue<int[]> combinations = new Queue<int[]>();

        public Combinations(List<int> list, int k)
        {
            CreateCombinationFor(list.ToArray(), k, 0, new int[k], 0);    
        }
        
        private void CreateCombinationFor(int[] arr, int k, int index, int[] data, int i)
        {
            if (index == k)
            {
                var combination = new int[k];
                
                for (var j = 0; j < k; j++)
                    combination[j] = data[j];
                
                combinations.Enqueue(combination);
                
                return;
            }

            if (i >= arr.Length)
                return;
            
            data[index] = arr[i];
            
            CreateCombinationFor(arr, k, index + 1, data, i + 1);
            CreateCombinationFor(arr, k, index, data, i + 1);
        }

        public IEnumerator<int[]> GetEnumerator()
        {
            return combinations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BestTravelTests
    {
        [Theory]
        [InlineData(163, 3, new [] { 50, 55, 56, 57, 58 }, 163)]
        [InlineData(163, 3, new [] { 50 }, null)]
        [InlineData(230, 3, new [] { 91, 74, 73, 85, 73, 81, 87 }, 228)]
        public void ExecuteChooseBestSumExample(int t, int k, int[] ls, int? expected)
        {
            SumOfK.chooseBestSum(t, k, ls.ToList()).Should().Be(expected);
        }
    }
}
