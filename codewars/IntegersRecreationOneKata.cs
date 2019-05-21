using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class IntegersRecreationOneSolution
    {
        public static string ListSquared(long m, long n)
        {
            throw new NotImplementedException();
        }
    }

    public class IntegersRecreationOneTests
    {
        [Theory]
        [InlineData(1, 250, "[[1, 1], [42, 2500], [246, 84100]]")]
        [InlineData(42, 250, "[[42, 2500], [246, 84100]]")]
        [InlineData(250, 500, "[[287, 84100]]")]
        public void VerifyListSquaredWith(long m, long n, string expectedSquared)
        {
            IntegersRecreationOneSolution.ListSquared(m, n).Should().Be(expectedSquared);
        }
    }
}
