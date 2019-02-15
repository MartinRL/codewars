using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class BestTravelKata
    {
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            return ls.CombinationsOf(k)
                .Select(_ => _.Sum())
                .Where(_ => _ <= t)
                .Max();
        }
    }
    
    /*
     * 
using System;
class GFG {
static void combinationUtil(int []arr,
int n, int r, int index,
int []data, int i)
{
if (index == r)
{
for (int j = 0; j < r; j++)
Console.Write(data[j] + " ");
Console.WriteLine("");
return;
}
if (i >= n)
return;
data[index] = arr[i];
combinationUtil(arr, n, r, index + 1,
data, i + 1);
combinationUtil(arr, n, r, index,
data, i + 1);
}
static void printCombination(int []arr,
int n, int r)
{
int []data = new int[r];
combinationUtil(arr, n, r, 0, data, 0);
}
public static void Main()
{
int []arr = { 10, 20, 30, 40, 50 };
int r = 3;
int n = arr.Length;
printCombination(arr, n, r);
}
}
     * */
    public class BestTravelTests
    {
        [Theory]
        [InlineData(163, 3, new [] { 50, 55, 56, 57, 58 }, 163)]
        [InlineData(163, 3, new [] { 50 }, null)]
        [InlineData(230, 3, new [] { 91, 74, 73, 85, 73, 81, 87 }, 228)]
        public void ExecuteChooseBestSumExample(int t, int k, int[] ls, int? expected)
        {
            BestTravelKata.chooseBestSum(t, k, ls.ToList()).Should().Be(expected);
        }

        [Fact]
        public void CombinationsOfShouldReturnAllCombinationsOfThree()
        {
            new [] {50, 55, 57, 58, 60}.CombinationsOf(3).Should().AllBeEquivalentTo(new [] 
            { 
                new [] {50, 55, 57},  
                new [] {50, 55, 58},  
                new [] {50, 55, 60},  
                new [] {50, 57, 58},  
                new [] {50, 57, 60},  
                new [] {50, 58, 60},  
                new [] {55, 57, 58},  
                new [] {55, 57, 60},  
                new [] {55, 58, 60},  
                new [] {57, 58, 60} 
             });
        }
    }
}
