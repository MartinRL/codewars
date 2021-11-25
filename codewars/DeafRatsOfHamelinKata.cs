namespace codewars;

public class DeafRatsOfHamelinSolution
{
    public static int CountDeafRats(string town) => town.Replace(" ", string.Empty).Skip(1).Select((c, i) => c == '~' && i % 2 == 0).Count(_ => _);
}

public class DeafRatsOfHamelinTests
{
    [Theory]
    [InlineData("~0~0~0~0 P", 0)]
    [InlineData("~0~0~0~0P", 0)]
    [InlineData("P O~ O~ ~O O~", 1)]
    [InlineData("PO~O~~OO~", 1)]
    [InlineData("~O~O~O~OP~O~OO~", 2)]
    [InlineData("P~O~OO~", 2)]
    [InlineData("O~~OO~~OO~~OO~ P~OO~~OO~~OO~~O", 8)]
    [InlineData("O~~OO~~OO~~OO~P ~OO~~OO~~OO~~O", 8)]
    [InlineData("~O~O ~O~O~O~O~O ~O~OO~~O~O~O~O~O~O~O~OP~OO~O~O~O~O~O~~OO~O~~OO~O~O~O~O~O~O~O~O~", 4)]
    public void VerifyCountDeafRatsWith(string town, int expectedNoOfDeafRats) => DeafRatsOfHamelinSolution.CountDeafRats(town).Should().Be(expectedNoOfDeafRats);
}