using Xunit.Abstractions;

namespace codewars;

public class RegularExpressionCheckIfDivisibleBy0b111Solution
{
    public static string MultipleOf7() => @"(?<regex>
    # The base case: single digits that are multiples of 7
    (?:0|111) |
    # The recursive case: any number that satisfies the rule
    (?:
        # Capture the last three bits and the rest of the number
        (000|001|010|011|100|101|110|111) (.*)
        # Check if the last three bits plus four times the rest of the number matches the regex
        (?= (?&regex))
    )
)";
}

public class RegularExpressionCheckIfDivisibleBy0b111Tests
{
    private static string rgxStr = RegularExpressionCheckIfDivisibleBy0b111Solution.MultipleOf7();
    
    private readonly ITestOutputHelper output;

    public RegularExpressionCheckIfDivisibleBy0b111Tests(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Fact]
    public void EdgeCases()
    {
        Regex.Match("", rgxStr).Success.Should().BeFalse();
        
        Regex.Match("0", rgxStr).Success.Should().BeTrue();
    }
    
    [Fact]
    public void FixedTests1000()
    {
        for (var i=1; i<100; i++) 
        {
            output.WriteLine(i.ToString());

            Regex.Match(Convert.ToString(i, 2), rgxStr).Success.Should().Be(i%7 == 0);
        }
    }
}
