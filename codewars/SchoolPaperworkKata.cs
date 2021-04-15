namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SchoolPaperworkSolution
    {
        public static int Paperwork(int n, int m) => throw new NotImplementedException();
    }

    public class SchoolPaperworkTests
    {
        [Theory]
        [InlineData(5, 5, 25)]
        [InlineData(-5, 5, 0)]
        public void VerifyPaperworkWith(int n, int m, int expectedNoOfBlankPages) => SchoolPaperworkSolution.Paperwork(n, m).Should().Be(expectedNoOfBlankPages);
    }
}
