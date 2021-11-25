namespace codewars;

public class DnaToRnaConversionSolution
{
    public static string DnaToRna(string dna) => dna.Replace('T', 'U');
}

public class DnaToRnaConversionTests
{
    [Theory]
    [InlineData("GCAT", "GCAU")]
    [InlineData("TTTT", "UUUU")]
    public void VerifyDnaToRnaWith(string dna, string expectedRna) => DnaToRnaConversionSolution.DnaToRna(dna).Should().Be(expectedRna);
}