using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class Kata
    {
        public static Func<double, double> Add(double term)
        {
            throw new NotImplementedException();
        }
    }

    public class FunctionalAdditionTests
    {
        [Fact]
        public void ShouldGiveAddFunc()
        {
            Kata.Add(1)(3).Should().Be(4);
        }
    }
}
