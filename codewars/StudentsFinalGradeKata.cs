using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class StudentsFinalGradeSolution
    {
        public static int FinalGrade(int exam, int projects) =>
            exam > 90 || projects > 10 ? 100 :
            exam > 75 && projects > 4 ? 90 :
            exam > 50 && projects > 1 ? 75 :
            0;
    }

    public class StudentsFinalGradeTests
    {
        [Theory]
        [InlineData(100, 12, 100)]
        [InlineData(99, 0, 100)]
        [InlineData(90, 5, 90)]
        [InlineData(10, 15, 100)]
        [InlineData(85, 5, 90)]
        [InlineData(55, 3, 75)]
        [InlineData(55, 0, 0)]
        [InlineData(20, 2, 0)]
        public void VerifyFinalGradeWith(int exam, int projects, int expected) => StudentsFinalGradeSolution.FinalGrade(exam, projects).Should().Be(expected);
    }
}
