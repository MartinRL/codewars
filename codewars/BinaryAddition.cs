using FluentAssertions;
using Xunit;

namespace codewars
{
    public class BinaryAdditionKata
    {
        public static string AddBinary(int firstTerm, int secondTerm)
        {
            // your code ...
        }
    }
    
    public class BinaryAdditionTests
    {
        [Theory]
        [InlineData(1, 2, "11")]
        public void RunCountDuplicatesTheory(int firstTerm, int secondTerm, string expected)
        {
            BinaryAdditionKata.AddBinary(firstTerm, secondTerm).Should().Be(expected);
        }
    }
}
