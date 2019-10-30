using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class DnaToRnaConversionSolution
    {
        public static string DnaToRna(string dna)
        {
            throw new NotImplementedException();
        }
    }

    public class DnaToRnaConversionTests
    {
        [Theory]
        [InlineData("GCAT", "GCAU")]
        [InlineData("UUUU", "TTTT")]
        public void VerifyDnaToRnaWith(string dna, string expectedRna)
        {
            DnaToRnaConversionSolution.DnaToRna(dna).Should().Be(expectedRna);
        }
    }
}
