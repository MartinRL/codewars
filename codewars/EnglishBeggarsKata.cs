using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class EnglishBeggarsSolution
    {
        public static int[] Beggars(int[] values, int n)
        {
            /*var f = values.Select((e, i) => i % 2 == 0 ? e : 0).Sum();
            var s = values.Select((e, i) => i % 2 == 1 ? e : 0).Sum();

            return new[] {f, s};*/

            var beggars = new int[n];
            var valuesLeft = values.ToList();

            for (var i = 0; i < n; i++)
            {
                valuesLeft = valuesLeft.Skip(i).ToList();
                beggars[i] = valuesLeft.Where((e, index) => index % n == 0).Sum();
            }

            return beggars;
        }
    }

    public class EnglishBeggarsTests
    {
        [Theory]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 1, new [] { 15 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 2, new [] { 9, 6 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 3, new [] { 5, 7, 3 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 6, new [] { 1, 2, 3, 4, 5, 0 })]
        [InlineData( new [] { 1, 2, 3, 4, 5 }, 0, new int[] {})]

        public void VerifyBeggarsWith(int[] values, int n, int[] expectedBeggars)
        {
            EnglishBeggarsSolution.Beggars(values, n).Should().BeEquivalentTo(expectedBeggars);
        }
    }
}
