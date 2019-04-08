using System;
using System.Collections.Generic;
using System.Linq;

namespace codewars
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var element in @this)
            {
                action(element);
            }
        }
        
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> @this, int k)
        {
            return k == 0 
                ? new[] { new T[0] } 
                : @this.SelectMany((e, i) => @this
                                             .Skip(i + 1)
                                             .Combinations(k - 1)
                                             .Select(c => (new[] {e}).Concat(c)));
        }
        
        public static int[] ToDigits(this int @this)
        {
            return @this.ToString().Select(_ => (int)char.GetNumericValue(_)).ToArray();
        }
    }
}
