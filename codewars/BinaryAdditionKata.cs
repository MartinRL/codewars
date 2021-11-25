namespace codewars;

public class BinaryAdditionSolution
{
    public static string AddBinary(int firstTerm, int secondTerm) => Convert.ToString(firstTerm + secondTerm, 2);
}

public class BinaryAdditionTests
{
    [Theory]
    [InlineData(1, 2, "11")]
    [InlineData(5, 10, "1111")]
    [InlineData(0, 235, "11101011")]
    public void VerifyAddBinaryWith(int firstTerm, int secondTerm, string expected) => BinaryAdditionSolution.AddBinary(firstTerm, secondTerm).Should().Be(expected);
}