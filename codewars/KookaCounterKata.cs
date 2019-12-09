namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class KookaCounterSolution
    {
        public static int Count(string laughing)
        {
            if (string.IsNullOrEmpty(laughing))
                return 0;

            var counter = 1;
            var hs = laughing.Replace("a", string.Empty);
            var current = hs.First();

            for (var i = 1; i < hs.Length; i++)
            {
                if (hs[i] != current)
                {
                    counter++;
                    current = hs[i];
                }
            }

            return counter;
        }
    }

    public static class KookaCounterExtensions
    {
        public static char ToggleCase(this char @this) => char.IsLower(@this) ? @this.ToString().ToUpper().First() : @this.ToString().ToLower().First();
    }

    public class KookaCounterTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("hahahahaha", 1)]
        [InlineData("hahahahahaHaHaHa", 2)]
        [InlineData("HaHaHahahaHaHa", 3)]
        public void VerifyCountWith(string laughing, int expectedNoOfKookas) => KookaCounterSolution.Count(laughing).Should().Be(expectedNoOfKookas);
    }
}
