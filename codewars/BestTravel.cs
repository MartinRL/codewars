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
            if (k > ls.Count)
                return null;
            
            return new CombinationsCreator().CreateFor(ls.ToArray(), k)
                .Select(_ => _.Sum())
                .Where(_ => _ <= t)
                .Max();
        }
    }

    public class CombinationsCreator
    {
        private void CreateCombinationFor(int[] arr, int k, int index, int[] data, int i, Queue<int[]> combinations)
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
            
            CreateCombinationFor(arr, k, index + 1, data, i + 1, combinations);
            CreateCombinationFor(arr, k, index, data, i + 1, combinations);
        }

        public IEnumerable<int[]> CreateFor(int[] arr, int r)
        {
            var data = new int[r];
            var combinations = new Queue<int[]>();
            CreateCombinationFor(arr, r, 0, data, 0, combinations);

            return combinations;
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
