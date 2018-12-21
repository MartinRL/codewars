﻿using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class JosephusSurvivorKata
    {
        public static int JosSurvivor(int n, int k) 
        {
            if (n == 1)
                return 1;
            
            return (JosSurvivor(n - 1, k) + k - 1) % n + 1;
        }  
    }

    public class JosephusSurvivorTests
    {
        [Theory]
        [InlineData(7, 3, 4)]
        [InlineData(11, 19, 10)]
        [InlineData(40, 3, 28)]
        [InlineData(14, 2, 13)]
        [InlineData(4, 2, 1)]
        [InlineData(100, 1, 100)]
        [InlineData(1, 300, 1)]
        [InlineData(2, 300, 1)]
        [InlineData(5, 300, 1)]
        [InlineData(7, 300, 7)]
        [InlineData(300, 300, 265)]
        public void ExecuteJosSurvivorExample(int n, int k, int expected)
        {
            JosephusSurvivorKata.JosSurvivor(n, k).Should().Be(expected);
        }
    }
}
