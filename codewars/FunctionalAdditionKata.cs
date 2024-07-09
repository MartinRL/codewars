namespace codewars;

public class FunctionalAdditionSolution
{
    public static Func<double, double> Add(double leftTerm) => rightTerm => leftTerm + rightTerm;
}

public class FunctionalAdditionTests
{
    [Fact]
    public void ShouldGiveAddFunc() => FunctionalAdditionSolution.Add(1)(3).Should().Be(4);
}
