namespace codewars;

using System.Linq;
using FluentAssertions;
using Xunit;
using static System.String;

public class YourOrderSolution
{
    public static string Order(string words) => IsNullOrEmpty(words) ? Empty : Join(" ", words.Split().OrderBy(s => s.Single(char.IsDigit)));
}

public class YourOrderTests
{
    [Theory]
    [InlineData("is2 Thi1s T4est 3a", "Thi1s is2 3a T4est")]
    [InlineData("4of Fo1r pe6ople g3ood th5e the2", "Fo1r the2 g3ood 4of th5e pe6ople")]
    [InlineData("", "")]
    public void VerifyOrderWith(string words, string orderedWords) => YourOrderSolution.Order(words).Should().Be(orderedWords);
}