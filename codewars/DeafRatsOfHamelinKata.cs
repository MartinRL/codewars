namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class DeafRatsOfHamelinSolution
    {
        public static int CountDeafRats(string town)
        {
            throw new NotImplementedException();
        }
    }

    public class DeafRatsOfHamelinTests
    {
        [Theory]
        [InlineData("~0~0~0~0 P", 0)]
        [InlineData("P O~ O~ ~O O~", 1)]
        [InlineData("~O~O~O~OP~O~OO~", 2)]
        public void VerifyCountDeafRatsWith(string town, int expectedNoOfDeafRats) => DeafRatsOfHamelinSolution.CountDeafRats(town).Should().Be(expectedNoOfDeafRats);
    }
}
