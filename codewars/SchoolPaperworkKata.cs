namespace codewars;

public class SchoolPaperworkSolution
{
    public static int Paperwork(int n, int m) => (n < 0 || m < 0) ? 0 : n * m;
}

public class SchoolPaperworkTests
{
    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(-5, 5, 0)]
    public void VerifyPaperworkWith(int n, int m, int expectedNoOfBlankPages) => SchoolPaperworkSolution.Paperwork(n, m).Should().Be(expectedNoOfBlankPages);
}
