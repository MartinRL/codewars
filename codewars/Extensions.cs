using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

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
        
        public static int ToNumber(this IEnumerable<int> @this)
        {
            return int.Parse(string.Join(string.Empty, @this));
        }
        
        public static string Repeating(this string @this)
        {
            var j = 0;
            
            for (var i = 1; i < @this.Length; i++)
            {
                if (@this[i] != @this[0]) continue;
                
                j = i;
                break;
            }

            return @this.Substring(0, j);
        }
    }

    public class ExtensionsTests
    {
        [Theory]
        [InlineData("1939193919", "1939")]
        [InlineData("1939193919391939", "1939")]
        public void VerifyRepeatingWith(string str, string repeats)
        {
            str.Repeating().Should().Be(repeats);
        }
    }
}
