using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MaximumSubarraySumSolution
    {
        public static int MaxSequence(int[] arr)
        {
            var n = arr.Length;
            
            if (n == 0 || arr.All(_ => _ <= 0))
                return 0;
            
            return MaxSubArraySum(arr, 0, n-1); 
        }
        
        // Returns sum of maxium sum subarray in aa[l..h] 
        static int MaxSubArraySum(int []arr, int l, int h) 
        {
            // Base Case: Only one element 
            if (l == h) 
                return arr[l]; 
  
            // Find middle point 
            var m = (l + h)/2; 
  
            /* Return maximum of following three possible cases: 
            a) Maximum subarray sum in left half 
            b) Maximum subarray sum in right half 
            c) Maximum subarray sum such that the subarray crosses the midpoint */
            return Math.Max(Math.Max(MaxSubArraySum(arr, l, m), 
                                     MaxSubArraySum(arr, m+1, h)), 
                                     MaxCrossingSum(arr, l, m, h)); 
        } 
        
        // Find the maximum possible sum in arr[] such that arr[m] is part of it 
        static int MaxCrossingSum(int []arr, int l, int m, int h) 
        { 
            // Include elements on left of mid. 
            var sum = 0; 
            var leftSum = int.MinValue; 
            for (var i = m; i >= l; i--) 
            { 
                sum = sum + arr[i]; 
                if (sum > leftSum) 
                    leftSum = sum; 
            } 
  
            // Include elements on right of mid 
            sum = 0; 
            var rightSum = int.MinValue;; 
            for (var i = m + 1; i <= h; i++) 
            { 
                sum = sum + arr[i]; 
                if (sum > rightSum) 
                    rightSum = sum; 
            } 
  
            // Return sum of elements on left and right of mid 
            return leftSum + rightSum; 
        } 
    }

    public class MaximumSubarraySumTests
    {
        [Theory]
        [InlineData(new int[0], 0)]
        [InlineData(new[]{1, 2, 3}, 6)]
        [InlineData(new[]{-1, -2, -3}, 0)]
        [InlineData(new[]{-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6)]
        public void VerifyMaxSequenceWith(int[] arr, int expected)
        {
            MaximumSubarraySumSolution.MaxSequence(arr).Should().Be(expected);
        }
    }
}
