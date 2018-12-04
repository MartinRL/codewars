using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class MumblingKata
    {
        public static string Accum(string s)
        {
            throw new NotImplementedException();
        }
    }

    public class MumblingTests
    {
        [Theory]
        [InlineData("abcd", "A-Bb-Ccc-Dddd")]
        [InlineData("RqaEzty", "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy")]
        [InlineData("cwAt", "C-Ww-Aaa-Tttt")]
        public void RunAccumTheory(string s, string accummed)
        {
            MumblingKata.Accum(s).Should().Be(accummed);
        }
    }
}
