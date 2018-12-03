using System;
using System.Linq;
using Xunit;

namespace codewars
{
    public static class Kata
    {
        public static int CountSheep(bool[] sheep)
        {
            return sheep.Count(_ => _);
        }
    }
    
    public class CountSheepTests 
    {
        [Theory]
        [InlineData(new[] { true, false, true }, 2)]
        [InlineData(new[] { true,  true,  true,  false,
                            true,  true,  true,  true,
                            true,  false, true,  false,
                            true,  false, false, true,
                            true,  true,  true,  true,
                            false, false, true,  true }, 17)]
        [InlineData(new[] { false, false, false, false, 
                            false, false, false, false, 
                            false, false, false, false }, 0)]
        public void SampleTest(bool[] sheep, int expected) 
        {
            Assert.Equal(Kata.CountSheep(sheep), expected);
        }
    }
}
