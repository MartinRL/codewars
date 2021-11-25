namespace codewars;

public class HammingDistanceSolution
{
    public static int CalculateDistance(string a, string b) => a.Zip(b, (ca, cb) => !ca.Equals(cb)).Count(_ => _);
}

public class HammingDistanceTests
{
    [Theory]
    [InlineData("hello world", "hello world", 0)]
    [InlineData("I like turtles", "I like turkeys", 3)]
    public void VerifyCalculateDistanceWith(string a, string b, int expectedDistance) => HammingDistanceSolution.CalculateDistance(a, b).Should().Be(expectedDistance);
}