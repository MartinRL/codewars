﻿using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class CountSheepKata
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
        public void ExecuteCountSheepExample(bool[] sheep, int expected) 
        {
            CountSheepKata.CountSheep(sheep).Should().Be(expected);
        }
    }
}
